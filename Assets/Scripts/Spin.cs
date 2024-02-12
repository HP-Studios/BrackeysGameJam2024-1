using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    [SerializeField] private GameObject wheel;
    private float countdown;
    private float rotationSpeed = 50f; // Start with high rotation speed
    private float deceleration = 5; // Deceleration rate

    void Awake()
    {
        countdown = Random.Range(8, 10);
    }

    void Update()
    {
        if (countdown > 0)
        {
            rotationSpeed -= deceleration * Time.deltaTime; // Decrease speed over time
            if (rotationSpeed < 0) rotationSpeed = 0; // Prevent speed from becoming negative
            wheel.transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0); // Apply rotation
            countdown -= Time.deltaTime;
        }
    }

}
