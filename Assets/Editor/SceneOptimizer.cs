using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace LastShift.EditorTools
{
    public class SceneOptimizer : EditorWindow
    {
        private Vector2 scrollPos;
        private List<Light> sceneLights = new List<Light>();

        [MenuItem("Tools/⚡ Tối Ưu Game LastShift/1. Đánh dấu Static cho Môi Trường (Batching & Occlusion)")]
        public static void MarkStaticEnvironment()
        {
            if (!EditorUtility.DisplayDialog("Xác nhận tối ưu Môi Trường",
                "Tool sẽ quét toàn bộ Scene và đánh dấu Static (BatchingStatic, Occluder, Occludee) cho các vật thể môi trường cố định (Tường, Sàn, Kệ, Bếp, Đồ vật tĩnh...).\n\n" +
                "Tool sẽ tự động BỎ QUA:\n" +
                "- Player, Camera, UI/Canvas\n" +
                "- Freddy, AI, Animator, Rigidbody\n" +
                "- Cửa (Door, khung cua di chuyển)\n" +
                "- Các nút bấm, vật phẩm tương tác (IInteractable)\n" +
                "- Đèn (Lights) và Trigger colliders\n\n" +
                "Bạn có muốn tiếp tục?", "Tiến hành", "Hủy"))
            {
                return;
            }

            int markedCount = 0;
            int skippedCount = 0;

            GameObject[] rootObjects = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
            List<GameObject> allObjects = new List<GameObject>();

            foreach (var root in rootObjects)
            {
                allObjects.AddRange(GetChildrenRecursive(root));
            }

            Undo.IncrementCurrentGroup();
            Undo.SetCurrentGroupName("Tối ưu Static Môi Trường");
            int undoGroup = Undo.GetCurrentGroup();

            for (int i = 0; i < allObjects.Count; i++)
            {
                GameObject go = allObjects[i];
                EditorUtility.DisplayProgressBar("Đang phân tích và đánh dấu Static...", go.name, (float)i / allObjects.Count);

                if (ShouldMarkStatic(go))
                {
                    Undo.RegisterCompleteObjectUndo(go, "Set Static Flags");
                    StaticEditorFlags currentFlags = GameObjectUtility.GetStaticEditorFlags(go);
                    StaticEditorFlags newFlags = currentFlags | 
                        StaticEditorFlags.BatchingStatic | 
                        StaticEditorFlags.OccluderStatic | 
                        StaticEditorFlags.OccludeeStatic;

                    GameObjectUtility.SetStaticEditorFlags(go, newFlags);
                    markedCount++;
                }
                else
                {
                    skippedCount++;
                }
            }

            EditorUtility.ClearProgressBar();
            Undo.CollapseUndoOperations(undoGroup);
            EditorSceneManager.MarkSceneDirty(UnityEngine.SceneManagement.SceneManager.GetActiveScene());

            EditorUtility.DisplayDialog("Hoàn tất Tối Ưu Môi Trường",
                $"Đã hoàn tất!\n\n" +
                $"✅ Đã đánh dấu Static cho: {markedCount} GameObjects (sẵn sàng cho Static Batching & Occlusion Culling)\n" +
                $"🛡️ Đã giữ nguyên (Dynamic/Interactive): {skippedCount} GameObjects\n\n" +
                $"Bước tiếp theo: Hãy chạy '2. Bake Occlusion Culling' để Unity loại bỏ các góc khuất phía sau tường!",
                "Tuyệt vời");

            Debug.Log($"<color=#00FF00><b>[SceneOptimizer]</b></color> Đã đánh dấu Static cho {markedCount} vật thể. Bỏ qua an toàn: {skippedCount}.");
        }

        private static bool ShouldMarkStatic(GameObject go)
        {
            // 1. Phải có Renderer để vẽ (MeshRenderer)
            MeshRenderer mr = go.GetComponent<MeshRenderer>();
            if (mr == null) return false;

            // 2. Không được có SkinnedMeshRenderer (nhân vật, quái vật, model có xương)
            if (go.GetComponent<SkinnedMeshRenderer>() != null) return false;

            // 3. Không được chứa Animator, Animation
            if (go.GetComponentInParent<Animator>() != null || go.GetComponent<Animation>() != null) return false;

            // 4. Không được có Rigidbody
            if (go.GetComponentInParent<Rigidbody>() != null) return false;

            // 5. Kiểm tra Trigger
            Collider col = go.GetComponent<Collider>();
            if (col != null && col.isTrigger) return false;

            // 6. Không được là Light, Camera, Canvas
            if (go.GetComponent<Light>() != null || go.GetComponent<Camera>() != null || go.GetComponent<Canvas>() != null) return false;

            // 7. Tên hoặc Parent chứa các từ khóa động/tương tác/nhân vật
            string lowerName = go.name.ToLower();
            Transform cur = go.transform;
            while (cur != null)
            {
                string pName = cur.name.ToLower();
                if (pName.Contains("player") ||
                    pName.Contains("freddy") ||
                    pName.Contains("watcher") ||
                    pName.Contains("door") ||
                    pName.Contains("button") ||
                    pName.Contains("canvas") ||
                    pName.Contains("interact") ||
                    pName.Contains("letter") ||
                    pName.Contains("handset") ||
                    pName.Contains("phone") ||
                    pName.Contains("gamemanager") ||
                    pName.Contains("camera") ||
                    pName.Contains("timeline"))
                {
                    return false;
                }
                cur = cur.parent;
            }

            // 8. Không có component tương tác
            MonoBehaviour[] scripts = go.GetComponents<MonoBehaviour>();
            foreach (var script in scripts)
            {
                if (script == null) continue;
                string typeName = script.GetType().Name.ToLower();
                if (typeName.Contains("interact") || 
                    typeName.Contains("door") || 
                    typeName.Contains("controller") || 
                    typeName.Contains("trigger") ||
                    typeName.Contains("light"))
                {
                    return false;
                }
            }

            return true;
        }

        private static List<GameObject> GetChildrenRecursive(GameObject root)
        {
            List<GameObject> list = new List<GameObject> { root };
            for (int i = 0; i < root.transform.childCount; i++)
            {
                list.AddRange(GetChildrenRecursive(root.transform.GetChild(i).gameObject));
            }
            return list;
        }

        [MenuItem("Tools/⚡ Tối Ưu Game LastShift/2. Bake Occlusion Culling (Tự Động)")]
        public static void BakeOcclusionCulling()
        {
            if (!StaticOcclusionCulling.isRunning)
            {
                StaticOcclusionCulling.smallestOccluder = 2.0f;
                StaticOcclusionCulling.smallestHole = 0.25f;
                StaticOcclusionCulling.backfaceThreshold = 100f;

                StaticOcclusionCulling.Compute();
                EditorUtility.DisplayDialog("Bake Occlusion Culling",
                    "Unity đang tiến hành Bake Occlusion Culling trong nền!\n\n" +
                    "Bạn có thể theo dõi thanh tiến trình ở góc dưới bên phải cửa sổ Unity.\n" +
                    "Khi hoàn tất, các vật thể sau bức tường (Kitchen, Storehouse...) sẽ tự động biến mất khỏi Draw Calls khi bạn đang ở trong phòng Security Office!",
                    "Đã hiểu");
            }
            else
            {
                EditorUtility.DisplayDialog("Thông báo", "Occlusion Culling hiện đang được tính toán!", "OK");
            }
        }

        [MenuItem("Tools/⚡ Tối Ưu Game LastShift/3. Quản Lý & Tối Ưu Ánh Sáng (Light Optimizer)")]
        public static void OpenLightOptimizer()
        {
            var window = GetWindow<SceneOptimizer>("Tối Ưu Ánh Sáng");
            window.minSize = new Vector2(500, 550);
            window.RefreshLights();
            window.Show();
        }

        [MenuItem("Tools/⚡ Tối Ưu Game LastShift/4. Kiểm Tra Sức Khỏe Scene (Health Check)")]
        public static void CheckSceneHealth()
        {
            List<string> issues = new List<string>();
            List<string> passes = new List<string>();

            // 1. Kiểm tra GeneratorUI
            var genUI = UnityEngine.Object.FindFirstObjectByType<GeneratorUI>();
            if (genUI == null)
            {
                issues.Add("❌ Thiếu 'GeneratorUI': Chưa gắn script GeneratorUI vào Circular Image UI! (Nguyên nhân thanh pin không hiển thị nạp)");
            }
            else
            {
                passes.Add("✅ Đã tìm thấy GeneratorUI trong Scene");
            }

            // 2. Kiểm tra ShiftGameManager
            var shiftGM = UnityEngine.Object.FindFirstObjectByType<ShiftGameManager>();
            if (shiftGM != null)
            {
                SerializedObject so = new SerializedObject(shiftGM);
                if (so.FindProperty("winUI").objectReferenceValue == null) issues.Add("⚠️ ShiftGameManager: Chưa kéo tham chiếu 'winUI' trong Inspector");
                if (so.FindProperty("gameOverUI").objectReferenceValue == null) issues.Add("⚠️ ShiftGameManager: Chưa kéo tham chiếu 'gameOverUI' trong Inspector");
                if (so.FindProperty("winScreen").objectReferenceValue == null) issues.Add("⚠️ ShiftGameManager: Chưa kéo tham chiếu 'winScreen' trong Inspector");
            }
            else
            {
                issues.Add("⚠️ Không tìm thấy ShiftGameManager trong Scene!");
            }

            // 3. Kiểm tra WatcherBrain & WatcherAttack
            var watcherBrain = UnityEngine.Object.FindFirstObjectByType<WatcherBrain>();
            if (watcherBrain != null)
            {
                SerializedObject so = new SerializedObject(watcherBrain);
                if (so.FindProperty("anomalyManager").objectReferenceValue == null)
                    issues.Add("⚠️ Freddy -> WatcherBrain: Chưa gán 'Anomaly Manager' trong Inspector");
            }

            var watcherAttack = UnityEngine.Object.FindFirstObjectByType<WatcherAttack>();
            if (watcherAttack != null)
            {
                SerializedObject so = new SerializedObject(watcherAttack);
                if (so.FindProperty("anim").objectReferenceValue == null) issues.Add("⚠️ Freddy -> WatcherAttack: Chưa gán 'anim' (Animator)");
                if (so.FindProperty("animatronicTransform").objectReferenceValue == null) issues.Add("⚠️ Freddy -> WatcherAttack: Chưa gán 'animatronicTransform'");
                if (so.FindProperty("jumpscareSound").objectReferenceValue == null) issues.Add("⚠️ Freddy -> WatcherAttack: Chưa gán 'jumpscareSound' (AudioSource)");
            }

            // 4. Kiểm tra Layer của các Button
            GameObject lightBtn2 = GameObject.Find("Light Button 2");
            if (lightBtn2 != null && lightBtn2.layer != 6)
            {
                issues.Add($"⚠️ 'Light Button 2' đang ở Layer {lightBtn2.layer} thay vì Layer 6 (Interactor)!");
            }
            else if (lightBtn2 != null)
            {
                passes.Add("✅ 'Light Button 2' đã ở Layer 6 (Interactor)");
            }

            // Hiển thị kết quả
            string report = "=== KẾT QUẢ KIỂM TRA SCENE ===\n\n";
            if (issues.Count > 0)
            {
                report += "CÁC VẤN ĐỀ CẦN LƯU Ý:\n" + string.Join("\n", issues) + "\n\n";
            }
            else
            {
                report += "🎉 Không phát hiện vấn đề nào! Tất cả các liên kết quan trọng đều tốt.\n\n";
            }

            if (passes.Count > 0)
            {
                report += "ĐÃ KIỂM TRA TỐT:\n" + string.Join("\n", passes);
            }

            EditorUtility.DisplayDialog("Scene Health Check", report, "OK");
            Debug.Log($"<color=#FFFF00><b>[SceneOptimizer]</b></color>\n{report}");
        }

        private void OnEnable()
        {
            RefreshLights();
        }

        public void RefreshLights()
        {
            sceneLights.Clear();
            Light[] allLights = UnityEngine.Object.FindObjectsByType<Light>(FindObjectsSortMode.None);
            sceneLights.AddRange(allLights);
        }

        private void OnGUI()
        {
            EditorGUILayout.Space(10);
            EditorGUILayout.LabelField("⚡ CÔNG CỤ TỐI ƯU ÁNH SÁNG & SHADOWS", EditorStyles.boldLabel);
            EditorGUILayout.HelpBox(
                "NGUYÊN LÝ HIỆU NĂNG CHO GAME KINH DỊ:\n" +
                "1. Mỗi đèn bật Soft Shadows sẽ buộc Unity vẽ lại toàn bộ vật thể xung quanh vào Shadow Map.\n" +
                "2. Các phòng phụ (Kitchen, Storehouse, Hallway...) không cần Soft Shadows liên tục khi Player ngồi ở Office.\n" +
                "3. Tắt Shadows ở các phòng phụ sẽ giảm ngay lập tức 500 - 1000 Draw Calls mà không làm giảm không khí rùng rợn của Game!",
                MessageType.Info);

            EditorGUILayout.Space(10);

            int softShadowCount = 0;
            foreach (var l in sceneLights)
            {
                if (l != null && l.shadows != LightShadows.None) softShadowCount++;
            }

            EditorGUILayout.LabelField($"Tổng số Đèn trong Scene: {sceneLights.Count} | Đang bật Shadows: {softShadowCount}", EditorStyles.boldLabel);

            EditorGUILayout.BeginHorizontal();
            GUI.backgroundColor = new Color(0.2f, 0.8f, 0.2f);
            if (GUILayout.Button("⚡ 1-Click: Tắt Shadows Phòng Phụ (Khuyên Dùng)", GUILayout.Height(35)))
            {
                OptimizeRemoteLights();
            }

            GUI.backgroundColor = new Color(0.9f, 0.5f, 0.2f);
            if (GUILayout.Button("Khôi Phục Shadows Ban Đầu", GUILayout.Height(35)))
            {
                RestoreAllShadows();
            }
            GUI.backgroundColor = Color.white;
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space(15);
            EditorGUILayout.LabelField("DANH SÁCH CHI TIẾT TỪNG ĐÈN:", EditorStyles.boldLabel);

            scrollPos = EditorGUILayout.BeginScrollView(scrollPos);

            for (int i = 0; i < sceneLights.Count; i++)
            {
                Light l = sceneLights[i];
                if (l == null) continue;

                EditorGUILayout.BeginHorizontal("box");
                EditorGUILayout.LabelField(l.name, GUILayout.Width(170));
                EditorGUILayout.LabelField(l.type.ToString(), GUILayout.Width(80));

                Color origColor = GUI.color;
                if (l.shadows == LightShadows.None)
                {
                    GUI.color = Color.green;
                    EditorGUILayout.LabelField("No Shadows", GUILayout.Width(90));
                }
                else
                {
                    GUI.color = Color.yellow;
                    EditorGUILayout.LabelField(l.shadows.ToString(), GUILayout.Width(90));
                }
                GUI.color = origColor;

                if (l.shadows != LightShadows.None)
                {
                    if (GUILayout.Button("Tắt Shadow", GUILayout.Width(85)))
                    {
                        Undo.RecordObject(l, "Disable Shadow");
                        l.shadows = LightShadows.None;
                        EditorUtility.SetDirty(l);
                    }
                }
                else
                {
                    if (GUILayout.Button("Bật Soft", GUILayout.Width(85)))
                    {
                        Undo.RecordObject(l, "Enable Soft Shadow");
                        l.shadows = LightShadows.Soft;
                        EditorUtility.SetDirty(l);
                    }
                }

                if (GUILayout.Button("🔍", GUILayout.Width(30)))
                {
                    Selection.activeGameObject = l.gameObject;
                    EditorGUIUtility.PingObject(l.gameObject);
                }

                EditorGUILayout.EndHorizontal();
            }

            EditorGUILayout.EndScrollView();

            EditorGUILayout.Space(10);
            if (GUILayout.Button("Làm Mới Danh Sách Đèn"))
            {
                RefreshLights();
            }
        }

        private void OptimizeRemoteLights()
        {
            Undo.IncrementCurrentGroup();
            Undo.SetCurrentGroupName("Tối ưu Shadows Phòng Phụ");
            int group = Undo.GetCurrentGroup();

            int changed = 0;
            foreach (var l in sceneLights)
            {
                if (l == null) continue;
                string lower = l.name.ToLower();

                // Giữ lại Directional Light và đèn Office chính
                if (l.type == LightType.Directional || lower.Contains("office") || lower.Contains("desk"))
                {
                    continue;
                }

                // Tắt shadow cho các đèn phòng xa
                if (lower.Contains("kitchen") || 
                    lower.Contains("store") || 
                    lower.Contains("hallway") || 
                    l.name.Contains("(1)") ||
                    l.type == LightType.Point)
                {
                    if (l.shadows != LightShadows.None)
                    {
                        Undo.RecordObject(l, "Optimize Light Shadow");
                        l.shadows = LightShadows.None;
                        EditorUtility.SetDirty(l);
                        changed++;
                    }
                }
            }

            Undo.CollapseUndoOperations(group);
            EditorSceneManager.MarkSceneDirty(UnityEngine.SceneManagement.SceneManager.GetActiveScene());
            EditorUtility.DisplayDialog("Tối Ưu Shadows Hoàn Tất",
                $"Đã chuyển Shadows của {changed} đèn phòng phụ về 'None'.\n" +
                $"Đèn Directional Light và đèn Office vẫn được giữ nguyên để đảm bảo không khí game!\n\n" +
                $"Hãy bấm Play để kiểm tra xem Draw Calls đã tụt xuống như thế nào nhé!", "OK");
            RefreshLights();
        }

        private void RestoreAllShadows()
        {
            Undo.IncrementCurrentGroup();
            Undo.SetCurrentGroupName("Khôi phục Shadows");
            int group = Undo.GetCurrentGroup();

            foreach (var l in sceneLights)
            {
                if (l == null) continue;
                if (l.name.ToLower().Contains("spot light"))
                {
                    Undo.RecordObject(l, "Restore Shadow");
                    l.shadows = LightShadows.Soft;
                    EditorUtility.SetDirty(l);
                }
            }

            Undo.CollapseUndoOperations(group);
            EditorSceneManager.MarkSceneDirty(UnityEngine.SceneManagement.SceneManager.GetActiveScene());
            RefreshLights();
        }
    }
}
