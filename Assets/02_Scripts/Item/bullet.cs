using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    private AttackSO attackData;
    
    private void OnTriggerEnter(Collider other)
    {
        if(((1<<other.gameObject.layer) & layerMask) != 0)
        {
            Vector3 destroyPosition = other.ClosestPoint(transform.position);
            DestroyBullet();
        }
        else if (((1 << other.gameObject.layer) & attackData.terget.value) != 0)
        {

        }
    }

    private void DestroyBullet()
    {
        //TODO ObjectPool
        gameObject.SetActive(false);
    }
}
