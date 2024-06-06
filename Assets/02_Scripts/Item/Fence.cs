using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : Item
{
    [SerializeField] private int value;
    [SerializeField] private GameObject obj;
    [SerializeField] private bool inequality;
    public override void ItemEffect()
    {
        if(inequality)
        {
            Debug.Log("»ý¼º!");
            for(int i = 0; i < value; i++)
            {
                Instantiate(obj);
            }
        }
        else
        {

        }
    }
}
