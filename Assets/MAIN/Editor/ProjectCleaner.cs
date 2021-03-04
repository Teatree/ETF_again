using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Reflection;

using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProjectCleaner
{

    [MenuItem("Component/Remove Missing Scripts From Project")]
    public static void RemoveMissingScriptsFromProject()
    {
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();

        if (!CleanPrefabAssets() || !CleanScenes())
        {
            Debug.Log("Canceled by user.");
            EditorUtility.ClearProgressBar();
            return;
        }

        AssetDatabase.SaveAssets();
        EditorUtility.ClearProgressBar();
    }

    private static GameObject[] FindPrefabsInProject(
        Action<float> progressCallback)
    {
        string[] assets =
            AssetDatabase.GetAllAssetPaths()
                .Where(
                    path =>
                        path.EndsWith(
                            ".prefab",
                            StringComparison.OrdinalIgnoreCase))
                .ToArray();

        GameObject[] prefabs = new GameObject[assets.Length];

        for (int i = 0; i < assets.Length; i++)
        {
            prefabs[i] =
                AssetDatabase.LoadAssetAtPath(
                    assets[i],
                    typeof(GameObject)) as GameObject;

            if (progressCallback != null)
                progressCallback((float)i / (float)assets.Length);
        }

        return prefabs
                .Where(p => p != null)
                .ToArray();
    }

    private static bool CleanPrefabAssets()
    {
        GameObject[] prefabs =
            FindPrefabsInProject(
                (float progress) => {
                    EditorUtility.DisplayProgressBar(
                                "Hold On",
                                "Finding prefabs in project",
                                progress);
                });

        int count = prefabs.Length;
        int index = 0;

        DisableNestedPrefabs();
        AssetDatabase.StartAssetEditing();
        {
            foreach (GameObject prefab in prefabs)
            {
                try
                {
                    if (EditorUtility.DisplayCancelableProgressBar(
                        "Removing components with a missing script",
                        AssetDatabase.GetAssetPath(prefab),
                        (float)(index++) / (float)count))
                    {
                        return false;
                    }

                    GameObject instance =
                        PrefabUtility.InstantiatePrefab(prefab) as GameObject;

                    CleanObjectRecursive(instance);

                    PrefabUtility.ReplacePrefab(instance, prefab);
                    GameObject.DestroyImmediate(instance);
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                }
            }
        }
        AssetDatabase.StopAssetEditing();
        AssetDatabase.SaveAssets();
        EnableNestedPrefabs();

        return true;
    }

    private static bool CleanScenes()
    {
        string[] sceneList =
            AssetDatabase.GetAllAssetPaths()
                .Where(
                    path =>
                        path.EndsWith(
                            ".unity",
                            StringComparison.OrdinalIgnoreCase))
                .ToArray();

        Scene activeScene = EditorSceneManager.GetActiveScene();

        int count = sceneList.Length;
        int index = 0;

        for (int i = 0; i < sceneList.Length; i++)
        {
            try
            {
                if (EditorUtility.DisplayCancelableProgressBar(
                        "Removing components with a missing script",
                        sceneList[i],
                        (float)(index++) / (float)count))
                {
                    return false;
                }

                Scene scene = EditorSceneManager.GetSceneByPath(sceneList[i]);

                if (!scene.isLoaded)
                    scene =
                        EditorSceneManager.OpenScene(
                            sceneList[i],
                            OpenSceneMode.Additive);

                CleanScene(scene);

                EditorSceneManager.SaveScene(scene);

                if (scene != activeScene)
                    EditorSceneManager.CloseScene(scene, true);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        return true;
    }

    private static void CleanScene(Scene scene)
    {
        GameObject[] rootGameObjects = scene.GetRootGameObjects();
        foreach (GameObject gameObject in rootGameObjects)
        {
            CleanObjectRecursive(gameObject);
        }
    }

    private static void CleanObjectRecursive(GameObject gameObject)
    {
        if (gameObject.transform.parent != null)
        {
            Debug.LogWarning("GameObject is not a root object");
            return;
        }

        Transform[] hierarchy = gameObject.GetComponentsInChildren<Transform>(true);
        foreach (Transform child in hierarchy)
        {
            var serializedChild = new SerializedObject(child.gameObject);
            var serializedComponentList = serializedChild.FindProperty("m_Component");
            var components = child.GetComponents<Component>();

            for (int i = components.Length - 1; i > -1; i--)
            {
                if (components[i] != null)
                    continue;

                serializedComponentList.DeleteArrayElementAtIndex(i);
            }

            serializedChild.ApplyModifiedPropertiesWithoutUndo();
        }
    }

    private static void DisableNestedPrefabs()
    {
        var postprocessor =
            FindType("VisualDesignCafe.Editor.Prefabs.NestedPrefabsPostprocessor");

        if (postprocessor == null)
            return;

        postprocessor
            .GetProperty(
                "IsEnabled",
                BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
            .SetValue(null, false, null);
    }

    private static void EnableNestedPrefabs()
    {
        var postprocessor =
            FindType("VisualDesignCafe.Editor.Prefabs.NestedPrefabsPostprocessor");

        if (postprocessor == null)
            return;

        postprocessor
            .GetProperty(
                "IsEnabled",
                BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
            .SetValue(null, true, null);
    }

    private static Type FindType(string typeName)
    {
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            foreach (var type in assembly.GetTypes())
            {
                if (type.FullName == typeName)
                    return type;
            }
        }

        return null;
    }
}