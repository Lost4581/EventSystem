#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public static class CreateScriptableObjects
{
    [MenuItem("Assets/Create/Game Events/Resource Event")]
    public static void CreateResourceEvent()
    {
        CreateAsset<ResourceEvent>("OnResourceChangedEvent");
    }

    [MenuItem("Assets/Create/Game Events/UI State Event")]
    public static void CreateUIStateEvent()
    {
        CreateAsset<UIStateEvent>("OnUIStateChangedEvent");
    }

    [MenuItem("Assets/Create/Game Events/Reset Event")]
    public static void CreateResetEvent()
    {
        CreateAsset<ResetEvent>("OnResetEvent");
    }

    private static void CreateAsset<T>(string defaultName) where T : ScriptableObject
    {
        T asset = ScriptableObject.CreateInstance<T>();

        string path = AssetDatabase.GetAssetPath(Selection.activeObject);
        if (path == "")
        {
            path = "Assets";
        }
        else if (System.IO.Path.GetExtension(path) != "")
        {
            path = path.Replace(System.IO.Path.GetFileName(path), "");
        }

        string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + "/" + defaultName + ".asset");
        AssetDatabase.CreateAsset(asset, assetPathAndName);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;
    }
}
#endif