using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : MonoBehaviour
{

    public WeaponProperties properties = new WeaponProperties();

    private void Start()
    {
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (collision.GetComponentInChildren<GunController>() == null)
            {
                return;
            }
            GunController gunController = collision.GetComponentInChildren<GunController>();
            SpriteRenderer spriteRenderer = gunController.GetComponentInChildren<SpriteRenderer>();

            spriteRenderer.sprite = properties.spriteHolding;

            Utility.Swap(ref gunController.properties, ref properties);

            GetComponent<SpriteRenderer>().sprite = properties.spriteItem;

            transform.position = collision.transform.position;

            transform.rotation = Quaternion.Euler(0.0f, 0.0f, Random.rotation.z);

            //GameObject droppedWeapon = gunController.properties.prefabItem;
            //Vector2 dropPosition = collision.transform.position;
            //Quaternion dropRotation = Quaternion.Euler(0.0f, 0.0f, Random.rotation.z);
            //Instantiate(droppedWeapon, dropPosition, dropRotation);

            //gunController.properties = properties;

            //spriteRenderer.sprite = properties.spriteItem;

            //Destroy(transform.gameObject);
        }
    }
}
