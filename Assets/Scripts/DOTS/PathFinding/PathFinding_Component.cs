using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine.Experimental.AI;

[GenerateAuthoringComponent]
public struct PathFinding_Component : IComponentData
{
    public float3 toLocation;
    public float3 fromLocation;
    public NavMeshLocation nml_FromLocation;
    public NavMeshLocation nml_ToLocation;
    public bool routed;
    public bool reached;
    public bool usingCachedPath;

    public float3 waypointDirection;
    public float speed;
    public float minDistanceReached;
    public int currentBufferIndex;
}
