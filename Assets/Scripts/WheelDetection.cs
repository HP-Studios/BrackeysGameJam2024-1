using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WheelDetection : MonoBehaviour
{
    [SerializeField] RandomWheelDecider wheelScript;
    [SerializeField] Light doorLight;
    private void OnTriggerStay(Collider other)
    {
        if (wheelScript.SpinningFinished)
        {
            string objTag = other.tag;
            switch (objTag)
            {
                case "Purple":
                    doorLight.color = new Color(0.5f, 0, 0.5f);
                    break;
                case "Yellow":
                    doorLight.color = Color.yellow;
                    break;
                case "Red":
                    doorLight.color = Color.red;
                    break;
                case "Blue":
                    doorLight.color = Color.blue;
                    break;
                case "Orange":
                    doorLight.color = new Color(1f, 0.5418492f, 0f);
                    break;
                case "Green":
                    doorLight.color = Color.green;
                    break;
                default:
                    Debug.Log("Error");
                    break;
            }
        }
    }
}
