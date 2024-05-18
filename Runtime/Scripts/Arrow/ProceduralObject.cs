using UnityEngine;

namespace WRA.Procedural.Arrow
{
    [RequireComponent(typeof(MeshFilter) , typeof(MeshRenderer)), ExecuteInEditMode]
    public abstract class ProceduralObject : MonoBehaviour
    {
        [SerializeField] protected float lenght = 5;
        protected MeshFilter meshFilter;
        protected MeshRenderer meshRenderer;

        private float lastLenght = 0;

        private void Awake()
        {
            meshFilter = GetComponent<MeshFilter>();
            meshRenderer = GetComponent<MeshRenderer>();
            GenerateObject();
        }

        private void Update()
        {
            ShouldUpdate();
        }
    
        protected virtual bool ShouldUpdate()
        {
            if (lastLenght == lenght)
            {
                return false;
            }
            lastLenght = lenght;
            GenerateObject();
            return true;
        }

        public void SetLenght(float lenght)
        {
            this.lenght = lenght;
            GenerateObject();
        }

        protected abstract void GenerateObject();
    }
}
