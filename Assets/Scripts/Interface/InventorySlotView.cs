using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlotView : MonoBehaviour {
    public float slotWidth = 120f;
    public GameObject slotPrefab;

    public CharacterPocketModel m_PocketModel;

    private int numberOfSlots;

    private void Awake()
    {
        numberOfSlots = m_PocketModel.GetMaxSize();
    }

    void Start ()
    {
        CreateQuickInventorySlots();
    }
	
    void CreateQuickInventorySlots()
    {
        setInventoryHolderSize();
        createInventorySlots();
    }

    void createInventorySlots()
    {
        for ( int i = 0; i < numberOfSlots; i++)
        {
            float tempWidth = slotWidth * i;

            GameObject temp = Instantiate(slotPrefab);
            temp.name = "Slot" + (i + 1).ToString();
            //temp.transform.parent = gameObject.transform;
            temp.transform.SetParent(gameObject.transform);

            RectTransform tempRect = temp.GetComponent<RectTransform>();
            //temp.transform.localScale = new Vector3(1f, 1f, 1f);
            //temp.transform.localPosition = new Vector2(i * slotWidth, 0f);
            tempRect.localScale = new Vector3(1f, 1f, 1f);
            tempRect.anchorMin = new Vector2(0f, 0);
            tempRect.anchorMax = new Vector2(0f, 0f);
            tempRect.pivot = new Vector2(0f, 0f);

            tempRect.anchoredPosition = new Vector2(tempWidth, 0f);
            //Debug.Log(tempWidth);
        }
    }

    void setInventoryHolderSize()
    {
        (gameObject.GetComponent<RectTransform>()).sizeDelta = new Vector2(slotWidth * numberOfSlots, slotWidth);
    }

	void Update ()
    {
        UpdateQuickInventoryView();
    }

    void UpdateQuickInventoryView()
    {
        for ( int i = 0; i < numberOfSlots; i++)
        {
            PocketItemType item = m_PocketModel.getInventoryItem(i);

            if (item != PocketItemType.Null)
            {
                SetSlotImage(item, i);
            }
        }
    }

    private void SetSlotImage(PocketItemType itemType, int index)
    {
        string slotName = "Slot" + index.ToString();

        pocketItemData itemData = Database.pItem.FindItem(itemType);

        GameObject tempSlot = gameObject.transform.Find(slotName).gameObject;
        GameObject tempImage = tempSlot.transform.Find("Visuals").gameObject;

        tempImage.GetComponent<SpriteRenderer>().sprite = itemData.Prefab.GetComponent<SpriteRenderer>().sprite;
    }
}
