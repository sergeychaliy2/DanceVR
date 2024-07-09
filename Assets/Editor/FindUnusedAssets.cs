using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public class FindUnusedAssets : EditorWindow
{
    [MenuItem("Window/Find Unused Assets")]
    public static void ShowWindow()
    {
        GetWindow<FindUnusedAssets>("Find Unused Assets");
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Find Unused Assets"))
        {
            FindUnused();
        }
    }

    private static void FindUnused()
    {
        string[] allAssets = AssetDatabase.GetAllAssetPaths();
        List<string> usedAssets = new List<string>();
        string[] scenePaths = AssetDatabase.FindAssets("t:Scene");
        foreach (string guid in scenePaths)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            string[] dependencies = AssetDatabase.GetDependencies(path, true);
            foreach (string dependency in dependencies)
            {
                if (!usedAssets.Contains(dependency))
                {
                    usedAssets.Add(dependency);
                }
            }
        }
        foreach (string asset in allAssets)
        {
            if (asset.EndsWith(".cs") && !usedAssets.Contains(asset) && !asset.StartsWith("Assets/Editor"))
            {
                Debug.Log("Unused Script: " + asset);
            }
        }
    }
}
