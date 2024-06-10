using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public List<GameObject> playerList = new List<GameObject>();
    public Transform playerGroup;

    private HealthBar healber;

    private void Awake()
    {
        healber = GetComponent<HealthBar>();
    }

    private void Start()
    {
        healber.OnDamage += FollowPlayerDamage;
    }
    private void FollowPlayerDamage()
    {
        if(playerList.Count > 0) 
        {
            Debug.Log("Follow Player Die");
            playerList.RemoveAt(0);
            Destroy(playerGroup.GetChild(0));
        }
    }
}
