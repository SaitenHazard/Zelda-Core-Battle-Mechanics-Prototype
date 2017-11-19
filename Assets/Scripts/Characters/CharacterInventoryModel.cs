﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterInventoryModel : MonoBehaviour
{
    private CharacterMovementModel m_MovementModel;

    Dictionary<ItemType, int> m_Items = new Dictionary<ItemType, int>();

    public void AddItem (ItemType itemType)
    {
        AddItem(itemType, 1);
    }

    public void AddItem(ItemType itemType, int amount)
    {
        if(m_Items.ContainsKey(itemType) == true)
        {
            m_Items[itemType] += amount;
        }
        else
        {
            m_Items.Add(itemType, amount);
        }
    }
}
