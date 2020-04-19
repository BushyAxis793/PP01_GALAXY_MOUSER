using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject deathExplosionFX;
    [SerializeField] int health = 100;
    [SerializeField] int hitPoint = 10;
    int scorePerKill = 1;

    bool isAlive = true;

    ScoreScript scoreScript;

    private void Start()
    { 
        scoreScript = FindObjectOfType<ScoreScript>();
    }
    void OnParticleCollision(GameObject other)
    {
        GetHit();
        if (health<=1)
        {
            GameObject explosion = Instantiate(deathExplosionFX, transform.position, Quaternion.identity);
            
            Destroy(gameObject);
            Destroy(explosion,1f);
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
