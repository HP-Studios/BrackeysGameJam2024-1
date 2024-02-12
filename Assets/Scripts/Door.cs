using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] TextMeshPro doorText;
    [SerializeField] float openSpeed = 2.0f;
    [SerializeField] Quaternion openRotation;
    bool isOpen;

    private void Start()
    {
        doorText.enabled = false;
        openRotation = transform.rotation * Quaternion.Euler(0, 90, 0);
    }

    private void OnMouseEnter()
    {
        if (!isOpen)
        {
            doorText.enabled = true;
        }
    }

    private void OnMouseExit()
    {
        doorText.enabled = false;
    }

    private void OnMouseDown()
    {
        isOpen = true;
        doorText.enabled = false;
    }

    private void OpenSlowly()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, openRotation, Time.deltaTime * openSpeed);
    }

    private void Update()
    {
        if (isOpen)
        {
            OpenSlowly();
        }
    }
}
