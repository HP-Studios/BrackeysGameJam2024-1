using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] TextMeshPro buttonText;
    [SerializeField] Animation pressAnim;
    //[SerializeField] private GameObject button;
    //private bool canPressButtonAgain;
    //private bool buttonAnimAll; //To control the 4 frames
    bool buttonPressed;
    //private bool buttonAnimation;
    private void Start()
    {
        //canPressButtonAgain = true;
        //buttonAnimAll = false;
        //buttonPressed = false;
        //buttonText.enabled = false;
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
        //    canPressButtonAgain = false;
        //}
        if (!buttonPressed)
        {
            pressAnim.Play();
            buttonText.enabled = false;
            buttonPressed = true;
        }
    }
}
