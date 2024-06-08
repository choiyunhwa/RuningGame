using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : Item
{
    [SerializeField] private int value;
    [SerializeField] private GameObject obj;
    [SerializeField] private bool inequality;
    public override void ItemEffect(Collider other)
    {
        if(inequality)
        {
            IncreasePlayerList(other);
        }
        else
        {
            DecreasePlayerList(other);
        }
    }

    private void IncreasePlayerList(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player pl))
        {
            pl.playerList.Add(obj);
                
            for (int i = 0; i < value; i++)
            {
                //float randomAngle = Random.Range(Mathf.PI / 2, 3 * Mathf.PI / 2);
                //Vector3 randomDir = new Vector3(Mathf.Cos(randomAngle), 0, -Mathf.Sin(randomAngle)) * 5f;
                Vector3 randomPoint = Random.insideUnitSphere;

                if (randomPoint.z > 0)
                {
                    randomPoint.z = -randomPoint.z;
                }
                randomPoint.y = 0;
                randomPoint *= 5;
                Vector3 pos = pl.transform.position + randomPoint;
                GameObject ob = Instantiate(obj, pos,Quaternion.identity);
                ob.transform.SetParent(pl.playerGroup);
                FollowPlayer follow = ob.AddComponent<FollowPlayer>();
                follow.playerTransform = pl.transform;
            }
        }
    }

    private void DecreasePlayerList(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player pl))
        {
            if (pl.playerList.Count > 0)
            {
                int indexToRemove = Mathf.Clamp(value, 0, pl.playerList.Count - 1);
                pl.playerList.RemoveAt(indexToRemove);
            }

            Transform playerTransform = pl.gameObject.transform;
            int childrenToRemove = Mathf.Min(value, playerTransform.childCount);

            for (int i = 0; i < childrenToRemove; i++)
            {
                Destroy(playerTransform.GetChild(0).gameObject);
            }

        }
    }
}
