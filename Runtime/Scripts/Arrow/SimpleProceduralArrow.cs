using UnityEngine;
using WRA.Utility;

namespace WRA.Procedural.Arrow
{
    public class SimpleProceduralArrow : ProceduralLine
    {
        [SerializeField] private float arrrowHeadLenght = 0.1f;
        [SerializeField] private float arrrowHeadWidth = 0.1f;
        [Range(0,1)]
        [SerializeField] private float arrowOffset = 0.5f;
    
        private float lastArrrowHeadLenght = 0;
        private float lastArrrowHeadWidth = 0;
        private float lastArrowOffset = 0;
    
        protected override bool ShouldUpdate()
        {
            if (base.ShouldUpdate())
                return true;
            if (lastArrrowHeadLenght == arrrowHeadLenght && lastArrrowHeadWidth == arrrowHeadWidth && lastArrowOffset == arrowOffset)
                return false;
            lastArrrowHeadLenght = arrrowHeadLenght;
            lastArrrowHeadWidth = arrrowHeadWidth;
            lastArrowOffset = arrowOffset;
            GenerateObject();
            return true;
        }
    
        protected override void GenerateObject()
        {
            // meshFilter.mesh = GenereteArrow();
            meshFilter.mesh = ArrowFactory.GenerateArrow(lenght, lineWidth, arrrowHeadLenght, arrrowHeadWidth, arrowOffset);
        }
    
        protected Mesh GenereteArrow()
        {
            var line = ArrowFactory.GenereteLine(lenght, lineWidth);
            var triangle = SimpleFactory.CreateTriangle(new Vector3[]
            {
                new Vector3(lenght, -arrrowHeadWidth / 2, 0),
                new Vector3(lenght + arrrowHeadLenght, 0, 0),
                new Vector3(lenght, arrrowHeadWidth / 2, 0)
            });
            var mesh = new Mesh();
            mesh = MeshCombine.Combine(line, triangle);
            mesh.name = "ProceduralArrow";
            return mesh;
        }
    }
}
