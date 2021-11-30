using System;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

[GenerateAuthoringComponent]
public struct UnitSpawn_Component : IComponentData
{
    public int XGridCount;
    public int ZGridCount;
    public float BaseOffset;
    public float XPadding;
    public float ZPadding;
    public Entity PrefabToSpawn;

    public float destinationDistanceZAxis;
    public float minSpeed;
    public float maxSpeed;
    public uint seed;
    public float minDistanceReached;
    public float3 currentPosition;
}
