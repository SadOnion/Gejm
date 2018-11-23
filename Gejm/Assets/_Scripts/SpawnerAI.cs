using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAI : MonoBehaviour {

    public float  startTimeBtwSpawns;

    public int wave = 1;
    float timeBtwSpawns;
    public GameObject[] enemies;
    public GameObject aidKit;
    float aidKitTimer = 50;
    // Use this for initialization
    void Start()
    {
        timeBtwSpawns = startTimeBtwSpawns;

        
    }
	
	// Update is called once per frame
	void Update () {
        if (aidKitTimer <= 0)
        {
            SpawnAidKit();
            aidKitTimer = 50;
        }
        else aidKitTimer -= Time.deltaTime;
        //if (timeBtwSpawns <= 0) SpawnRandomEnemy();
        //else timeBtwSpawns -= Time.deltaTime;
	}

    void SpawnRandomEnemy()
    {
        timeBtwSpawns = startTimeBtwSpawns;
        int rand = Random.Range(1, 4);
        Vector3 randomTransform = new Vector3(Random.Range(-19f, 20f), Random.Range(-17f, 17f));
        switch (rand)
        {
            case 1:
                {
                    Instantiate(enemies[0], randomTransform, Quaternion.identity);
                    break;
                }
            case 2:
                {
                    Instantiate(enemies[1], randomTransform, Quaternion.identity);
                    break;
                }
            case 3:
                {
                    Instantiate(enemies[2], randomTransform, Quaternion.identity);
                    break;
                }
            default:
                {

                    break;
                }
        }
    }
    void SpawnAidKit()
    {
        Vector3 randomTransform = new Vector3(Random.Range(-19f, 20f), Random.Range(-17f, 17f));
        Instantiate(aidKit,randomTransform,Quaternion.identity);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(new Vector3(-19, 17), new Vector3(20, 17));
        Gizmos.DrawLine(new Vector3(-19, -17), new Vector3(20, -17));
        Gizmos.DrawLine(new Vector3(-19, -17), new Vector3(-19, 17));
        Gizmos.DrawLine(new Vector3(20, -17), new Vector3(20, 17));
    }
    public void SpawnWave(int wave)
    {
        
        int x = Mathf.FloorToInt(0.2f*wave*wave+3);
        for (int i = 0; i < x; i++)
        {
            int rand = Random.Range(1, 4);
            Vector3 randomTransform = new Vector3(Random.Range(-19f, 20f), Random.Range(-17f, 17f));
            switch (rand)
            {
                case 1:
                    {
                        Instantiate(enemies[0], randomTransform, Quaternion.identity);
                        break;
                    }
                case 2:
                    {
                        Instantiate(enemies[1], randomTransform, Quaternion.identity);
                        break;
                    }
                case 3:
                    {
                        Instantiate(enemies[2], randomTransform, Quaternion.identity);
                        break;
                    }
                default:
                    {

                        break;
                    }
            }
           
        }
        Debug.Log("Start wave :" + this.wave);
        this.wave++;

    }
}

