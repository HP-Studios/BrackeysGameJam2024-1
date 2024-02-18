using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WoodenChestScript : MonoBehaviour
{
    [SerializeField] private TextMeshPro chestClose;
    [SerializeField] private TextMeshPro chestOpen;
    [SerializeField] Animator chestAnimator;
    [SerializeField] private GameObject box;

    private void Awake()
    {
        chestAnimator = GetComponentInChildren<Animator>();
        chestOpen.enabled = false;

    }

    private void OnMouseDown()
    {
        StartCoroutine(EndTheGame());
    }

    IEnumerator EndTheGame()
    {
        chestAnimator.SetBool("isOpen", true);
        yield return new WaitForSeconds(2);
        chestClose.enabled = false;
        chestOpen.enabled = true;
        yield return new WaitForSeconds(2);
        box.SetActive(true);
    }

}