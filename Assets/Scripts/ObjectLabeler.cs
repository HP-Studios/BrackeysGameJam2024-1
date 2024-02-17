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
        objectName = GetComponentInChildren<TextMeshPro>();
        objectName.text = objectLabel;
        objectName.enabled = false;
    }
    private void OnMouseOver()
    {
        objectName.enabled = true;
        Transform player = Camera.main.transform;
        objectName.transform.LookAt(2 * objectName.transform.position - player.position);
    }
    private void OnMouseExit()
    {
        objectName.enabled = false;
    }
}
