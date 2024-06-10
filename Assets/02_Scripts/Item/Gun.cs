using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Item
{
    public AudioSource audioSource;

    private int value = 3;
    public override void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public override void ItemEffect(Collider other)
    {
        base.ItemEffect(other);
        if(other.TryGetComponent<ShootingScript>(out ShootingScript pl))
        {
            Debug.Log("ÃÑ È¹µæ!");
            audioSource.Play();
            pl.bulletSpeed += value;
            Destroy(this.gameObject);
        }
    }

}
