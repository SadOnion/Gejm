using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketManAI : MonoBehaviour {
    public int hp = 100;
    public float rotationSpeed;
    public float timeBtwRockets;
    public Transform spawnShot;
    public GameObject rocket;

    float nextShot;
    GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        nextShot = timeBtwRockets + Random.Range(-2,2);
	}
	
	// Update is called once per frame
	void Update () {
        if (hp <= 0) Destroy(gameObject);
        if (nextShot <= 0)
        {
            nextShot = timeBtwRockets;
            Instantiate(rocket, spawnShot.position, transform.rotation);
        }
        else nextShot -= Time.deltaTime;


        Vector2 rotateDirection = player.transform.position - transform.position;
        float angle = Mathf.Atan2(rotateDirection.y, rotateDirection.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward) * Quaternion.Euler(0, 0, -90);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "bullet")
        {
            hp -= player.GetComponentInChildren<GunController>().properties.damage;
        }
    }
}
