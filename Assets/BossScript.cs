using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    [SerializeField] Transform playerShip;
    [SerializeField] GameObject deathExplosionFX;
    int health = 200;
    int hitPoint = 10;
    int scorePerKill = 1;

    ScoreScript scoreScript;

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

        if (distanceToPlayer <= 10)
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (health <= 0)
        {
            GetHit();
            GameObject explosion = Instantiate(deathExplosionFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(explosion, 1f);
            scoreScript.ScoreCount(scorePerKill);
        }
    }

    private void GetHit()
    {
        health -= hitPoint;
    }


}
