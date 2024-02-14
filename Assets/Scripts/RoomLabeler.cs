using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomLabeler : MonoBehaviour
{
    [SerializeField] string roomName;
    [SerializeField] GameObject roomPrize;
    [SerializeField] TextMeshProUGUI roomText;
    void Start()
    {
        roomText.enabled = false;
        roomText.text = roomName;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            roomText.enabled = true;
            ReturnMainRoom();
        }
    }

    private static void ReturnMainRoom()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
