using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

// Utility to select (ping) the currently open scene asset in the Project window.
// Place this script in Assets/Editor/ so Unity compiles it as an Editor tool.
public static class SelectOpenScene
{
    [MenuItem("Tools/Select Open Scene In Project")] 
    private static void SelectScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (!scene.IsValid() || string.IsNullOrEmpty(scene.path))
        {
            Debug.LogWarning("No hay ninguna escena guardada abierta. Guarda la escena para poder seleccionarla en Project.");
            return;
        }

        // Load the asset at the scene path and select it
        Object asset = AssetDatabase.LoadMainAssetAtPath(scene.path);
        if (asset != null)
        {
            Selection.activeObject = asset;
            EditorGUIUtility.PingObject(asset);
            Debug.Log($"Seleccionada la escena en Project: {scene.path}");
        }
        else
        {
            Debug.LogWarning($"No se encontró el asset para la escena: {scene.path}");
        }
    }
}
