using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBulletAfterTime : MonoBehaviour {

    public float destroyTime;
	
	void Start () {
        Destroy(this.gameObject, destroyTime);
	}
	
	
}
