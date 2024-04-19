using Unity.Entities;
using UnityEngine;

namespace Game.Scripts.ECS.Components
{
    public struct RotateSquare : IComponentData
    {
        public float rotateSpeed;
    }


    public class RotateSquareAuthoring : MonoBehaviour
    {
        public float rotateSpeed;
        private class RotateSquareAuthoringBaker : Baker<RotateSquareAuthoring>
        {
            public override void Bake(RotateSquareAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new RotateSquare
                {
                    rotateSpeed = authoring.rotateSpeed
                });
            }
        }
    }
}