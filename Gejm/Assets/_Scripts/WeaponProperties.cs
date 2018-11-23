using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponProperties
{
    //Dictionary<int, string> dict = new Dictionary<int, string>();
    public string weaponType = "pistol";
    public GameObject bullet;
    public Sprite spriteHolding;
    public Sprite spriteItem;
    [Range(0, 100)]
    public int maxMagazineCapacity = 6;
    public int actualMagazineCapacity;
    [Range(0, 20)]
    public int bulletsPerShot = 1;
    public float reloadingTime = 2.5f;
    [Range(0, 2f)]
    public float accurateFireRate = 0.5F;
    [Range(0, 2f)]
    public float minFireRate = 0.3F;
    [Range(0, 0.16f)]
    public float maxBloom = 0.05f;
    [Range(0, 0.16f)]
    public float maxRecoil = 0.05f;
    [Range(0, 0.16f)]
    public float recoilGrow = 0.01f;
    public int damage = 26;

    public WeaponProperties()
    {  
        actualMagazineCapacity = maxMagazineCapacity;
        minFireRate = accurateFireRate / 2;
    }
}
