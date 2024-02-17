using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textDisplay;
    [SerializeField] private string[] sentences;
    [SerializeField] private float typingSpeed;
    [SerializeField] private float pauseBetweenSentences = 1f;
    private int index = 0;
    private bool isTyping = false;

    private void Start()
    {
        StartCoroutine(TypeSentence());
    }

    IEnumerator TypeSentence()
    {
        isTyping = true;
        textDisplay.text = ""; 

        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
        yield return new WaitForSeconds(pauseBetweenSentences); 

        if (index < sentences.Length - 1)
        {
            index++;
            StartCoroutine(TypeSentence());
        }
    }
}
