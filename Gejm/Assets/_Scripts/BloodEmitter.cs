using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodEmitter : MonoBehaviour {

    public GameObject blood;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bullet")
        {
            Instantiate(blood, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
    }
}
