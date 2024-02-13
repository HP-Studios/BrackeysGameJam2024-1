using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] TextMeshPro buttonText;
    private void Start()
    {
        buttonText.enabled = false;
    }

    private void OnMouseEnter()
    {
        buttonText.enabled = true;
    }

    private void OnMouseExit()
    {
        buttonText.enabled = false;
    }

    private void OnMouseDown()
    {
        buttonText.enabled = false;
    }
}
