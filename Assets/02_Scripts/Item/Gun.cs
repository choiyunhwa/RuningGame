using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Item
{
    private int value = 3;
    public override void ItemEffect(Collider other)
    {
        base.ItemEffect(other);
        if(other.TryGetComponent<ShootingScript>(out ShootingScript pl))
        {
            Debug.Log("ÃÑ È¹µæ!");
            pl.bulletSpeed += value;
            Destroy(this.gameObject);
        }
    }

}
