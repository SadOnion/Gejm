using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAidKit : MonoBehaviour {

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementController>().Heal(50);
            Destroy(gameObject);
        }
    }
}
