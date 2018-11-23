using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    Transform objectToFollow;
    Vector3 offset = new Vector3(0, 0, -10);
    public float xMin, xMax, yMin, yMax;
	
	// Update is called once per frame
	void LateUpdate () {
        objectToFollow = GameObject.FindGameObjectWithTag("Player").transform ?? transform;
        transform.position = objectToFollow.position + offset;
        if (transform.position.x > xMax)
        {
            transform.position= new Vector3(xMax,transform.position.y,-1);
        }
        if (transform.position.y > yMax)
        {
            transform.position = new Vector3(transform.position.x, yMax, -1);
        }
        if (transform.position.x < xMin)
        {
            transform.position = new Vector3(xMin, transform.position.y, -1);
        }
        if (transform.position.y < yMin)
        {
            transform.position = new Vector3(transform.position.x, yMin, -1);
        }
    }
}
