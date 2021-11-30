using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager instance { get; private set; }
    
    public int maxPathSize;
    public int maxEntitiesRoutedPerFrame;
    public int maxPathNodePoolSize;
    public int maxIterations;
    public bool useCache;
    // public float spawnEvery;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
