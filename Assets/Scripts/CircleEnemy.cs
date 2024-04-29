using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CircleEnemy : Controller_Enemy
{

    //Nuevo enemigo, la idea es que dispare de manera circular, tengo que corregir eso.

    private GameObject player;

    private Rigidbody rb;
    private float shootingCooldownCircle;
    private Vector3 direction;
    public int numberOfBullets = 8;
    public float radius = 2f;

    // Start is called before the first frame update
    void Start()
    {
        shootingCooldownCircle = 10f;

        if (Controller_Player._Player != null)
        {
            player = Controller_Player._Player.gameObject;
        }
        else
        {
            player = GameObject.Find("Player");
        }
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public override void Update()
    {
        shootingCooldownCircle -= Time.timeScale;
        CheckLimits();
        ShootInCircle();

        if (player != null)
        {
            direction = -(this.transform.localPosition - player.transform.localPosition).normalized;
        }
        //base.Update();
    }

    void ShootInCircle()
    {
        if (Controller_Player._Player != null)
        {
            if(shootingCooldownCircle <= 0)
            {

                float angleStep = 360f / numberOfBullets;

                float x = Mathf.Sin(Mathf.Deg2Rad * angleStep) * radius;
                float y = Mathf.Cos(Mathf.Deg2Rad * angleStep) * radius;

                Vector3 spawnPosition = transform.position + new Vector3 (x, y, 0);

                GameObject bullet = Instantiate(enemyProjectile, spawnPosition, Quaternion.identity);
                // Puedes ajustar la rotación de las balas si es necesario
                bullet.transform.rotation = Quaternion.Euler(x, y, angleStep);
            }
        }
        
    }

    void FixedUpdate()
    {
        if (player != null)
            rb.AddForce(direction * enemySpeed);
    }

    private void CheckLimits()
    {
        if (this.transform.position.x < xLimit)
        {
            Destroy(this.gameObject);
        }
    }
}
