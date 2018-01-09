using UnityEngine;
using System.Collections;

public class DropItemOnDestroy : MonoBehaviour 
{
    public ItemType DropItemType;
    //public int Amount;
    //public Transform DropPosition;

    [Range( 0f, 1f )]
    public float Probability;

    void OnLootDrop()
    {
        float randomValue = Random.Range(0f, 1f);

        if (randomValue > Probability)
        {
            return;
        }

        ItemData data = Database.Item.FindItem(DropItemType);

        if (data == null || data.Prefab == null)
        {
            Debug.Log("Last Return");

            return;
        }

        //Transform dropPosition = DropPosition;

        //if (dropPosition == null)
        //{
        //    dropPosition = transform;
        //}

        GameObject newLoot = (GameObject)Instantiate(data.Prefab, transform.position, Quaternion.identity);
    }
}
