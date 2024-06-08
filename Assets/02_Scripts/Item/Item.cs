using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteraction
{    public void GetItemEffect(Collider other);
}

public class Item : MonoBehaviour, IInteraction
{
    [SerializeField] protected ItemDataSO itemData;
    [SerializeField] protected LayerMask layerMask;

    public void GetItemEffect(Collider other)
    {
        ItemEffect(other);
        //Destroy(gameObject);
    }

    public virtual void ItemEffect(Collider other){}
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ãæµ¹!");
        if (((1 << other.gameObject.layer) & layerMask) != 0)
        {
            GetItemEffect(other);
            
        }
    }
}
