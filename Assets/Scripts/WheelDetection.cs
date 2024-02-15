using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WheelDetection : MonoBehaviour
{
    [SerializeField] private RandomWheelDecider wheelScript;
    private void OnTriggerStay(Collider other)
    {
        if (wheelScript.SpinningFinished)
        {
            string objTag = other.tag;
            switch (objTag)
            {
                case "Purple":
                    Debug.Log("Purple");
                    break;
                case "Yellow":
                    Debug.Log("Yellow");
                    break;
                case "Red":
                    Debug.Log("Red");
                    break;
                case "Blue":
                    Debug.Log("Blue");
                    break;
                case "Orange":
                    Debug.Log("Orange");
                    break;
                case "Green":
                    Debug.Log("Green");
                    break;
                default:
                    Debug.Log("Error");
                    break;
            }
            wheelScript.SpinningReset();
        }
    }
}
