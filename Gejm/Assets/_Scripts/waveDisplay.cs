using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class waveDisplay : MonoBehaviour {


    SpawnerAI spawner;
    Text text;
    int wave;
    Animator anim;

	// Use this for initialization
	void Start () {
        spawner = FindObjectOfType<SpawnerAI>();
        text = GetComponent<Text>();
        anim = GetComponent<Animator>();
        wave = spawner.wave;
	}
	
	// Update is called once per frame
	void Update () {
        if (wave != spawner.wave)
        {
            
            text.text = "Wave " + wave;
            wave++;
            anim.SetTrigger("Show");
        }
	}
}
