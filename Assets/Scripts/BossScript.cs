using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossScript : MonoBehaviour
{
    [SerializeField] Transform playerShip;
    [SerializeField] GameObject deathExplosionFX;
    [SerializeField] int health = 1000;


    int hitPoint = 10;
    int scorePerKill = 1;
    bool isAlive = true;


    ScoreScript scoreScript;

    void Start()
    {
        scoreScript = FindObjectOfType<ScoreScript>();
    }

    private void Update()
    {
        StartMovement();
        BossStatus();

    }



    private void StartMovement()
    {
        CalculateDistanceToPlayer();
    }

    private void CalculateDistanceToPlayer()
    {
        var distanceToPlayer = Vector3.Distance(playerShip.transform.position, transform.position);

        if (distanceToPlayer <= 5f)
        {
            transform.Translate(Vector3.back * Time.deltaTime);
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        GetHit();
        BossDead();
    }

    private void BossDead()
    {
        if (health <= 1)
        {
            isAlive = false;
            GameObject explosion = Instantiate(deathExplosionFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(explosion, 1f);
            scoreScript.ScoreCount(scorePerKill);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
    }

    private void GetHit()
    {
        if (isAlive)
        {

            health -= hitPoint;
        }
    }

    private void BossStatus()
    {



        var playerPosition = playerShip.transform.position.z;
        var bossPosition = transform.position.z;
        var distance = Vector3.Distance(playerShip.transform.position, transform.position);
        print(distance);

        if (distance <= 10)
        {
            if (distance > 10)
            {
                var player = FindObjectOfType<PlayerMovement>();
                Destroy(player, 5f);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }





}
