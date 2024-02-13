using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWheelDecider : MonoBehaviour
{
    [SerializeField] GameObject wheel;
    [SerializeField] float rotationSpeedOffSet;
    [SerializeField] float decelerationOffSet;
    float rotationSpeed; // Start with high rotation speed
    float deceleration; // Deceleration rate
    float targetAngle; // The target angle for the wheel to stop at
    float roundsToSpin; // Number of rounds to spin before decelerating
    bool isWheelSpining; //triger for starting spin
    float totalDistance;
    // h = V0 * t - 1/2 a t^2

    void Awake()
    {
        SetRandomValues();
    }
    private void Start()
    {
        rotationSpeed += rotationSpeedOffSet;
        deceleration += decelerationOffSet;
    }
    void Update()
    {
        if (isWheelSpining)
        {
            SpinTheWheel();
        }
    }

    private void SetRandomValues()
    {
        roundsToSpin = Random.Range(2, 3);
        targetAngle = Random.Range(0, 360);
        totalDistance = roundsToSpin * 360 + targetAngle;
        rotationSpeed = Random.Range(180, 200);
        deceleration = Random.Range(15, 20);
    }
    private void OnMouseDown()
    {
        isWheelSpining = true;
    }
    private void SpinTheWheel()
    {
        if (totalDistance > 0)
        {
            totalDistance = rotationSpeed * Time.deltaTime - (0.5f * deceleration * Time.deltaTime * Time.deltaTime);
            wheel.transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0); // Rotate the wheel
            rotationSpeed -= deceleration * Time.deltaTime; // Decrease the speed
        }
    }
}
