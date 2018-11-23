using UnityEngine;
using UnityEngine.UI;

public class BulletUI : MonoBehaviour {


    int actualAmmo;
    int maxAmmo;
    int ammoLeft;

    public Image[] bullets;
    public Sprite fullBullet, emptyBullet;

    GunController gun;

    private void Start()
    {
        gun = GetComponentInChildren<GunController>();
        
    }

    private void Update()
    {
        actualAmmo = gun.properties.actualMagazineCapacity;
        maxAmmo = gun.properties.maxMagazineCapacity;
        ammoLeft = gun.actualAmmo;

        for (int i = 0; i < bullets.Length; i++)
        {
            if(i < actualAmmo)
            {
                bullets[i].sprite = fullBullet;
            }
            else
            {
                bullets[i].sprite = emptyBullet;
            }

            if(i < maxAmmo)
            {
                bullets[i].enabled = true;
            }else
            {
                bullets[i].enabled = false;
            }
        }
    }
}
