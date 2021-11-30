using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquadsSpawner : MonoBehaviour
{
    public GameObject UnitPrefab;
    [Header("Size")]
    [Range(1, 100)]
    public int Width;
    [Range(1, 100)]
    public int Length;
    [Header("Padding")]
    [Range(1, 100)]
    public int widthPadding;
    [Range(1, 100)]
    public int lengthPadding;
    [Button]
    public bool _Spawn;

    public void OnSpawn()
    {
        SpawnSquad(UnitPrefab, Width, Length, widthPadding, lengthPadding);
    }

    public void SpawnSquad(GameObject prefab, int width, int length, float widthPadding, float lengthPadding)
    {
        if (prefab == null)
        {
            Debug.LogError("Unit prefab is null!");
            return;
        }
        var squadRoot = new GameObject($"{prefab.name}_Squad_{width}x{length}");
        squadRoot.transform.position = transform.position;
        squadRoot.transform.rotation = transform.rotation;

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < length; j++)
            {
                var pos = new Vector3(i * widthPadding, 0, j * lengthPadding);
                var unit = Instantiate(prefab, squadRoot.transform);
                unit.transform.localPosition = pos;
                unit.transform.localRotation = Quaternion.identity;
            }
        }
    }
}
