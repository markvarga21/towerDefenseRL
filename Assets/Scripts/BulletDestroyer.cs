using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroyer : MonoBehaviour
{
    const string PLAYER_NAME = "TBasic_lvl1_top";
    private TurrentController turrentController;

    private void Awake()
    {
        turrentController = GameObject.Find(PLAYER_NAME).GetComponent<TurrentController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            turrentController.AddScore(1.0f);
        }

        if (other.gameObject.tag == "Barrier")
        {
            Destroy(gameObject);
            turrentController.AddScore(-0.5f);
        }
    }
}
