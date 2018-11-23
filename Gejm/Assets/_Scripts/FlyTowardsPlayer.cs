using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyTowardsPlayer : MonoBehaviour {
    public int damage;
    public float speed;
    public float rotationSpeed;
    public float maxTimeBeforeBoom = 7.5f;
    bool isRotating = true;
    int stopMoving = 1;
    Animator anim;
    GameObject player;
    Rigidbody2D body;
    bool hit = false;
    CircleCollider2D area;
    AudioSource source;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        area = GetComponent<CircleCollider2D>();
        source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

        body.velocity = transform.up * speed * Time.deltaTime* stopMoving;
        Rotate(isRotating);
        if(maxTimeBeforeBoom <= 0)
        {
            stopMoving = 0;
            isRotating = false;
            anim.SetTrigger("Boom");
            Destroy(gameObject, 0.5f);
            if(!source.isPlaying)source.Play();
        }
        maxTimeBeforeBoom -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "bullet")
        {
            stopMoving = 0;
            isRotating = false;
            anim.SetTrigger("Boom");
            Destroy(gameObject, 0.5f);
            source.Play();
        }
        if(collision.tag == "Player")
        {
            stopMoving = 0;
            isRotating = false;
            anim.SetTrigger("Boom");
            source.Play();
        }
        if (area.IsTouching(player.GetComponent<Collider2D>()))
        {
            if(!hit)player.GetComponent<PlayerMovementController>().TakeDamage(damage);
            hit = true;
            Destroy(gameObject,0.5f);
        }
        
    }
    private void Rotate(bool rotate)
    {
        if (rotate)
        {
            Vector2 rotateDirection = player.transform.position - transform.position;
            float angle = Mathf.Atan2(rotateDirection.y, rotateDirection.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward) * Quaternion.Euler(0, 0, -90);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }
        
    }
}
