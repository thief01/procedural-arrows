#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace WRA.Procedural.Arrow.Editor
{
    [CustomEditor(typeof(ProceduralObject), true)]
    public class ProceduralObjectEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            if (GUILayout.Button("Export UV"))
            {
                var proceduralObject = target as ProceduralObject;
                var mesh = proceduralObject.GetComponent<MeshFilter>().sharedMesh;
                var uvs = mesh.uv;
            
                float minU = float.MaxValue;
                float maxU = float.MinValue;
                float minV = float.MaxValue;
                float maxV = float.MinValue;

                for (int i = 0; i < uvs.Length; i++)
                {
                    Vector2 uv = uvs[i];
                    minU = Mathf.Min(minU, uv.x);
                    maxU = Mathf.Max(maxU, uv.x);
                    minV = Mathf.Min(minV, uv.y);
                    maxV = Mathf.Max(maxV, uv.y);
                }

            
                Texture2D texture = new Texture2D((int)(maxU-minU), (int)(maxV-minV), TextureFormat.RGBA32, false);

                // Iterate over the UV coordinates and map them to the texture
                for (int i = 0; i < uvs.Length; i++)
                {
                    Vector2 uv = uvs[i];
                    texture.SetPixel((int)uv.x, (int)uv.y, Color.red);
                }

                // Apply changes
                texture.Apply();

                // Encode texture into PNG
                byte[] bytes = texture.EncodeToPNG();

                // Write to a file
                string path = EditorUtility.SaveFilePanel("Save UV Texture", "", "UVTexture", "png");
                if (path.Length != 0)
                {
                    System.IO.File.WriteAllBytes(path, bytes);
                }
            }
            base.OnInspectorGUI();
        }
    }
}

#endif
