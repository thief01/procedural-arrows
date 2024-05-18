#if UNITY_EDITOR

using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace WRA.Procedural.Arrow.Editor
{
    public class ProceduralObjects : MonoBehaviour
    {
        [MenuItem("GameObject/thief01-SDK/Procedural Line")]
        public static void CreateProceduralLine()
        {
            GameObject g = new GameObject("Procedural line");
            g.AddComponent<ProceduralLine>();

            Selection.activeGameObject = g;
            Undo.RegisterCreatedObjectUndo(g, "Create procedural line");
            EditorSceneManager.MarkAllScenesDirty();
        }
    
        [MenuItem("GameObject/thief01-SDK/Simple Procedural Arrow")]
        public static void CreateSimpleProceduralArrow()
        {
            GameObject g = new GameObject("Simple Procedural Arrow");
            g.AddComponent<SimpleProceduralArrow>();

            Selection.activeGameObject = g;
            Undo.RegisterCreatedObjectUndo(g, "Create Simple Procedural Arrow");
            EditorSceneManager.MarkAllScenesDirty();
        }
    }
}
#endif