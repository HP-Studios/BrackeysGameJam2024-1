using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyPrizes : MonoBehaviour
{
    [SerializeField] GameObject NothingRoom;
    [SerializeField] GameObject DoorRoom;
    private void Awake()
    {
        if(PlayerPrefs.HasKey("Nothing Behind The Door"))
        {
            if(PlayerPrefs.GetInt("Nothing Behind The Door") == 1)
            {
                NothingRoom.SetActive(true);
            }
        }
        else
        {
            NothingRoom.SetActive(false);
        }

        if (PlayerPrefs.HasKey("Door Behind The Door"))
        {
            if (PlayerPrefs.GetInt("Door Behind The Door") == 1)
            {
                DoorRoom.SetActive(true);
            }
        }
        else
        {
            DoorRoom.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
