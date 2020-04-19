using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        transform.Translate(Vector3.forward * Time.deltaTime);
        
    }
}
