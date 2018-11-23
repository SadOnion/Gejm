using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaśmaKlejonca : MonoBehaviour {

    public Sprite[] weapons;

	
	// Update is called once per frame
	void Update () {
        switch (Data.gunName)
        {
            case "Rewolwer":
                {
                    GetComponent<SpriteRenderer>().sprite = weapons[0];

                    break;
                }
            case "MiniUzi":
                {
                    GetComponent<SpriteRenderer>().sprite = weapons[1];
                    break;
                }
            case "Magnum":
                {
                    GetComponent<SpriteRenderer>().sprite = weapons[2];
                    break;
                }
            case "RedHawk":
                {
                    GetComponent<SpriteRenderer>().sprite = weapons[3];
                    break;
                }
            default:
                {
                    break;
                }
        }
	}
}
