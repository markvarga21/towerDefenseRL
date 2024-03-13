using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Barrier")
        {
            Destroy(gameObject);
        }
    }
}
