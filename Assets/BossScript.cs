using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossScript : MonoBehaviour
{
    [SerializeField] Transform playerShip;
    [SerializeField] GameObject deathExplosionFX;
    [SerializeField] int health = 2000;
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


        if (distanceToPlayer <= 5f)
        {
            transform.Translate(Vector3.back * Time.deltaTime);
        }

    }

    private void OnParticleCollision(GameObject other)
    {


        GetHit();
        if (health <= 1)
        {
            isAlive = false;
            GameObject explosion = Instantiate(deathExplosionFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(explosion, 1f);
            scoreScript.ScoreCount(scorePerKill);
            Invoke("LoadNextLevel", 2f);
           

        }
    }

    private void GetHit()
    {
        if (isAlive)
        {

            health -= hitPoint;
        }
    }

    private void LoadNextLevel()
    {
        if (!isAlive)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }


}
