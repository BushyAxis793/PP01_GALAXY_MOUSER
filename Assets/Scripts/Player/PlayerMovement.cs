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
    [SerializeField] float loadDelay = 5f;

    [SerializeField] GameObject[] guns;
    [SerializeField] GameObject playerExplosion;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject gameLeader;

    [SerializeField] AudioClip shootingInSpace;
    [SerializeField] AudioClip deathSFX;

    bool isAlive = true;
    bool mainMenuActive = false;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
            audioSource.PlayOneShot(shootingInSpace);
        }
        else
        {
            audioSource.Stop();
            TurnOnGuns(false);
        }
    }
    private void PlayerMovementTransform()
    {
        transform.localPosition = new Vector3(CalculateXMove(), 1f, CalculateZMove());
        transform.Translate(Vector3.forward * Time.deltaTime);
    }
    private float CalculateXMove()
    {
        var inputMouseX = Input.GetAxis("Mouse X");
        float xOffset = inputMouseX * speedFactor * Time.deltaTime;
        float originXPos = transform.position.x + xOffset;
        float clampedXPos = Mathf.Clamp(originXPos, -xPosRange, xPosRange);
        return clampedXPos;
    }
    private float CalculateZMove()
    {
        var inputMouseZ = Input.GetAxis("Mouse Y");
        float zOffset = inputMouseZ * speedFactor * Time.deltaTime;
        float originZPos = transform.position.z + zOffset;
        return originZPos;
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
        PlayerDeath();
    }
    private void PlayerDeath()
    {
        GameObject explosion = Instantiate(playerExplosion, transform.position, Quaternion.identity);
        audioSource.PlayOneShot(deathSFX);
        Destroy(gameObject);
        Destroy(explosion, 1f);
        isAlive = false;
        RestartLevel();
    }
    private void RestartLevel()
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
