﻿using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public static class EditorBridge
{
    public static void SetDirty(Object obj)
    {
#if UNITY_EDITOR
        EditorUtility.SetDirty(obj);
#endif
    }

    public static void SaveAssets()
    {
#if UNITY_EDITOR
        AssetDatabase.SaveAssets();
#endif
    }
        
    public static string GetAssetPath(Object asset)
    {
#if UNITY_EDITOR
        return AssetDatabase.GetAssetPath(asset);
#endif

        return null;
    }
        
    public static string GetMainAssetNameIfExist(Object asset)
    {
#if UNITY_EDITOR
        if (AssetDatabase.IsSubAsset(asset))
        {
            return AssetDatabase.LoadMainAssetAtPath(AssetDatabase.GetAssetPath(asset)).name;
        }
#endif

        return asset.name;
    }
        
    public static bool IsAsset(Object asset)
    {
#if UNITY_EDITOR
        return AssetDatabase.Contains(asset);
#endif

        return false;
    }
        
    public static GameObject GetPrefabParent(Object asset)
    {
#if UNITY_EDITOR
        return (GameObject) PrefabUtility.GetCorrespondingObjectFromSource(asset);
#endif

        return null;
    }
        
    public static void DeleteAsset(Object asset)
    {
#if UNITY_EDITOR
        AssetDatabase.DeleteAsset(AssetDatabase.GetAssetPath(asset));
#endif
        return;
    }
}