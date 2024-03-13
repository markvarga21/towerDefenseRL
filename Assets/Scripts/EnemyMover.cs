using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    private GameObject player;

    private float enemySpeed = 1.0f;

    void Awake()
    {
        this.player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Vector3 direction = new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z);
        this.transform.position = Vector3.MoveTowards(this.transform.position, direction, enemySpeed * Time.deltaTime);
    }
}
