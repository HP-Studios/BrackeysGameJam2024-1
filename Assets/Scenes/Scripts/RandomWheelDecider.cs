using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWheelDecider : MonoBehaviour
{
    [SerializeField] private GameObject wheel;
    private float rotationSpeed = 360f; // Start with high rotation speed
    private float deceleration = 20f; // Deceleration rate
    private float totalRotation = 0; // Total rotation that has occurred
    private float targetAngle; // The target angle for the wheel to stop at
    private float roundsToSpin; // Number of rounds to spin before decelerating

    void Awake()
    {
        roundsToSpin = Random.Range(2, 3);
        targetAngle = Random.Range(0, 360);
        rotationSpeed = Random.Range(100, 150);
        deceleration = Random.Range(8, 10);
    }

    void Update()
    {
        float rotationThisFrame = rotationSpeed * Time.deltaTime;
        totalRotation += rotationThisFrame;

        // Start decelerating after the wheel has spun the desired number of rounds
        if (totalRotation >= 360 * roundsToSpin)
        {
            rotationSpeed -= deceleration * Time.deltaTime; // Deceleration
        }

        float currentAngle = wheel.transform.rotation.eulerAngles.x;
        float remainingAngle = Mathf.DeltaAngle(currentAngle, targetAngle);

        // If the wheel is close to the target angle, reduce the rotation speed to match the remaining angle
        if (Mathf.Abs(remainingAngle) < rotationSpeed * Time.deltaTime)
        {
            rotationSpeed = Mathf.Abs(remainingAngle) / Time.deltaTime;
        }

        // If the remaining angle is very small, stop the wheel
        if (Mathf.Abs(remainingAngle) < 0.01f)
        {
            rotationSpeed = 0;
        }

        wheel.transform.Rotate(rotationSpeed * Time.deltaTime * Mathf.Sign(remainingAngle), 0, 0); // Rotate
    }

}
