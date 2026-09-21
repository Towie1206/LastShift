#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.ProBuilder;

[InitializeOnLoad]
public static class ApplyFNAFTexturesAndMaterials
{
    private const string TexturesFolder = "Assets/Art/Textures/FNAF";
    private const string MaterialsFolder = "Assets/Art/Materials/FNAF";
    private const string DoneMarker = "Assets/Art/Textures/FNAF/.fnaf_applied";

    [InitializeOnLoadMethod]
    private static void AutoRun()
    {
        EditorApplication.delayCall += () =>
        {
            if (Application.isPlaying) return;
            var activeScene = EditorSceneManager.GetActiveScene();
            if (activeScene.name != "Game") return;
            if (File.Exists(DoneMarker)) return;

            Execute();
        };
    }

    [MenuItem("Tools/LastShift/Apply FNAF Textures and Materials Now")]
    public static void Execute()
    {
        if (!Directory.Exists(TexturesFolder)) Directory.CreateDirectory(TexturesFolder);
        if (!Directory.Exists(MaterialsFolder)) Directory.CreateDirectory(MaterialsFolder);

        // 1. Kiểm tra / Tải textures
        Texture2D floorAsset = AssetDatabase.LoadAssetAtPath<Texture2D>($"{TexturesFolder}/T_FNAF_Floor_Checkered.png");
        Texture2D wallAsset = AssetDatabase.LoadAssetAtPath<Texture2D>($"{TexturesFolder}/T_FNAF_Wall.png");
        Texture2D doorAsset = AssetDatabase.LoadAssetAtPath<Texture2D>($"{TexturesFolder}/T_FNAF_Door.png");
        Texture2D carpetAsset = AssetDatabase.LoadAssetAtPath<Texture2D>($"{TexturesFolder}/T_FNAF_ArcadeCarpet.png");
        Texture2D ductAsset = AssetDatabase.LoadAssetAtPath<Texture2D>($"{TexturesFolder}/T_FNAF_MetalDuct.png");

        // 2. Tạo hoặc tải các Material URP Lit
        Material floorMat = CreateOrUpdateMaterial($"{MaterialsFolder}/M_FNAF_Floor_Checkered.mat", floorAsset, new Vector2(1f, 1f), 0.35f, 0.05f);
        Material wallMat = CreateOrUpdateMaterial($"{MaterialsFolder}/M_FNAF_Wall.mat", wallAsset, new Vector2(0.5f, 1f), 0.15f, 0f);
        Material doorMat = CreateOrUpdateMaterial($"{MaterialsFolder}/M_FNAF_Door.mat", doorAsset, new Vector2(1f, 1f), 0.35f, 0.7f);
        Material carpetMat = CreateOrUpdateMaterial($"{MaterialsFolder}/M_FNAF_ArcadeCarpet.mat", carpetAsset, new Vector2(4f, 4f), 0.05f, 0f);
        Material ductMat = CreateOrUpdateMaterial($"{MaterialsFolder}/M_FNAF_MetalDuct.mat", ductAsset, new Vector2(2f, 2f), 0.5f, 0.85f);

        AssetDatabase.SaveAssets();

        // 3. Ốp thẳng Material lên các MeshRenderer và ProBuilderMesh trong scene
        MeshRenderer[] renderers = Object.FindObjectsByType<MeshRenderer>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        int appliedCount = 0;

        foreach (var mr in renderers)
        {
            string name = mr.gameObject.name.ToLower();
            string path = GetHierarchyPath(mr.transform).ToLower();
            Material targetMat = null;

            // 1. Sàn (Floor / Ground)
            if (name.Contains("ground") || name.Contains("nen"))
            {
                if (!path.Contains("outside") && !path.Contains("road"))
                {
                    targetMat = floorMat;
                }
            }
            // 2. Tường (Wall / Forward)
            else if (name.Contains("wall") || name.Contains("forward") || name.Contains("tuong"))
            {
                if (!path.Contains("room/behind") && !path.Contains("wall planner") && !path.Contains("outside"))
                {
                    targetMat = wallMat;
                }
            }
            // 3. Cửa sắt (Door)
            else if (name.Contains("door") || path.Contains("door"))
            {
                if (!name.Contains("button") && !name.Contains("cube") && !name.Contains("khung") && !name.Contains("lamp"))
                {
                    targetMat = doorMat;
                }
            }
            // 4. Sân khấu Freddy (Stage)
            else if (name.Contains("stage"))
            {
                targetMat = carpetMat;
            }

            if (targetMat != null)
            {
                ApplyMaterialToTarget(mr, targetMat);
                appliedCount++;
            }
        }

        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene());

        File.WriteAllText(DoneMarker, "applied");
        AssetDatabase.Refresh();

        Debug.Log($"<color=#00FF7F><b>[LastShift]</b></color> Đã ốp thành công Material FNAF cho {appliedCount} mảng tường/sàn/cửa/sân khấu trong Scene Game!");
    }

    private static void ApplyMaterialToTarget(MeshRenderer mr, Material mat)
    {
        Undo.RecordObject(mr, "Apply FNAF Material");
        mr.sharedMaterial = mat;

        ProBuilderMesh pb = mr.GetComponent<ProBuilderMesh>();
        if (pb != null)
        {
            Undo.RecordObject(pb, "Apply FNAF Material to ProBuilder");
            pb.SetMaterial(pb.faces, mat);
            pb.ToMesh();
            pb.Refresh();
        }
    }

    private static Material CreateOrUpdateMaterial(string path, Texture2D texture, Vector2 tiling, float smoothness, float metallic)
    {
        Material mat = AssetDatabase.LoadAssetAtPath<Material>(path);
        if (mat == null)
        {
            Shader litShader = Shader.Find("Universal Render Pipeline/Lit");
            if (litShader == null) litShader = Shader.Find("Standard");
            mat = new Material(litShader);
            AssetDatabase.CreateAsset(mat, path);
        }

        if (texture != null)
        {
            mat.SetTexture("_BaseMap", texture);
            mat.SetTextureScale("_BaseMap", tiling);
        }
        mat.SetFloat("_Smoothness", smoothness);
        mat.SetFloat("_Metallic", metallic);
        EditorUtility.SetDirty(mat);
        return mat;
    }

    private static string GetHierarchyPath(Transform t)
    {
        string p = t.name;
        while (t.parent != null)
        {
            t = t.parent;
            p = t.name + "/" + p;
        }
        return p;
    }
}
#endif
