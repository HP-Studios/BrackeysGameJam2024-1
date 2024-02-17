using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WoodenChestScript : MonoBehaviour
{
    [SerializeField] private TextMeshPro chestClose;
    [SerializeField] private TextMeshPro chestOpen;

    [SerializeField] private GameObject box;

    private void Awake()
    {
        chestOpen.enabled = false;

    }

    private void OnMouseDown()
    {
        StartCoroutine(EndTheGame());
    }

    IEnumerator EndTheGame()
    {
        //2 saniyelik animasyon oynat
        yield return new WaitForSeconds(2);
        chestClose.enabled = false;
        chestOpen.enabled = true;
        yield return new WaitForSeconds(2);
        box.SetActive(true);
    }

}