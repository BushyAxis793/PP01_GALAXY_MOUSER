using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speedFactor = 4f;
    [SerializeField] float xPosRange = 7f;
    [SerializeField] float zPosRange = 5f;
    [SerializeField] float loadDelay = 1f;

    [SerializeField] GameObject[] guns;
    [SerializeField] GameObject playerExplosion;

    [SerializeField] AudioClip shooting;
    AudioSource shootingInSpace;

    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject gameLeader;

    bool isAlive = true;
    float zPosForward = 3f;
    float inputMouseX, inputMouseZ;
    float controllFactor = 4f;

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
        var inputMouseX = Input.GetAxis("Mouse X");
        float xOffset = inputMouseX * speedFactor * Time.deltaTime;
        float originXPos = transform.position.x + xOffset;
        float clampedXPos = Mathf.Clamp(originXPos, -xPosRange, xPosRange);


        var inputMouseZ = Input.GetAxis("Mouse Y");
        float zOffset = inputMouseZ * speedFactor * Time.deltaTime;
        float originZPos = transform.position.z + zOffset;

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
        Destroy(gameObject);
        Destroy(explosion, 1f);
        isAlive = false;
        RestartScene();
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            mainMenuActive = !mainMenuActive;
            mainMenu.SetActive(mainMenuActive);
            if (mainMenuActive)
            {
                Cursor.visible = true;
                Time.timeScale = 0;
            }
            else
            {
                Cursor.visible = false;
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
