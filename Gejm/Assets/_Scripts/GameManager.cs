using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    bool isPaused;
    GameObject[] enemies;
    public Image panel;
    public WeaponItem[] weapons;
    private void Awake()
    {
        GameObject g = GameObject.FindGameObjectWithTag("Player");
        
        g.SetActive(true);
        
        switch (Data.gunName)
        {
            case "Rewolwer":
                {
                    g.GetComponentInChildren<GunController>().properties = weapons[0].properties;


                    break;
                }
            case "MiniUzi":
                {
                    g.GetComponentInChildren<GunController>().properties = weapons[1].properties;

                    break;
                }
            case "Magnum":
                {
                    g.GetComponentInChildren<GunController>().properties = weapons[2].properties;

                    break;
                }
            case "RedHawk":
                {
                    g.GetComponentInChildren<GunController>().properties = weapons[3].properties;

                    break;
                }
            default:
                {
                    break;
                }
        }
        
            
    }

    // Update is called once per frame
    void LateUpdate () {
        enemies = GameObject.FindGameObjectsWithTag("enemy");
        if(enemies.Length <= 0)
        {
            FindObjectOfType<SpawnerAI>().SpawnWave(FindObjectOfType<SpawnerAI>().wave);
        }
        if (GameObject.FindGameObjectWithTag("Player") == null) SceneManager.LoadScene(0);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                panel.color = new Color(255, 255, 255, 100);
                Time.timeScale = 0;

            }
            else
            {
                panel.color = new Color(255, 255, 255, 0);
                Time.timeScale = 1;
            }
            
        }
	}
}
