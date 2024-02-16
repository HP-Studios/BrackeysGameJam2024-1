using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWheelDecider : MonoBehaviour
{
    [SerializeField] GameObject wheel;
    [SerializeField] int laps = 4;
    float rotationSpeed; // Start with high rotation speed
    float targetAngle; // The target angle for the wheel to stop at
    bool isWheelSpining; //trigger for starting spin
    private bool spinningFinished; //To check if the spinning has stopped

    [SerializeField] float playerDistance = 4.0f;
    bool isPlayerInDistance;

    private float spinStartTime;
    [SerializeField] float spinDuration = 5.0f; // Spin for 5 seconds

    public bool SpinningFinished { get { return spinningFinished; } }


    void Awake()
    {
        SetRandomValues();

        spinningFinished = false;
    }

    void Update()
    {
        if (isWheelSpining && !spinningFinished)
        {
            SpinTheWheel();
        }
        isPlayerInDistance = Vector3.Distance(transform.position, Camera.main.transform.position) < playerDistance;
        Debug.Log(SpinningFinished);
    }

    private void SetRandomValues()
    {
        targetAngle = Random.Range(0, 360);
        rotationSpeed = (360 * laps + targetAngle) / spinDuration; // Calculate rotation speed based on spin duration and target angle
    }
    private void OnMouseDown()
    {
        if (isPlayerInDistance && !spinningFinished)
        {
            isWheelSpining = true;
            spinStartTime = Time.time; // Record the time when the spin starts
        }
    }

    private void SpinTheWheel()
    {
        if (Time.time - spinStartTime < spinDuration)
        {
            wheel.transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0, Space.Self); // Rotate the wheel
        }
        else
        {
            spinningFinished = true;
            isWheelSpining = false;
        }
    }
}