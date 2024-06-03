using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteraction
{    public void GetItemEffect();
}

public class Item : MonoBehaviour, IInteraction
{
    [SerializeField] protected ItemDataSO itemData;
    [SerializeField] protected LayerMask layerMask;

    public void GetItemEffect()
    {
        ItemEffect();
        Destroy(gameObject);
    }

    public virtual void ItemEffect(){}
    

    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & layerMask) != 0)
        {
            GetItemEffect();
        }
    }
}
