using UnityEngine;
using UnityEditor;

public class PoseBaker
{
    [MenuItem("Tools/2. Tao File Anim Tu Pose Hien Tai (Khong Bi Lech)")]
    public static void BakePoseToAnim()
    {
        GameObject selected = Selection.activeGameObject;
        if (selected == null)
        {
            Debug.LogWarning("Vui long chon nhan vat!");
            return;
        }

        // Tu dong tim dung thang chua Animator de lam goc toa do
        Animator anim = selected.GetComponent<Animator>();
        if (anim == null) anim = selected.GetComponentInChildren<Animator>();
        
        if (anim == null)
        {
            Debug.LogWarning("Vat the nay khong co Animator!");
            return;
        }

        GameObject rootObject = anim.gameObject;
        string defaultName = "Pose_Tinh_" + rootObject.name;
        AnimationClip clip = new AnimationClip();
        clip.name = defaultName;
        
        Transform[] allTransforms = rootObject.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in allTransforms)
        {
            if (t == rootObject.transform) continue; 

            string path = AnimationUtility.CalculateTransformPath(t, rootObject.transform);

            AnimationCurve curveX = new AnimationCurve(new Keyframe(0f, t.localRotation.x));
            AnimationCurve curveY = new AnimationCurve(new Keyframe(0f, t.localRotation.y));
            AnimationCurve curveZ = new AnimationCurve(new Keyframe(0f, t.localRotation.z));
            AnimationCurve curveW = new AnimationCurve(new Keyframe(0f, t.localRotation.w));

            clip.SetCurve(path, typeof(Transform), "localRotation.x", curveX);
            clip.SetCurve(path, typeof(Transform), "localRotation.y", curveY);
            clip.SetCurve(path, typeof(Transform), "localRotation.z", curveZ);
            clip.SetCurve(path, typeof(Transform), "localRotation.w", curveW);
        }

        if (!AssetDatabase.IsValidFolder("Assets/Animation"))
        {
            AssetDatabase.CreateFolder("Assets", "Animation");
        }

        string assetPath = AssetDatabase.GenerateUniqueAssetPath("Assets/Animation/" + defaultName + ".anim");
        AssetDatabase.CreateAsset(clip, assetPath);
        AssetDatabase.SaveAssets();

        Debug.Log($"[Thanh Cong] Da tao Pose tu goc: {rootObject.name}. Luu tai: {assetPath}");
        EditorGUIUtility.PingObject(clip);
    }
}
