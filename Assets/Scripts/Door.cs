using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] TextMeshPro doorText;
    [SerializeField] float openSpeed = 2.0f;
    [SerializeField] float openAngle = 90f;
    [SerializeField] float playerDistance = 2.0f;
    [SerializeField] RandomWheelDecider buttonScript = null;
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
        isPlayerInDistance = Vector3.Distance(transform.position, Camera.main.transform.position) < playerDistance;

        if ((isOpen || !isLocked) && isPlayerInDistance)
        {
            OpenSlowly();
        }
        else if (isOpen || !isLocked) 
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
        if (buttonScript)
        {
            if (isPlayerInDistance && buttonScript.SpinningFinished)
            {
                isOpen = !isOpen;
                doorText.enabled = false;
            }
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
