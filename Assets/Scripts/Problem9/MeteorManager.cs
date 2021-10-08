using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorManager : MonoBehaviour
{
    public GameObject[] meteors;

    public float randomFactor = 2f;

    [Range(3f, 10f)]
    public float maxSecondDelay = 5f;
    
    [Range(15f, 120f)]
    public float maxVelocity = 30f;

    [Header("Respawn Radius")]
    public Transform xPoint;
    public Transform yPoint;
    public float offset = 0f;

    private float _xRadius;
    private float _yRadius;
    private float _time;

    private void Awake()
    {
        _xRadius = xPoint.position.x;
        _yRadius = yPoint.position.y;
    }

    private void Start()
    {
        SpawnMeteor(_xRadius, _yRadius);
        _time = maxSecondDelay;
    }

    private void Update()
    {
        _time -= Time.deltaTime;
        if(_time <= 0f)
        {
            SpawnMeteor(_xRadius, _yRadius);
            _time = maxSecondDelay;
        }
    }

    private void SpawnMeteor(float x, float y)
    {
        Debug.Log("...Trying to respawn");
        Vector2 pos = RandomBoundaryPosition(x, y);

        Debug.Log("Respawned");
        GameObject obj = Instantiate(meteors[Random.Range(0, meteors.Length)], pos, Quaternion.identity);
        obj.GetComponent<Rigidbody2D>().AddForce(ForceRandomToScreen(obj));
    }

    private Vector2 RandomBoundaryPosition(float x, float y)
    {
        Vector2 pos = new Vector2(Random.Range(-x - offset, x + offset), Random.Range(-y - offset, y + offset));
        pos.Normalize();
        pos.x *= _xRadius;
        pos.y *= _yRadius;

        return pos;
    }

    private Vector2 ForceRandomToScreen(GameObject obj)
    {
        Vector2 Force = -obj.transform.position;
        Force.Normalize();
        Force.x += Random.Range(-randomFactor, randomFactor);
        Force.y += Random.Range(-randomFactor, randomFactor);
        Force *= Random.Range(15f, maxVelocity);
        return Force;
    }
}
