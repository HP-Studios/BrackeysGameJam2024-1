using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWheelDecider : MonoBehaviour
{
    [SerializeField] private GameObject wheel;
    private float rotationSpeed; // Start with high rotation speed
    private float deceleration; // Deceleration rate
    private float targetAngle; // The target angle for the wheel to stop at
    private float roundsToSpin; // Number of rounds to spin before decelerating

    private float totalDistance;

    // h = V0 * t - 1/2 a t^2

    void Awake()
    {
        roundsToSpin = Random.Range(2, 3);
        targetAngle = Random.Range(0, 360);
        totalDistance = roundsToSpin * 360 + targetAngle;
        rotationSpeed = Random.Range(180, 200);
        deceleration = Random.Range(15, 20);
    }

    void Update()
    {
        if (totalDistance > 0)
        {
            totalDistance = rotationSpeed * Time.deltaTime - (0.5f * deceleration * Time.deltaTime * Time.deltaTime);
            wheel.transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0); // Rotate the wheel
            rotationSpeed -= deceleration * Time.deltaTime; // Decrease the speed
        }
    }


}
