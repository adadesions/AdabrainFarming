using Unity.Entities;
using UnityEngine;

namespace Game.Scripts.ECS.Components
{
    public struct Square : IComponentData { }
    
    public class SquareAuthoring : MonoBehaviour
    {
        private class SquareAuthoringBaker : Baker<SquareAuthoring>
        {
            public override void Bake(SquareAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);
                AddComponent(entity, new Square());
            }
        }
    }
}