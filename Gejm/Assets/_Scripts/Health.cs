using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour {


    PlayerMovementController player;
    Image img;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementController>();
        img = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        
        img.fillAmount = (float)player.ActualHp()/player.hitPoints;
    }
}
