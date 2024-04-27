using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleEnemy : Controller_Enemy
{

    private GameObject player;

    private Rigidbody rb;

    private Vector3 direction;
    public int numberOfBullets = 8;
    public float radius = 2f;

    // Start is called before the first frame update
    void Start()
    {
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
        ShootInCircle();

        if (player != null)
        {
            direction = -(this.transform.localPosition - player.transform.localPosition).normalized;
        }
        base.Update();
    }

    void ShootInCircle()
    {
        float angleStep = 360f / numberOfBullets;

        for(int i = 0; i < numberOfBullets; i++)
        {
            float angle = i * angleStep;
            float x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            float y = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;

            Vector3 spawnPosition = transform.position + new Vector3 (x, y, 0);
            GameObject bullet = Instantiate(enemyProjectile, spawnPosition, Quaternion.identity);
        }
    }

    void FixedUpdate()
    {
        if (player != null)
            rb.AddForce(direction * enemySpeed);
    }
}
