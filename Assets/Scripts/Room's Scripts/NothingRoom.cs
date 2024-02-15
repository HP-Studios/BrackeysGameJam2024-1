using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NothingRoom : MonoBehaviour
{
    [SerializeField] GameObject audio;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audio.SetActive(false);
        }
    }
}
