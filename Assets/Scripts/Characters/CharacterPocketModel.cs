using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPocketModel : MonoBehaviour
{
    public static CharacterPocketModel instance;
    public static int maxInventorySize = 3;
    private int selectedSlotID = -1;
    private int countNumberOfItems = 0;

    private PocketItemType [] PocketItemArray = new PocketItemType[maxInventorySize];

    public void Start()
    {
        if (SaveLoadSystem.control.doLoadGame == true)
                setSaveData();

        instance = this;
    }

    public void AddItem(PocketItemType itemType, int amount)
    {
        for (int i = 0; i < maxInventorySize; i++)
        {
            AddItem(itemType);
        }
    }

    public void setSaveData()
    {
        PocketItemArray = SaveLoadSystem.control.getLoadData();

        for (int i = 0; i < maxInventorySize; i++)
        {
            if (PocketItemArray[i] != PocketItemType.Null)
            {
                countNumberOfItems++;
                Debug.Log("out");
            }
        }

        changeSelectedSlotID(true);
    }

    public PocketItemType[] getEntireInventory()
    {
        return PocketItemArray;
    }

    public int getSelectedID()
    {
        return selectedSlotID;
    }

    public PocketItemType GetSelectedItem()
    {
        if (selectedSlotID == -1) return PocketItemType.Null;

        return PocketItemArray[selectedSlotID];
    }

    public void changeSelectedSlotID(bool forward)
    {
        Debug.Log("out");

        if (countNumberOfItems == 0)
        {
            selectedSlotID = -1;
            return;
        }

        if (forward)
        {
            if (selectedSlotID == maxInventorySize - 1)
                selectedSlotID = 0;
            else
                selectedSlotID++;

            if (PocketItemArray[selectedSlotID] == PocketItemType.Null)
            {
                changeSelectedSlotID(true);
                Debug.Log("out");
            }
        }
        else
        {
            if (selectedSlotID == 0)
                selectedSlotID = maxInventorySize - 1;
            else
                selectedSlotID--;

            if (PocketItemArray[selectedSlotID] == PocketItemType.Null)
                changeSelectedSlotID(false);
        }
    }

    public int GetNumberOfItems()
    {
        return countNumberOfItems;
    }

    public PocketItemType getInventoryItem(int index)
    {
        return PocketItemArray[index];
    }

    public void AddItem(PocketItemType itemType)
    {
        int emptyIndex = findFirstEmptyIndex();

        if (emptyIndex == -1)
        {
            return;
        }

        PocketItemArray[emptyIndex] = itemType;
        countNumberOfItems++;

        if (countNumberOfItems == 1) changeSelectedSlotID(true);
    }

    public void RemoveSelectedItem()
    {
        RemoveItem(selectedSlotID);
    }

    private void RemoveItem(int index)
    {
        PocketItemArray[index] = PocketItemType.Null;
        countNumberOfItems--;

        changeSelectedSlotID(true);
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