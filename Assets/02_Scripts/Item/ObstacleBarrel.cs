using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectStat
{
    public int maxValue;
    public AttackSO attackSO;
}
public class ObstacleBarrel : Item
{
    [SerializeField] private ObjectStat objectStat;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameObject dropItem;

    private int currentValue;
    [SerializeField] private int maxValue;

    private void Awake()
    {
        currentValue = maxValue;
    }

    public override void ItemEffect(Collider other)
    {
        base.ItemEffect(other);

        //플레이어 공격 데미지

        if(currentValue > 0)
        {
            currentValue --;
            UpdateText();
        }
        
        if(currentValue <= 0)
        {
            Instantiate(dropItem, this.transform);
            Destroy(this.gameObject);
        }
    }

    private void UpdateText()
    {
        if(text != null)
        {
            text.text = currentValue.ToString();
        }
    }
}
