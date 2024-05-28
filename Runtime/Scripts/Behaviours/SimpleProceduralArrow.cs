using procedural_shape_generator.Runtime.Scripts.Procedural_Factories.Flat3D;
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
        
        protected override void GenerateObject()
        {
            // meshFilter.mesh = GenereteArrow();
            meshFilter.mesh = ArrowFactory.GenerateArrow(lenght, lineWidth, arrrowHeadLenght, arrrowHeadWidth, arrowOffset);
        }
    }
}
