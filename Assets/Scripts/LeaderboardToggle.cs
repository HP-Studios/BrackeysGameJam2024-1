using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardToggle : MonoBehaviour
{
    private bool isGamePaused;
    private void Start()
    {
        isGamePaused = false;
    }
    [SerializeField] Canvas canvas;
    public void TogglePause()
    {

        isGamePaused = !isGamePaused;

        if (isGamePaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }
    public void PauseGame()
    {

        canvas.enabled = true;

    }

    public void ResumeGame()
    {
        canvas.enabled = false;

    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
    }
}
