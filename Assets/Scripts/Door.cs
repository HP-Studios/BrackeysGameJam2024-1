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
    [SerializeField] RandomWheelDecider buttonScript;
    [SerializeField] bool isLocked = true;
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
        else if (isOpen) 
        {
            KeepDoorOpenSequance();
        }
    }
    private void OnMouseOver()
    {
        if (!isOpen && isPlayerInDistance)
        {
            doorText.enabled = true;
        }
        else
        {
            doorText.enabled = false;
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
        if (isPlayerInDistance && buttonScript.SpinningFinished)
        {
            isOpen = !isOpen;
            doorText.enabled = false;
        }
        if (!isLocked && isPlayerInDistance)
        {
            isOpen = !isOpen;
            doorText.enabled = false;
        }
    }

    private void OpenSlowly()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, openRotation, Time.deltaTime * openSpeed);
    }

    private void KeepDoorOpenSequance()
    {
        Quaternion closedRotation = Quaternion.Euler(0, 0, 0); 
        transform.rotation = Quaternion.Lerp(transform.rotation, closedRotation, Time.deltaTime * openSpeed);
    }
}
