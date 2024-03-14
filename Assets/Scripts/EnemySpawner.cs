using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject xLeftBoundary;
    private Transform xLeftBoundaryTransform;
    [SerializeField]
    private GameObject xRightBoundary;
    private Transform xRightBoundaryTransform;
    [SerializeField]
    private GameObject zBottomBoundary;
    private Transform zBottomBoundaryTransform;
    [SerializeField]
    private GameObject zTopBoundary;
    private Transform zTopBoundaryTransform;

    [SerializeField]
    private GameObject enemyPrefab;

    private float spawnInterval = 5f;
    private float nextTimeToSpawn = 0f;

    private void Setup()
    {
        xLeftBoundaryTransform = xLeftBoundary.transform;
        xRightBoundaryTransform = xRightBoundary.transform;
        zBottomBoundaryTransform = zBottomBoundary.transform;
        zTopBoundaryTransform = zTopBoundary.transform;
    }

    private Vector3 randomizePosition() { 
        float x = Random.Range(xLeftBoundaryTransform.position.x, xRightBoundaryTransform.position.x);
        float z = Random.Range(zBottomBoundaryTransform.position.z, zTopBoundaryTransform.position.z);
        return new Vector3(x, 1.4f, z);
    }

    private void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab);
        enemy.transform.position = randomizePosition();
    }

    void Start()
    {
        Setup();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextTimeToSpawn)
        {
            nextTimeToSpawn = Time.time + spawnInterval;
            SpawnEnemy();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(this.gameObject);
        }
    }
}
