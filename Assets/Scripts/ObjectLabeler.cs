using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectLabeler : MonoBehaviour
{
    [SerializeField] string objectLabel;
    TextMeshPro objectName;
    private void Start()
    {
        objectName = GetComponent<TextMeshPro>();
        objectName.text = objectLabel;
        objectName.enabled = false;
    }
    private void OnMouseOver()
    {
        objectName.enabled = true;
    }
    private void OnMouseExit()
    {
        objectName.enabled = false;
    }
}
