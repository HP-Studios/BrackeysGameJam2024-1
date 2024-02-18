using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyPrizes : MonoBehaviour
{
    [SerializeField] GameObject NothingRoom;
    [SerializeField] GameObject DoorRoom;
    [SerializeField] GameObject GymRoom;
    [SerializeField] GameObject BallRoom;
    [SerializeField] GameObject GalaxyRoom;
    [SerializeField] GameObject GeometryRoom;
    [SerializeField] GameObject MinimalistRoom;
    [SerializeField] GameObject MazeRoom;
    [SerializeField] GameObject KillerRoom;
    private void Awake()
    {
        #region Nothing Room
        if (PlayerPrefs.HasKey("Nothing Behind The Door"))
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
        #endregion
        #region Door Room
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
        #endregion
        #region Gym Room
        if (PlayerPrefs.HasKey("Gym Behind The Door"))
        {
            if (PlayerPrefs.GetInt("Gym Behind The Door") == 1)
            {
                GymRoom.SetActive(true);
            }
        }
        else
        {
            GymRoom.SetActive(false);
        }
        #endregion
        #region Ball Room
        if (PlayerPrefs.HasKey("Ball Behind The Door"))
        {
            if (PlayerPrefs.GetInt("Ball Behind The Door") == 1)
            {
                BallRoom.SetActive(true);
            }
        }
        else
        {
            BallRoom.SetActive(false);
        }
        #endregion
        #region Galaxy Room
        if (PlayerPrefs.HasKey("Galaxy Behind The Door"))
        {
            if (PlayerPrefs.GetInt("Galaxy Behind The Door") == 1)
            {
                GalaxyRoom.SetActive(true);
            }
        }
        else
        {
            GalaxyRoom.SetActive(false);
        }
        #endregion
        #region Geometry Room
        if (PlayerPrefs.HasKey("Geometry Behind The Door"))
        {
            if (PlayerPrefs.GetInt("Geometry Behind The Door") == 1)
            {
                GeometryRoom.SetActive(true);
            }
        }
        else
        {
            GeometryRoom.SetActive(false);
        }
        #endregion
        #region Minimalist Room
        if (PlayerPrefs.HasKey("Minimalist Behind The Door"))
        {
            if (PlayerPrefs.GetInt("Minimalist Behind The Door") == 1)
            {
                MinimalistRoom.SetActive(true);
            }
        }
        else
        {
            MinimalistRoom.SetActive(false);
        }
        #endregion
        #region Treasure  Room
        if (PlayerPrefs.HasKey("Treasure Behind The Door"))
        {
            if (PlayerPrefs.GetInt("Treasure Behind The Door") == 1)
            {
                MazeRoom.SetActive(true);
            }
        }
        else
        {
            MazeRoom.SetActive(false);
        }
        #endregion
        #region Killer Room
        if (PlayerPrefs.HasKey("Killer Behind The Door"))
        {
            if (PlayerPrefs.GetInt("Killer Behind The Door") == 1)
            {
                KillerRoom.SetActive(true);
            }
        }
        else
        {
            KillerRoom.SetActive(false);
        }
        #endregion
    }

}
