using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float speed = 5f; 
    public Transform playerTransform;
    public float offsetRange = 2f;
    private bool isMove = false;
    private Rigidbody rigid;
    public float stoppingDistance = 2f;

    private void OnEnable()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (playerTransform != null)
        {
            MoveToPlayer();
        }
    }

    private void MoveToPlayer()
    {
        if(!isMove)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

            if (distanceToPlayer > stoppingDistance)
            {
                Vector3 direction = (playerTransform.position - transform.position).normalized;
                transform.position += direction * speed * Time.deltaTime;
            }
            else
            {
                rigid.constraints = RigidbodyConstraints.FreezeAll;
                isMove = false;
            }
        }
    }
}
