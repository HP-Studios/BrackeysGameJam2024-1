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
            timer.text = "Your Time:\n" + TimeSpan.FromSeconds(numOfSecs).Hours + "h " + TimeSpan.FromSeconds(numOfSecs).Minutes + "m " + TimeSpan.FromSeconds(numOfSecs).Seconds + "s.";
        }
    
    }

    private void OnMouseDown()
    {
        if (isPlayerInDistance)
        {
            isDone = true;
            finalBox.SetActive(true);
            StartCoroutine(WaitForFinal());
        }
    }

    IEnumerator WaitForFinal()
    {
        yield return new WaitForSeconds(3.5f);
        movementScript.enabled = false;
        movementScript.walkSFX.Stop();
        image.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        goodbyeText.SetActive(true);
        yield return new WaitForSeconds(14);
        goodbyeText.SetActive(false);
    }
}
