using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMovement : MonoBehaviour
{
    PlayerMovement playerMovement;


    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();

    }
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        transform.Translate(Vector3.forward * Time.deltaTime);

    }

}
