using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float speed = 5f; 
    public Transform playerTransform;
    public float offsetRange = 2f;
    private bool isMove = false;
    void Start()
    {
        //if (playerTransform != null)
        //{
        //    MoveToPlayer();
        //}
    }

    private void Update()
    {
        if (playerTransform != null)
        {
            Vector3 randomOffset = new Vector3(
                Random.Range(-offsetRange, offsetRange),
                0,
                Random.Range(-offsetRange, offsetRange)
            );

            MoveToPlayer();
        }
    }


    private void MoveToPlayer()
    {
        if(!isMove)
        {
            Debug.Log("¿Ãµø!");
            Vector3 newPos = Vector3.MoveTowards(transform.position, playerTransform.transform.position, speed);
            transform.position = newPos;
            isMove = true;
        }
    }
}
