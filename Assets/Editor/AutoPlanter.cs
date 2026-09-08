using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class AutoPlanter
{
    [MenuItem("Tools/Trồng Cây Tự Động")]
    public static void PlantTrees()
    {
        // Tìm tất cả các model cây có chữ "tree" trong tên ở thư mục Import
        string[] guids = AssetDatabase.FindAssets("tree t:Model", new[] { "Assets/Import" });
        List<GameObject> treePrefabs = new List<GameObject>();
        
        foreach (var g in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(g);
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            if (prefab != null) treePrefabs.Add(prefab);
        }

        if (treePrefabs.Count == 0)
        {
            EditorUtility.DisplayDialog("Lỗi", "Không tìm thấy file cây nào (có tên chứa chữ 'tree') trong thư mục Import!", "OK");
            return;
        }

        // Tìm 2 khu đất dựa theo đúng tên bạn đặt trong Hierarchy
        GameObject ground1 = GameObject.Find("Ground outside");
        GameObject ground2 = GameObject.Find("Ground outside (2)");

        if (ground1 == null && ground2 == null)
        {
            EditorUtility.DisplayDialog("Lỗi", "Không tìm thấy 'Ground outside' hay 'Ground outside (2)'", "OK");
            return;
        }

        // Tạo một GameObject rỗng để chứa tất cả cây (giữ Hierarchy gọn gàng)
        GameObject treeContainer = GameObject.Find("KhuVucCayCoi");
        if (treeContainer == null) treeContainer = new GameObject("KhuVucCayCoi");

        // Bắt đầu trồng cây (Mỗi bên rải 40 cây)
        int totalPlanted = 0;
        if (ground1 != null) totalPlanted += PlantOnGround(ground1, treePrefabs, treeContainer.transform, 40);
        if (ground2 != null) totalPlanted += PlantOnGround(ground2, treePrefabs, treeContainer.transform, 40);

        EditorUtility.DisplayDialog("Thành công!", $"Đã trồng {totalPlanted} cây ngẫu nhiên 2 bên đường!\n(Đã xoay và scale ngẫu nhiên, được gom gọn trong KhuVucCayCoi).", "Tuyệt");
    }

    static int PlantOnGround(GameObject ground, List<GameObject> prefabs, Transform parent, int count)
    {
        Renderer rend = ground.GetComponent<Renderer>();
        if (rend == null) return 0;

        Bounds bounds = rend.bounds;
        int planted = 0;

        for (int i = 0; i < count; i++)
        {
            // Lấy ngẫu nhiên 1 loại cây
            GameObject randomTree = prefabs[Random.Range(0, prefabs.Count)];
            
            // Random vị trí lộn xộn trong giới hạn của mảnh đất
            float rx = Random.Range(bounds.min.x, bounds.max.x);
            float rz = Random.Range(bounds.min.z, bounds.max.z);
            Vector3 pos = new Vector3(rx, bounds.max.y, rz);

            // Sinh ra cây
            GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(randomTree);
            instance.transform.position = pos;
            instance.transform.parent = parent;

            // Random góc xoay Y và Random kích thước
            instance.transform.rotation = Quaternion.Euler(0, Random.Range(0f, 360f), 0);
            float s = Random.Range(0.7f, 1.4f);
            instance.transform.localScale = new Vector3(s, s, s);

            planted++;
        }
        return planted;
    }
}
