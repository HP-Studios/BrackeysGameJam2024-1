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
    
    private bool spinningFinished; //To check if the spinning has stopped
    public bool SpinningFinished { get { return spinningFinished; } }

    public void SpinningReset()
    {
        spinningFinished = false;
    }

    // h = V0 * t - 1/2 a t^2

    void Awake()
    {
        SetRandomValues();
        rotationSpeed += rotationSpeedOffSet;
        deceleration += decelerationOffSet;
        spinningFinished = false;
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
        roundsToSpin = Random.Range(1, 2);
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
            wheel.transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0, Space.Self); // Rotate the wheel SPACE SELF OBJEN�N KEND� EKSEN�NDE D�NMES�NE YARAR BEN EKLED�M SORUN �IKARSA BUNA B�R BAK EM�N DE��L�M EKLEMEK MANTIKLI MI SORUN �IKMASIN D�YE EKLED�M AMA SORUN DA �IKARAB�L�R OHA NE UZUN YAZDIM NEYSE BU KADARDI SLM NABER B)
            rotationSpeed -= deceleration * Time.deltaTime; // Decrease the speed
        }
        else
        {
            spinningFinished = true;
        }
    }
}
