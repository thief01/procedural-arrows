using UnityEngine;

namespace WRA.Procedural.Arrow
{
    public class ProceduralLine : ProceduralObject
    {
        [SerializeField] protected float lineWidth = 0.1f;
        private float lastLineWidth = 0;
    
        protected override bool ShouldUpdate()
        {
            if (base.ShouldUpdate())
            {
                return true;
            }
            if (lastLineWidth == lineWidth)
            {
                return false;
            }
            lastLineWidth = lineWidth;
            GenerateObject();
            return true;
        }
    
        protected override void GenerateObject()
        {
            meshFilter.mesh = MeshFactory.GenereteLine(lenght, lineWidth);
        }
    }
}
