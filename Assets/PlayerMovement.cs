using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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


    [SerializeField] AudioClip shooting;
    AudioSource shootingInSpace;

    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject gameLeader;


    bool mainMenuActive = false;
    bool optionsMenuActive = false;

    private void Start()
    {
        shootingInSpace = GetComponent<AudioSource>();
        Cursor.visible = false;

    }
    private void Update()
    {
        if (isAlive)
        {

            PlayerMovementTransform();
            ActiveGuns();
            PauseGame();
            ResetPosition();

        }



    }

    private void ResetPosition()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = new Vector3(0f, 1f, gameLeader.transform.position.z);
        }
    }

    private void ActiveGuns()
    {
        if (Input.GetMouseButton(0))
        {
            TurnOnGuns(true);
            shootingInSpace.PlayOneShot(shooting);
        }
        else
        {
            shootingInSpace.Stop();
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


    private void TurnOnGuns(bool isTurned)
    {
        foreach (GameObject gun in guns)
        {
            var emissionProcess = gun.GetComponent<ParticleSystem>().emission;
            emissionProcess.enabled = isTurned;
        }
    }

    public void OnTriggerEnter(Collider collision)
    {
        GameObject explosion = Instantiate(playerExplosion, transform.position, Quaternion.identity);
      //  Destroy(gameObject);
        Destroy(explosion, .25f);
        //isAlive = false;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }



    public void PauseGame()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            mainMenuActive = !mainMenuActive;
            mainMenu.SetActive(mainMenuActive);
            if (mainMenuActive)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;

            }

        }
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    
}
