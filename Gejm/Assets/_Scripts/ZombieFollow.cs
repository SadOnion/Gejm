using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFollow : MonoBehaviour {
    public int damage;
    public float rotationSpeed;
    public int hitPoints = 100;
    public float speed;
    public BoxCollider2D attackRange;
    public float startAttackDelay;

    float attackDelay;
    Animator anim;
    PlayerMovementController player;
    Rigidbody2D body;
    private void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementController>();
        attackDelay = startAttackDelay;
        
    }

    // Update is called once per frame
    void Update () {
        if (hitPoints <= 0) Destroy(gameObject);

        if (attackRange.IsTouching(player.GetComponent<Collider2D>()) && attackDelay <= 0)
        {

            attackDelay = startAttackDelay;
            anim.SetTrigger("Punch");
            player.TakeDamage(damage);

        }
        else
        {
            attackDelay -= Time.deltaTime;
            if (Vector2.Distance(transform.position, player.transform.position) > 0.8f)
                transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        
            
        
        ////transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Time.deltaTime * speed);
        ///rotating shit
        Vector2 rotateDirection = player.transform.position - transform.position;
        float angle = Mathf.Atan2(rotateDirection.y, rotateDirection.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);// * Quaternion.Euler(0, 0, -90);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "bullet")
        {
            hitPoints -= player.GetComponentInChildren<GunController>().properties.damage;
        }
    }

}
