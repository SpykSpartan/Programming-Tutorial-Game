using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager playermanager;

    public GameObject player;
    
    void Awake()
    {
        if (playermanager == null)
        {
            playermanager = this;
        }
    }
}
