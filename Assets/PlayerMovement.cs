using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    float inputMouseX, inputMouseZ;
    float controllFactor = 4f;
    [SerializeField] float speedFactor = 4f;

    [SerializeField] float xPosRange = 7f;
    [SerializeField] float zPosRange = 5f;
    float zPosForward = 3f;

    [SerializeField] GameObject[] guns;
    [SerializeField] GameObject playerExplosion;
    bool isAlive = true;

    private void Start()
    {
        Cursor.visible = false;

    }
    private void Update()
    {
        if (isAlive)
        {

            PlayerMovementTransform();
            ActiveGuns();
        }
        else
        {
            return;
        }


    }

    private void ActiveGuns()
    {
        if (Input.GetMouseButton(0))
        {
            TurnOnGuns(true);
        }
        else
        {
            TurnOnGuns(false);
        }
    }

    private void PlayerMovementTransform()
    {
        inputMouseX = Input.GetAxis("Mouse X");
        inputMouseZ = Input.GetAxis("Mouse Y");

        float xOffset = inputMouseX * speedFactor * Time.deltaTime;
        float zOffset = inputMouseZ * speedFactor * Time.deltaTime;

        float originXPos = transform.position.x + xOffset;
        float originZPos = transform.position.z + zOffset;

        float clampedXPos = Mathf.Clamp(originXPos, -xPosRange, xPosRange);
        
        transform.localPosition = new Vector3(clampedXPos, 1f, originZPos);
        transform.Translate(Vector3.forward * Time.deltaTime);

    }



    private void PlayerRotation()//todo rotation with scale shooting
    {
        float roll = inputMouseX * controllFactor;
        transform.localRotation = Quaternion.Euler(0, 0, roll);
    }

    private void TurnOnGuns(bool isTurned)
    {
        foreach (GameObject gun in guns)
        {
            var emissionProcess = gun.GetComponent<ParticleSystem>().emission;
            emissionProcess.enabled = isTurned;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        GameObject explosion =  Instantiate(playerExplosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(explosion, .25f);
        isAlive = false;
        
    }

    private void RestartLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

}
