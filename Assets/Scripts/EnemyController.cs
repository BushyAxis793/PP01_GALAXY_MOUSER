using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] GameObject deathExplosionFX;
    [SerializeField] int health = 100;
    [SerializeField] int hitPoint = 10;
    [SerializeField] AudioClip deathAudio;

    int scorePerKill = 1;
    bool isAlive = true;

    ScoreScript scoreScript;
    AudioSource audioSource;


    private void Start()
    {
        scoreScript = FindObjectOfType<ScoreScript>();
        audioSource = GetComponent<AudioSource>();
    }
    private void OnParticleCollision(GameObject other)
    {
        GetHit();
        EnemyDead();
    }

    private void EnemyDead()
    {
        if (health <= 1)
        {
            audioSource.PlayOneShot(deathAudio);
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
