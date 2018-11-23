using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public ParticleSystem blood;
    public float rotationSpeed = 15;
    public int hitPoints = 100;
    public float speed = 2;
    public float crossMovementPenalty = 0.7f;
    public float minAcceleration = 0.4f;
    public float maxAcceleration = 1;
    public float accelerationSmoothing = 2.6f;

    private int hp;
    private Rigidbody2D rb;
    private float acceleration = 1;
    private float horizontalSpeed;
    private float verticalSpeed;

    // Use this for initialization
    void Start()
    {
        hp = hitPoints;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        horizontalSpeed = Input.GetAxisRaw("Horizontal");
        verticalSpeed = Input.GetAxisRaw("Vertical");
        float penalty = 1;

        if (horizontalSpeed != 0 && verticalSpeed != 0)
        {
            penalty = crossMovementPenalty;
        }

        Vector2 movement = new Vector2(horizontalSpeed, verticalSpeed);

        rb.velocity = movement * speed * penalty * Mathf.Clamp(acceleration, minAcceleration, maxAcceleration);
        

        // Rotating Logic
        Vector2 rotateDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(rotateDirection.y, rotateDirection.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward)*Quaternion.Euler(0,0,-90);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }

    void Update()
    {
        if (hp <= 0) Destroy(gameObject);
    if(horizontalSpeed != 0 || verticalSpeed != 0){
      if(acceleration< maxAcceleration)
      acceleration += Time.deltaTime * accelerationSmoothing;
      
    }else{
      acceleration = minAcceleration;
    }
    
  }
    public void TakeDamage(int dmg)
    {
        
        Instantiate(blood, transform.position, Quaternion.identity);
        hp -= dmg;
    }
    public int ActualHp()
    {
        return hp;
    }
    public void Heal(int h)
    {
        if (hp + h > hitPoints) hp = hitPoints;
        else hp += h;
        
    }
    

    
}

