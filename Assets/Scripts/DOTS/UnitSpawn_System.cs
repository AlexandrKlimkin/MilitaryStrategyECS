using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine.UIElements;

public class UnitSpawn_System : SystemBase
{
    private BeginInitializationEntityCommandBufferSystem ei_ECB;
    public float elapsedTime;
    
    protected override void OnCreate()
    {
        ei_ECB = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();
        
        //CreateSquad();
    }

    protected override void OnStartRunning()
    {
        CreateSquad();
    }

    protected override void OnUpdate()
    {
        //CreateSquad();
    }

    private void CreateSquad()
    {
        var ecb = ei_ECB.CreateCommandBuffer().AsParallelWriter();
        
        Entities
            .WithBurst(synchronousCompilation: true)
            .ForEach((Entity e, int entityInQueryIndex, in UnitSpawn_Component uic, in LocalToWorld ltw) =>
            {
                for (int i = 0; i < uic.XGridCount; i++)
                {
                    for (int j = 0; j < uic.ZGridCount; j++)
                    {
                        Entity defEntity = ecb.Instantiate(entityInQueryIndex, uic.PrefabToSpawn);
                        float3 position = new float3(i * uic.XPadding, uic.BaseOffset, j * uic.ZPadding) + uic.currentPosition;
                        ecb.SetComponent(entityInQueryIndex, defEntity, new Translation {Value = position});
                        ecb.AddComponent<PathFinding_Component>(entityInQueryIndex, defEntity);
                        ecb.AddBuffer<Unit_Buffer>(entityInQueryIndex, defEntity);
        
                        var uc = new PathFinding_Component();
                        uc.fromLocation = position;
                        uc.toLocation = new float3(position.x, position.y,
                            position.z + uic.destinationDistanceZAxis);
                        uc.currentBufferIndex = 0;
                        uc.speed = (float) new Random(uic.seed + (uint)(i * j)).NextDouble(uic.minSpeed, uic.maxSpeed);
                        uc.minDistanceReached = uic.minDistanceReached;
                        ecb.SetComponent(entityInQueryIndex, defEntity, uc);
                    }
                }
                //ecb.DestroyEntity(entityInQueryIndex, e);
            }).Schedule();
        ei_ECB.AddJobHandleForProducer(Dependency);
    }
}