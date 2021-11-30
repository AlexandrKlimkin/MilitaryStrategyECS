using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

public class MovementSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;
        
        Entities.ForEach((ref Translation translation, in MovableComponent moveComp) =>
        {
            translation.Value += new float3(moveComp.MoveSpeed, 0, 0) * deltaTime;
        }).Schedule();
    }
}
