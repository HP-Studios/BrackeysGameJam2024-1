using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyPrizes : MonoBehaviour
{
    [SerializeField] GameObject NothingRoom;
    private void Awake()
    {
        if(PlayerPrefs.HasKey("Nothing Room"))
        {
            if(PlayerPrefs.GetInt("Nothing Room") == 1)
            {
                NothingRoom.SetActive(true);
            }
        }
        else
        {
            NothingRoom.SetActive(false);

        }
    }
}
