using Unity.Burst;
using UnityEngine;

namespace WRA.Procedural
{
    [BurstCompile(CompileSynchronously = true)]
    public static class MeshFactory
    {
        public static Mesh GenereteLine(float lenght, float height, float offsetX = 0)
        {
            Mesh mesh = new Mesh();
        
            Vector3[] vertices = new Vector3[4];
            Vector2[] uv = new Vector2[4];
            int[] triangles = new int[6];
        
            vertices[0] = new Vector3(-offsetX, -height / 2, 0); // left bottom
            vertices[1] = new Vector3(-offsetX + lenght, -height / 2, 0); // right bottom
            vertices[2] = new Vector3(-offsetX, height / 2, 0); // left top
            vertices[3] = new Vector3(-offsetX + lenght, height / 2, 0); // right top
        
            uv[0] = new Vector2(0, 0);
            uv[1] = new Vector2(lenght, 0);
            uv[2] = new Vector2(0, height);
            uv[3] = new Vector2(lenght, height);
        
            triangles[0] = 0;
            triangles[1] = 2;
            triangles[2] = 1;
        
            triangles[3] = 2;
            triangles[4] = 3;
            triangles[5] = 1;
        
            mesh.vertices = vertices;
            mesh.uv = uv;
            mesh.triangles = triangles;
            mesh.name = "ProceduralLine";
        
            return mesh;
        }

        public static Mesh GenerateTriangle(Vector3[] veritcies)
        {
            Mesh mesh = new Mesh();
        
            Vector2[] uv = new Vector2[3];
            int[] triangles = new int[3];
        
            uv[0] = new Vector2(0, 0);
            uv[1] = new Vector2(1, 0);
            uv[2] = new Vector2(0, 1);
        
            triangles[0] = 0;
            triangles[1] = 2;
            triangles[2] = 1;
        
            mesh.vertices = veritcies;
            mesh.uv = uv;
            mesh.triangles = triangles;
            mesh.name = "ProceduralTriangle";
        
            return mesh;
        }
        
        public static Mesh GenerateArrow(float lineLenght, float lineHeight, float arrrowHeadLenght, float arrowHeadHeight, float offsetX= 0.5f)
        {
            offsetX = Mathf.Clamp(offsetX, 0, 1);
            var offsetValue = (lineLenght + arrrowHeadLenght) * offsetX;
            
            var line = GenereteLine(lineLenght, lineHeight, offsetValue);
            var triangleVerticies = GetTriangleVertices(arrowHeadHeight, arrrowHeadLenght, 0);
            for (int i = 0; i < triangleVerticies.Length; i++)
            {
                triangleVerticies[i] += new Vector3(lineLenght - offsetValue, 0, 0);
            }
            var triangle = GenerateTriangle(triangleVerticies);
            
            var mesh = new Mesh();
            mesh = MeshCombine(line, triangle);
            mesh.name = "ProceduralArrow";
            return mesh;
        }
    
        public static Mesh MeshCombine(params Mesh[] meshes)
        {
            CombineInstance[] combine = new CombineInstance[meshes.Length];
            for (int i = 0; i < meshes.Length; i++)
            {
                combine[i].mesh = meshes[i];
                combine[i].transform = Matrix4x4.identity;
            }
        
            Mesh mesh = new Mesh();
            mesh.CombineMeshes(combine);
            return mesh;
        }
        
        /// <summary>
        /// If offset equals to 0 then triangle will be at the beginning of the line
        /// If offset equals to 0.5 then triangle will be in the middle of the line
        /// If offset equals to 1 then triangle will be at the end of the line
        /// </summary>
        /// <param name="baseSize"></param>
        /// <param name="lenght"></param>
        /// <param name="offsetX"></param>
        /// <returns></returns>
        public static Vector3[] GetTriangleVertices(float baseSize, float lenght, float offsetX = 0)
        {
            offsetX = Mathf.Clamp(offsetX, 0, 1);
            float offsetValue= lenght * offsetX;
            
            return new[]
            {
                new Vector3(-offsetValue, -baseSize / 2, 0),
                new Vector3( lenght - offsetValue, 0, 0),
                new Vector3(-offsetValue, baseSize / 2, 0)
            };
        }
    }
}
