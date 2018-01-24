using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PocketItemDatabase : ScriptableObject
{
    public List<pocketItemData> Data;

    public pocketItemData FindItem(PocketItemType itemType)
    {
        for (int i = 0; i < Data.Count; ++i)
        {
            if (Data[i].Type == itemType)
            {
                return Data[i];
            }
        }

        return null;
    }
}

[System.Serializable]
public class pocketItemData
{
    //public enum PickupAnimation
    //{
    //    None,
    //    OneHanded,
    //    TwoHanded,
    //}

    public PocketItemType Type;
    public GameObject Prefab;
}