using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] TextMeshPro doorText;
    [SerializeField] float openSpeed = 2.0f;
    [SerializeField] float openAngle = 90f;
    [SerializeField] float openDistance = 2.0f;
    Quaternion openRotation;
    bool isPlayerInDistance;
    bool isOpen;

    private void Start()
    {
        doorText.enabled = false;
        openRotation = transform.rotation * Quaternion.Euler(0, openAngle, 0);
    }

    private void Update()
    {
        isPlayerInDistance = Vector3.Distance(transform.position, Camera.main.transform.position) < openDistance;

        if (isOpen && isPlayerInDistance)
        {
            OpenSlowly();
        }
        else if (isOpen)  // Close the door only when it's open
        {
            CloseSlowly();
        }
    }
    private void OnMouseOver()
    {
        if (!isOpen && isPlayerInDistance)
        {
            doorText.enabled = true;
        }
    }
    private void OnMouseExit()
    {
        if (!isOpen)
        {
            doorText.enabled = false;
        }
    }

    private void OnMouseDown()
    {
        if (isPlayerInDistance)
        {
            isOpen = !isOpen;  // Toggle the door state
            doorText.enabled = false;
        }
    }

    private void OpenSlowly()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, openRotation, Time.deltaTime * openSpeed);
    }

    private void CloseSlowly()
    {
        Quaternion closedRotation = Quaternion.Euler(0, 0, 0);  // Change this line to set the closed rotation
        transform.rotation = Quaternion.Lerp(transform.rotation, closedRotation, Time.deltaTime * openSpeed);
    }
}
