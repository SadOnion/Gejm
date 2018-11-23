using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public WeaponProperties properties = new WeaponProperties();
    public Transform shotSpawn;
    
    [Range(0, 500)]
    public int maxAmmo;
    [Range(0, 500)]
    public int actualAmmo;
    public bool infiniteAmmo = false;

    private float nextFire = 0.0F;
    private float recoil = 0.0f;
    private bool fireEnabled;
    // Use this for initialization
    void Start ()
    {
        fireEnabled = true;
    }

    private void Update()
    {
        if (transform.root.CompareTag("Player"))
        {
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
        if (properties.actualMagazineCapacity <= 0)
        {
            Reload();
            return;
        }
        if (!fireEnabled || Time.time < nextFire)
        {
            return;
        }

        // Weapon spread per bullet
        if (Time.time < nextFire + properties.accurateFireRate) {
            recoil += properties.recoilGrow;
            recoil = Mathf.Clamp(recoil, 0, properties.maxRecoil);
        }
        else recoil = 0;

        Debug.Log("recoil: "+recoil);

        float spread = Random.Range(-properties.maxBloom, properties.maxBloom);
        if (Mathf.Abs(spread / properties.maxBloom) < 0.3) spread = 0;

        spread += Random.Range(0, recoil) * Mathf.Sign(spread);

        spread = Mathf.Clamp(spread, -0.16f, 0.16f);
        Debug.Log("spread: " + spread);

        Quaternion rotation = shotSpawn.rotation;
        rotation.z += spread;

        properties.actualMagazineCapacity--;
        nextFire = Time.time + properties.minFireRate;


        Instantiate(properties.bullet, shotSpawn.position, rotation);
        FindObjectOfType<AudioManager>().Play("shot");
    }

    public void Reload()
    {
        
        if (!fireEnabled)
        {
            return;
        }
        fireEnabled = false;
        recoil = 0;
        StartCoroutine(Reloading(properties.reloadingTime));
    }

    IEnumerator Reloading(float time)
    {
        if (!FindObjectOfType<AudioManager>().IsPlaying("reload")) FindObjectOfType<AudioManager>().Play("reload");

        yield return new WaitForSeconds(time);

        if (infiniteAmmo) properties.actualMagazineCapacity = properties.maxMagazineCapacity;
        else
        {
            int toReload = properties.maxMagazineCapacity - properties.actualMagazineCapacity;

            if (actualAmmo - toReload >= 0)
            {
                properties.actualMagazineCapacity += toReload;
                actualAmmo -= toReload;
            }
            else
            {
                properties.actualMagazineCapacity += actualAmmo;
                actualAmmo = 0;
            }
        }

        fireEnabled = true;
    }
}
