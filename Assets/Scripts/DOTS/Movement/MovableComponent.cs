using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityEngine.AI;

[GenerateAuthoringComponent]
public struct MovableComponent : IComponentData
{
    public float MoveSpeed;
    public bool CanMove;
    public Vector3? TargetPoint;
}
