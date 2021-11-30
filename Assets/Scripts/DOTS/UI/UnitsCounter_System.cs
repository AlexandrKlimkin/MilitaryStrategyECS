using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class UnitsCounter_System : SystemBase
{
    protected override void OnCreate()
    {
        
    }

    protected override void OnUpdate()
    {
        var count = 0;
        Entities.ForEach((Entity e, ref PathFinding_Component uc) =>
        {
            count++;
        }).Run();
        
        Entities.ForEach((UnitsCounter_Component uintsCounter) =>
        {
            uintsCounter.Text.text = $"UNITS COUNT: {count}";
        }).WithoutBurst().Run();
    }
    
    
}
