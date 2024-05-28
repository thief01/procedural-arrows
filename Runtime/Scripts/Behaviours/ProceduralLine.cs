using System.Collections.Generic;
using UnityEngine;

namespace WRA.Procedural.Arrow
{
    public class ProceduralLine : ProceduralObject
    {
        [SerializeField] protected float lenght = 1;
        [SerializeField] protected float lineWidth = 0.1f;
        
        protected override void GenerateObject()
        {
            meshFilter.mesh = ArrowFactory.GenereteLine(lenght, lineWidth);
        }
    }
}
