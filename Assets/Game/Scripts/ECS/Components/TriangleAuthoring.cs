using Unity.Entities;
using UnityEngine;

namespace Game.Scripts.ECS.Components
{
    public struct Triangle : IComponentData { }
    
    public class TriangleAuthoring : MonoBehaviour
    {
        private class TriangleAuthoringBaker : Baker<TriangleAuthoring>
        {
            public override void Bake(TriangleAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);
                AddComponent(entity, new Triangle());
            }
        }
    }
}