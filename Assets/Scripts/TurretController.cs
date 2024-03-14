using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrentController : MonoBehaviour
{
    const float MOUSE_MIN_X = -350f;
    const float MOUSE_MAX_X = 1500f;

    const float fireRate = 0.2f;
    private float lastShootTime = 0f;

    [SerializeField]
    private GameObject bulletPrefab;

    void Start()
    {
        
    }

    private void Setup()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
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
        if (Time.time - lastShootTime >= fireRate)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = new Vector3(transform.position.x, transform.position.y + 0.35f, transform.position.z);
            bullet.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);

            lastShootTime = Time.time;
        }
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

    public void AddScore(float score)
    {
        Debug.Log("Score: " + score);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }
}
