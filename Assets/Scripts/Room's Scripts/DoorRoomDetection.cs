using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(BoxCollider))]
public class DoorRoomDetection : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI failText;
    [SerializeField] float restartDelay = 2f;
    [SerializeField] bool passable;

    private void Start()
    {
        failText.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !passable)
        {
            failText.enabled = true;
            Invoke("RestartLevel", restartDelay);
        }
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
