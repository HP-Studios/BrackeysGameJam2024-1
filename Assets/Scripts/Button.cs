using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] TextMeshPro buttonText;
    [SerializeField] private Animator pressAnim = null;
    [SerializeField] float playerDistance = 4.0f;
    bool isPlayerInDistance;
    bool buttonPressed;

    private void Update()
    {
        isPlayerInDistance = Vector3.Distance(transform.position, Camera.main.transform.position) < playerDistance;
    }
    private void Start()
    {

        buttonPressed = false;
        buttonText.enabled = false;
    }

    private void OnMouseOver()
    {
        if (isPlayerInDistance)
        {
            buttonText.enabled = true;
        }
    }

    private void OnMouseExit()
    {
        buttonText.enabled = false;
    }

    private void OnMouseDown()
    {
        if (!buttonPressed && isPlayerInDistance)
        {
            pressAnim.SetTrigger("isPressed");
            buttonText.enabled = false;
            buttonPressed = true;
        }
    }
}
