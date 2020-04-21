using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    [SerializeField] Transform playerShip;
    [SerializeField] GameObject deathExplosionFX;
    [SerializeField] int health = 200;
    int hitPoint = 10;
    int scorePerKill = 1;

    ScoreScript scoreScript;

    bool isAlive = true;


    void Start()
    {
        scoreScript = FindObjectOfType<ScoreScript>();
    }

    private void Update()
    {
        StartMovement();
    }

    private void StartMovement()
    {
        var distanceToPlayer = Vector3.Distance(playerShip.transform.position, transform.position);

        Debug.Log(distanceToPlayer);

        if (distanceToPlayer <= 5f)
        {
            transform.Translate(Vector3.back * Time.deltaTime);
        }

    }

    private void OnParticleCollision(GameObject other)
    {
        if (health <= 1)
        {
            GetHit();
            GameObject explosion = Instantiate(deathExplosionFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(explosion, 1f);
            scoreScript.ScoreCount(scorePerKill);
            isAlive = false;

        }
    }

    private void GetHit()
    {
        if (isAlive)
        {

            health -= hitPoint;
        }
    }


}
