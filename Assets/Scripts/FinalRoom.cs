using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class FinalRoom : MonoBehaviour
{
    private float numOfSecs;
    private bool isDone;
    [SerializeField] TextMeshPro timer;
    bool isPlayerInDistance;
    [SerializeField] float playerDistance = 4.0f;

    [SerializeField] GameObject finalBox;
    [SerializeField] PlayerMovement movementScript;

    [SerializeField] GameObject image;
    [SerializeField] GameObject goodbyeText;

    [SerializeField] GameObject inputFieldImage;
    [SerializeField] GameObject inputFieldButton;
    [SerializeField] GameObject inputField;

        
    private void Start()
    {
        isDone = false;
        numOfSecs = PlayerPrefs.GetFloat("Timer");
    }

    private void Update()
    {
        isPlayerInDistance = Vector3.Distance(transform.position, Camera.main.transform.position) < playerDistance;
        if (!isDone)
        {
            numOfSecs += Time.deltaTime;
            PlayerPrefs.SetFloat("Timer", numOfSecs);
            int hour = (int)numOfSecs / 3600;
            int remainingSeconds = (int)numOfSecs % 3600;
            int minute = remainingSeconds / 60;
            int seconds = remainingSeconds % 60;
            string tempText = hour + "h " + minute + "m " + seconds + "s.";
            timer.text = "Your Time:\n" + tempText;
        }
    
    }

    private void OnMouseDown()
    {
        if (isPlayerInDistance)
        {
            isDone = true;
            StartCoroutine(WaitForFinal());
        }
    }

    IEnumerator WaitForFinal()
    {
        yield return new WaitForSeconds(3.5f);
        movementScript.enabled = false;
        finalBox.SetActive(true);
        movementScript.walkSFX.Stop();
        image.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        goodbyeText.SetActive(true);
        yield return new WaitForSeconds(10);
        inputField.SetActive(true);
        inputFieldButton.SetActive(true);
        inputFieldImage.SetActive(true);
        goodbyeText.SetActive(false);
        image.SetActive(false);
        UnlockMouse(); 
    }
    public void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
