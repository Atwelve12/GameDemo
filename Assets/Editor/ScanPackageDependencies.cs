using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public class ScanPackageDependencies
{
    [MenuItem("Tools/Scan Package Dependencies")]
    static void ScanSelectedFolder()
    {
        Object selected = Selection.activeObject;
        string rootPath = AssetDatabase.GetAssetPath(selected);

        if (!AssetDatabase.IsValidFolder(rootPath))
        {
            Debug.LogError("Please select a folder!");
            return;
        }

        List<string> allAssetPaths = new List<string>();
        string[] allGuids = AssetDatabase.FindAssets("", new string[] { rootPath });

        foreach (string guid in allGuids)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(guid);
            allAssetPaths.Add(assetPath);
        }

        int hitCount = 0;
        foreach (string assetPath in allAssetPaths)
        {
            string[] dependencies = AssetDatabase.GetDependencies(assetPath, false);
            foreach (string dep in dependencies)
            {
                if (dep.StartsWith("Packages/"))
                {
                    Debug.Log($"Found asset: {assetPath}\nDependency: {dep}");
                    hitCount++;
                    break;
                }
            }
        }
        Debug.Log($"Scan finished, hit {hitCount} files with package dependencies.");
    }
}
