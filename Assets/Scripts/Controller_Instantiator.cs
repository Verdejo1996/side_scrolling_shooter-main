using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Instantiator : MonoBehaviour
{
    public float timer=7;

    public  List<GameObject> enemies;

    public GameObject instantiatePos;

    private float time = 0;

    private int multiplier = 20;

    void Start()
    {
        
    }

    void Update()
    {
        timer -= Time.deltaTime;
        SpawnEnemies();
        ChangeVelocity();
    }

    private void ChangeVelocity()
    {
        time += Time.deltaTime;
        if (time > multiplier)
        {
            multiplier *= 2;
            //Increase velocity
        }
    }

    private void SpawnEnemies()
    {
        if (timer <= 0)
        {
            float offsetX = instantiatePos.transform.position.x;
            int rnd = UnityEngine.Random.Range(0, enemies.Count);
            if(rnd == 3)
            {
                offsetX = offsetX + 1;
                Vector3 transform = new Vector3(offsetX, instantiatePos.transform.position.y, instantiatePos.transform.position.z);
                Instantiate(enemies[3], transform, Quaternion.identity);
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    offsetX = offsetX + 4;
                    Vector3 transform = new Vector3(offsetX, instantiatePos.transform.position.y, instantiatePos.transform.position.z);
                    Instantiate(enemies[rnd], transform, Quaternion.identity);
                }

            }
            timer = 7;
        }
    }
}
