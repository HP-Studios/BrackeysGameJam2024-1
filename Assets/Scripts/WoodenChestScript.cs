using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WoodenChestScript : MonoBehaviour
{
    [SerializeField] private TextMeshPro chestClose;
    [SerializeField] private TextMeshPro chestOpen;

    [SerializeField] GameObject chestTop;
    private void OnMouseDown()
    {
        chestTop.transform.rotation = Quaternion.Euler(-90, 0, 0);
    }

}