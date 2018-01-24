using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPocketModel : MonoBehaviour
{
    public static int maxInventorySize = 3;

    private PocketItemType [] PocketItemArray = new PocketItemType[maxInventorySize];

    public void AddItem(PocketItemType itemType, int amount)
    {
        for (int i = 0; i < maxInventorySize; i++)
        {
            AddItem(itemType);
        }
    }

    public PocketItemType getInventoryItem(int index)
    {
        return PocketItemArray[index];
    }

    public void AddItem(PocketItemType itemType)
    {
        int emptyIndex = findFirstEmptyIndex();

        if(emptyIndex == -1)
        {
            return;
        }

        PocketItemArray[emptyIndex] = itemType;
    }

    public int GetMaxSize()
    {
        return maxInventorySize;
    }

    private int findFirstEmptyIndex()
    {
        for ( int i = 0; i < maxInventorySize; i++)
        {
            if (PocketItemArray[i] == PocketItemType.Null)
            {
                return i;
            }
                
        }

        return -1;
    }
}