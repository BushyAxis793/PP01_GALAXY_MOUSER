using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillatorMovement : MonoBehaviour
{
    [SerializeField] Vector3 movementVector = new Vector3(-6f, 0f, 0f);
    [SerializeField] float period = 2f;

    [Range(0, 1)] [SerializeField] float movementFactor;

    Vector3 startingPoint;

    private void Start()
    {
        startingPoint = transform.position;
    }
    private void Update()
    {
        CalculateMove();
    }

    private void CalculateMove()
    {
        float cycles = Time.time / period;
        float tau = Mathf.PI * 2;//=6.28
        float baseSinWave = Mathf.Sin(cycles * tau);
        movementFactor = baseSinWave / 2f + 0.5f;
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPoint + offset;
    }
}
