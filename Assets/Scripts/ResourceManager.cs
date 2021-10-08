using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public GameObject resourcePrefabs;
    public int count = 5;

    [Header("Respawn Radius")]
    public Transform xPoint;
    public Transform yPoint;
    public float offset = 0f;

    private float _xRadius;
    private float _yRadius;

    private void Awake()
    {
        _xRadius = xPoint.position.x;
        _yRadius = yPoint.position.y;
    }

    private void Start()
    {
        for(int i = 0; i < count; i++)
            SpawnResource(_xRadius, _yRadius);
    }

    private void SpawnResource(float x, float y)
    {
        Instantiate(resourcePrefabs, RandomRadiusPosition(x, y), Quaternion.identity);
    }

    private Vector2 RandomRadiusPosition(float x, float y)
    {
        return new Vector2(Random.Range(-x - offset, x + offset), Random.Range(-y - offset, y + offset));
    }
}
