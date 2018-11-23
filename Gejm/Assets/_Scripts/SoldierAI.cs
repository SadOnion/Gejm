using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAI : MonoBehaviour {

    public int hp = 100;
    public float rotationSpeed;
    public float speed;
    public Transform shotSpawn;
    public float stoppingDistance;
    public float retreatDistance;
    public float timeBtwShots,startTimeBtwShots;
    public GameObject bullet;
    Transform player;


	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;
	}
	
	void Update () {
        //Walking
        float distance = Vector2.Distance(transform.position, player.position);
        if (distance > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            timeBtwShots -= Time.deltaTime;
        }
        else if(distance < stoppingDistance && distance > retreatDistance)
        {
            transform.position = this.transform.position;
            Shot();
        }else if(distance < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            Shot();
        }

        if (hp <= 0) Destroy(gameObject);
        

        //Rotation
        Vector2 rotateDirection = player.transform.position - transform.position;
        float angle = Mathf.Atan2(rotateDirection.y, rotateDirection.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
    private void Shot()
    {
        if (timeBtwShots <= 0)
        {
            Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);
            FindObjectOfType<AudioManager>().Play("shot");
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "bullet")
        {
            hp -= GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<GunController>().properties.damage;
        }
    }
}
