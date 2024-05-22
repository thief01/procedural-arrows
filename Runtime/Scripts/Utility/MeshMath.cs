using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using UnityEngine;

namespace WRA.Utility
{
    [BurstCompile(CompileSynchronously = true)]
    public static class MeshMath
    {
        public static Vector3[] GetTriangleVertices(float baseSize, float lenght, float rotation, float offsetX = 0.5f,
            float offsetY = 0.5f)
        {
            float reverseOffsetX = 1 - offsetX;
            float reverseOffsetY = 1 - offsetY;
            float midOffsetX = offsetX - 0.5f;

            return RotateVertices( new[]
            {
                new Vector3(-lenght * offsetX, -baseSize * offsetY, 0), // left bottom
                new Vector3(lenght * reverseOffsetX, -baseSize * offsetY, 0), // right bottom
                new Vector3(-lenght * midOffsetX, baseSize * reverseOffsetY, 0) // top
            }, rotation );
        }
        
        public static Vector3[] RotateVertices(Vector3[] vertices, float rotation)
        {
            var rotationMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 0, rotation));
            for (int i = 0; i < vertices.Length; i++)
            {
                vertices[i] = rotationMatrix.MultiplyPoint3x4(vertices[i]);
            }

            return vertices;
        }
    }
}