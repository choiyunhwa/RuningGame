using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float speed = 5f; 
    public Transform playerTransform;
    private bool isMove = true;
    public float stoppingDistance = 2f;
    private RaycastHit hit;
    private float maxDistance = 1f;
    private Rigidbody rigid;
    public LayerMask layer;
    private void OnEnable()
    {
        rigid = GetComponent<Rigidbody>();
        layer = LayerMask.GetMask("Player");
    }

    private void Update()
    {
        if (playerTransform != null && isMove)
        {
            MoveToPlayer(hit);
        }
    }

    private void MoveToPlayer(RaycastHit hit)
    {

        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer > stoppingDistance)
        {

            if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, layer))
            {
                Debug.DrawLine(transform.position, hit.point, Color.red);
                rigid.constraints = RigidbodyConstraints.FreezeAll;
                isMove = false;
                Debug.Log("��ֹ� ����, �̵� ����");
            }
            else
            {
                Vector3 direction = (playerTransform.position - transform.position).normalized;
                transform.position += direction * speed * Time.deltaTime;
                Debug.Log("�÷��̾ ���� �̵� ��");
            }
        }
        else
        {
            rigid.constraints = RigidbodyConstraints.FreezeAll;
            Debug.Log("�÷��̾� ��ó�� ����, �̵� ����");
            isMove = false;
        }

    }
}
