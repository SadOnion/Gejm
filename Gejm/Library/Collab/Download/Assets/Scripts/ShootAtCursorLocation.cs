using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtCursorLocation : MonoBehaviour {

    public float rotationSpeed;
    public GameObject projectile;
    public float projectileSpeed;
    public Transform bulletSpawnPosition;
    public float startWaitTime;
    float waitTime;
    [Range(0.1f,5)]
    public float bulletDestroyTime;
    [Range(0, 1)]
    public float t;

    // Update is called once per frame
    void Update() { 
    
        // Shooting Logic
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButton(0) && waitTime <=0)
        {
            waitTime = startWaitTime;
            GameObject bullet = Instantiate(projectile, bulletSpawnPosition.position, transform.rotation);
            Vector2 direction = (mousePosition - (Vector2)transform.position).normalized;
            bullet.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed * Time.deltaTime;
            Destroy(bullet, bulletDestroyTime);
        }
        waitTime -= Time.deltaTime;
    }
    private void FixedUpdate()
    {
        // Rotating Logic
        Vector2 rotateDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(rotateDirection.y, rotateDirection.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
