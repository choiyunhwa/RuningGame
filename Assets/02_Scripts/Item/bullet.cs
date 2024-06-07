using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    private AttackSO attackData;
    public int damage =0;


    public void OnTriggerEnter(Collider other)
    {
        if(((1<<other.gameObject.layer) & layerMask) != 0)
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.OnHit(damage);
            Vector3 destroyPosition = other.ClosestPoint(transform.position);
            DestroyBullet();
            }
        }
        //else if (((1 << other.gameObject.layer) & attackData.terget.value) != 0)
        //{

        //}
    }

    public void DestroyBullet()
    {
        //TODO ObjectPool
        gameObject.SetActive(false);
    }
}
