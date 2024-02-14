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
    [SerializeField] float playerDistance = 4.0f;
    bool isPlayerInDistance;
    void Start()
    {
        roomText.enabled = false;
    }
    private void Update()
    {
        isPlayerInDistance = Vector3.Distance(transform.position, Camera.main.transform.position) < playerDistance;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isClickAble)
        {
            roomText.text = roomName;
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
        if (isClickAble && isPlayerInDistance)
        {
            roomText.text = roomName;
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
