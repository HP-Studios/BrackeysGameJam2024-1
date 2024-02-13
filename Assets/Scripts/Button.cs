using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] TextMeshPro buttonText;
    [SerializeField] private Animator pressAnim = null;

    bool buttonPressed;
    private void Start()
    {

        buttonPressed = false;
        buttonText.enabled = false;
    }

    private void OnMouseOver()
    {
        buttonText.enabled = true;
    }

    private void OnMouseExit()
    {
        buttonText.enabled = false;
    }

    private void OnMouseDown()
    {
        if (!buttonPressed)
        {
            pressAnim.SetTrigger("isPressed");
            buttonText.enabled = false;
            buttonPressed = true;
        }
    }
}
