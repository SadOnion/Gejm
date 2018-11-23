using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject shot;
    public Transform shotSpawn;
    public SpriteRenderer spriteGround;
    public SpriteRenderer spriteHands;
    [Range(0, 100)]
    public int magazineCapacity = 7;
    public float reloadingTime = 2.5f;
    public float fireRate = 0.5F;
    [Range(0, 46)]
    public float maxBloom = 5;

    private float nextFire = 0.0F;
    private int magazine;
    private bool fireEnabled;

    // Use this for initialization
    void Start () {
        //maxBloom /= 100;
        magazine = magazineCapacity;
        fireEnabled = true;
    }
	
	// Update is called once per frame
	void Update () {
		if (transform.root.CompareTag("Player")){
            if (Input.GetButton("Fire1"))
            {
                Fire();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                Reload();
            }
        }
	}

    public void Fire()
    {
        if (magazine <= 0)
        {
            Reload();
            return;
        }
        if (!fireEnabled || Time.time < nextFire)
        {
            return;
        }
        /*float bloom = Random.Range(-maxBloom, maxBloom);
        if (Mathf.Abs(bloom / maxBloom) < 0.3)
        {
            bloom = 0;
        }
        */
        Quaternion rotation = shotSpawn.rotation;
        //rotation.z += bloom;
        
        magazine -= 1;
        nextFire = Time.time + fireRate;

        Instantiate(shot, shotSpawn.position, rotation * Quaternion.Euler(0,0,Random.Range(-maxBloom,maxBloom)));
    }

    public void Reload()
    {
        StartCoroutine(DisableFire(reloadingTime));
        magazine = magazineCapacity;
    }

    IEnumerator DisableFire(float time)
    {
        fireEnabled = false;
        yield return new WaitForSeconds(time);
        fireEnabled = true;
    }
}
