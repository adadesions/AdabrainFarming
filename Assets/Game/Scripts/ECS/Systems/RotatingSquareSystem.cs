using Game.Scripts.ECS.Components;
using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

namespace Game.Scripts.ECS.Systems
{
    public partial struct RotatingSquareSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<RotateSquare>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            // foreach (var (localTransform, rotateSquare) 
            //          in SystemAPI.Query<RefRW<LocalTransform>, RefRO<RotateSquare>>() )
            // {
            //     
            // }

            var rotatingSquareJobs = new RotatingSquareJobs
            {
                deltaTime = SystemAPI.Time.DeltaTime
            };

            rotatingSquareJobs.Schedule();
        }

        [BurstCompile]
        [WithNone(typeof(Triangle))]
        public partial struct RotatingSquareJobs : IJobEntity
        {
            public float deltaTime;

            private void Execute(ref LocalTransform localTransform, in RotateSquare rotateSquare)
            {
                localTransform = localTransform.RotateZ(rotateSquare.rotateSpeed * deltaTime);
            }
        }
    }
}