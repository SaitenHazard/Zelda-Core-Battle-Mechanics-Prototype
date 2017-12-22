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
        ItemData data = Database.Item.FindItem(DropItemType);

        if (data==null || data.Prefab == null)
        {

            return;
        }

        GameObject newLoot = (GameObject)Instantiate(data.Prefab, transform.position, Quaternion.identity);
        Debug.Log("in");

    }
}
