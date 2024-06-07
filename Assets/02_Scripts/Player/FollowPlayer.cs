using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float speed = 5f; 

    private Transform playerTransform; 
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player"); //Fix
        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    void Update()
    {
        if (playerTransform != null)
        {
            Vector3 targetPosition = playerTransform.position;
            Vector3 newPosition = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
            transform.position = newPosition;
        }
    }

}
