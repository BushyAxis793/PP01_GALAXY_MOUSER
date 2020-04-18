using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float inputMouseX, inputMouseZ;
    float controllFactor = 4f;
    [SerializeField] float speedFactor = 4f;

    [SerializeField] float xPosRange = 7f;
    [SerializeField] float zPosRange = 5f;
    float zPosForward = 1f;

    [SerializeField] GameObject[] guns;

    private void Start()
    {
        Cursor.visible = false;
    }
    private void Update()
    {
        PlayerMovementTransform();
        ActiveGuns();

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
        float clampedZPos = Mathf.Clamp(originZPos, -zPosRange, zPosForward);



        transform.localPosition = new Vector3(clampedXPos, 1f, clampedZPos);
        

    }

    private void PlayerRotation()
    {
        float roll = inputMouseX * controllFactor;
        transform.localRotation = Quaternion.Euler(0, 0, roll);
    }
    private void ActiveGuns()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Strzelam");

            foreach (GameObject gun in guns)
            {
                var emissionProcess = gun.GetComponent<ParticleSystem>().emission;
                emissionProcess.enabled = false;
            }
        }
    }

}
