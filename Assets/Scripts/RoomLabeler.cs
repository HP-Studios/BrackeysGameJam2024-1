using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider))]
public class RoomLabeler : MonoBehaviour
{
    [SerializeField] string roomName;
    [SerializeField] GameObject roomPrize;
    [SerializeField] TextMeshProUGUI roomText;
    [SerializeField] float returnMainDelay = 3f;
    [SerializeField] float textDelay = 3f;
    [SerializeField] bool isClickAble;
    void Start()
    {
        roomText.enabled = false;
        roomText.text = roomName;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isClickAble)
        {
            Invoke("DisplayRoomText", textDelay);
            Invoke("ReturnMainRoom", returnMainDelay);
        }
    }

    private void DisplayRoomText()
    {
        roomText.enabled = true;
    }

    private void OnMouseDown()
    {
        if (isClickAble)
        {
            roomText.enabled = true;
            Invoke("ReturnMainRoom", returnMainDelay);
        }
    }
    void ReturnMainRoom()
    {
        PlayerPrefs.SetInt("Nothing Room", 1);
        SceneManager.LoadScene(0);
    }
}
