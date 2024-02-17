using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRoomWin : MonoBehaviour
{
    public int botLeftToKill = 6;
    [SerializeField] GameObject box;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(botLeftToKill == 0)
        {
            box.SetActive(true);
        }
    }
}
