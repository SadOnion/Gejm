using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    public float fireRate;
    public GameObject bullet;
    public Transform bulletSpawnPoint;
    public Transform[] destinations;
    public float stppingDistance;
    public float startWaitTime,speed;
    public float spottedDistance;
    float waitTime,fireWait;
    Rigidbody2D body;
    int randomSpot;
    Transform player;
    Transform target;
	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, destinations.Length);
        target = destinations[randomSpot];
        player = GameObject.FindGameObjectWithTag("Player").transform;
        fireWait = fireRate;
    }
	
	// Update is called once per frame
	void Update () {
        if ((Vector2.Distance(transform.position, player.transform.position) > spottedDistance))
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else Follow();
    if (Vector2.Distance(transform.position, destinations[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, destinations.Length);
                target = destinations[randomSpot];
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

    }
    private void FixedUpdate()
    {
        Vector2 rotateDirection = target.position - transform.position;
        float angle = Mathf.Atan2(rotateDirection.y, rotateDirection.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        if(Vector2.Distance(target.position,transform.position) >=0.2f)
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10 * Time.deltaTime);
    }

    private void Follow()
    {
        target = player.transform;
        if (Vector2.Distance(transform.position, player.position) > stppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = this.transform.position;
        }
        if (fireWait <= 0) {
            
            Quaternion shotRotation = Quaternion.Euler(0, 0, bulletSpawnPoint.rotation.z + Random.Range(-5, 6));
            Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            fireWait = fireRate;
    }
        else fireWait -= Time.deltaTime;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.gray;
        Gizmos.DrawWireSphere(transform.position, spottedDistance);
    }
}
