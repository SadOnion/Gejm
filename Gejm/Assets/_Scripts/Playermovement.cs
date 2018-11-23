using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour {

    public int speed = 2;
    Rigidbody2D body;
	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float horizontalSpeed = Input.GetAxisRaw("Horizontal");
        float   verticalSpeed = Input.GetAxisRaw("Vertical");

        body.velocity = new Vector2(horizontalSpeed, verticalSpeed) * speed;
		
	}
}
