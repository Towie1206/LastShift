#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[InitializeOnLoad]
public static class SetupMainRoomLights
{
    private const string RootName = "MainRoom_Lights";

    [InitializeOnLoadMethod]
    private static void AutoInit()
    {
        EditorApplication.delayCall += () =>
        {
            if (Application.isPlaying) return;
            var activeScene = EditorSceneManager.GetActiveScene();
            if (activeScene.name != "Game") return;
            if (GameObject.Find(RootName) != null) return;

            CreateLightsInternal(silent: true);
        };
    }

    [MenuItem("Tools/LastShift/Setup MainRoom Lights (Tạo dàn đèn sân khấu & sảnh tiệc)")]
    public static void CreateLightsMenu()
    {
        CreateLightsInternal(silent: false);
    }

    private static void CreateLightsInternal(bool silent)
    {
        GameObject existing = GameObject.Find(RootName);
        if (existing != null)
        {
            if (!silent)
            {
                if (EditorUtility.DisplayDialog("Xác nhận", $"Đã tìm thấy '{RootName}' trong scene. Bạn có muốn xóa đi và tạo lại bộ đèn mới?", "Tạo lại", "Hủy"))
                {
                    Undo.DestroyObjectImmediate(existing);
                }
                else
                {
                    Selection.activeGameObject = existing;
                    return;
                }
            }
            else
            {
                return;
            }
        }

        GameObject mapObj = GameObject.Find("Map");
        Transform parentTransform = mapObj != null ? mapObj.transform : null;

        GameObject root = new GameObject(RootName);
        Undo.RegisterCreatedObjectUndo(root, "Create MainRoom Lights");
        if (parentTransform != null)
        {
            root.transform.SetParent(parentTransform);
        }
        root.transform.localPosition = Vector3.zero;
        root.transform.localRotation = Quaternion.identity;

        // 1. Stage_SpotLight: Rọi thẳng vào Freddy trên bục sân khấu (Stage ở -21, 0.5, 0)
        CreateLightObject("Stage_SpotLight", root.transform,
            new Vector3(-17f, 5.5f, 0f),
            new Vector3(55f, -90f, 0f),
            LightType.Spot,
            range: 10f,
            intensity: 22f,
            color: new Color(1f, 0.96f, 0.88f),
            shadows: LightShadows.Soft,
            spotAngle: 55f,
            innerSpotAngle: 38f);

        // 2. Stage_RimLight: Đèn viền sau lưng sân khấu - tạo bóng Silhouette ma mị cho Freddy
        CreateLightObject("Stage_RimLight", root.transform,
            new Vector3(-23.5f, 3.2f, 0f),
            new Vector3(0f, 90f, 0f),
            LightType.Point,
            range: 3.5f,
            intensity: 2.5f,
            color: new Color(0.35f, 0.5f, 0.75f),
            shadows: LightShadows.None);

        // 3. Dining_CenterLight: Đèn sảnh tiệc / Bàn ăn trung tâm (gần Point 01 Main)
        CreateLightObject("Dining_CenterLight", root.transform,
            new Vector3(-10f, 4.8f, 2f),
            new Vector3(90f, 0f, 0f),
            LightType.Point,
            range: 8.5f,
            intensity: 9f,
            color: new Color(1f, 0.84f, 0.6f),
            shadows: LightShadows.Soft);

        // 4. Dining_SideLight: Đèn phụ rọi khu vực bàn tiệc hướng về Cam 00B
        CreateLightObject("Dining_SideLight", root.transform,
            new Vector3(-4f, 4.8f, 6f),
            new Vector3(90f, 0f, 0f),
            LightType.Point,
            range: 7.5f,
            intensity: 7f,
            color: new Color(1f, 0.84f, 0.6f),
            shadows: LightShadows.Soft);

        // Cập nhật Ambient Color nếu đang là đen sì
        if (RenderSettings.ambientSkyColor == Color.black)
        {
            RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Flat;
            RenderSettings.ambientSkyColor = new Color(0.05f, 0.08f, 0.12f, 1f);
        }

        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        Selection.activeGameObject = root;

        Debug.Log("<color=#00FF7F><b>[LastShift]</b></color> Đã tự động tạo xong dàn đèn 'MainRoom_Lights' (Stage Spotlight, Stage Rimlight, Dining Lights) chuẩn tọa độ!");
    }

    private static GameObject CreateLightObject(string name, Transform parent, Vector3 worldPos, Vector3 rotation, LightType type, float range, float intensity, Color color, LightShadows shadows, float spotAngle = 60f, float innerSpotAngle = 40f)
    {
        GameObject go = new GameObject(name);
        Undo.RegisterCreatedObjectUndo(go, $"Create {name}");
        go.transform.SetParent(parent);
        go.transform.position = worldPos;
        go.transform.eulerAngles = rotation;

        Light light = go.AddComponent<Light>();
        light.type = type;
        light.range = range;
        light.intensity = intensity;
        light.color = color;
        light.shadows = shadows;

        if (type == LightType.Spot)
        {
            light.spotAngle = spotAngle;
            light.innerSpotAngle = innerSpotAngle;
        }

        UniversalAdditionalLightData urpLight = go.GetComponent<UniversalAdditionalLightData>();
        if (urpLight == null)
        {
            urpLight = go.AddComponent<UniversalAdditionalLightData>();
        }
        urpLight.usePipelineSettings = true;

        return go;
    }
}
#endif
