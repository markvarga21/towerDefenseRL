using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrentController : MonoBehaviour
{
    const float MOUSE_MIN_X = -350f;
    const float MOUSE_MAX_X = 1500f;

    [SerializeField]
    private GameObject bulletPrefab;

    void Start()
    {
        
    }

    private float mapMouseXToRotation(float mouseX)
    {
        float rotation = 0;
        float range = MOUSE_MAX_X - MOUSE_MIN_X;
        float percent = (mouseX - MOUSE_MIN_X) / range;
        rotation = percent * 180;
        return rotation;
    }

    private void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = new Vector3(transform.position.x, transform.position.y + 0.35f, transform.position.z);
        bullet.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
    }


    // Update is called once per frame
    void Update()
    {
        float mousePosition = Input.mousePosition.x;
        transform.rotation = Quaternion.Euler(0, mapMouseXToRotation(mousePosition), 0);
        
        // Listen to click event
        if (Input.GetMouseButtonDown(0))
        {
            ShootBullet();

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }
}
