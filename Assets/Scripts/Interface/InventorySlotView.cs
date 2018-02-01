using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            temp.name = "Slot" + i.ToString();
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
        UpdateSlotSelected();
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
            else
            {
                SetEmptySlotImage(i);
            }
        }
    }

    private void SetEmptySlotImage(int index)
    {
        string slotName = getSlotName(index);

        GameObject tempSlotObject = getImage(index);

        Image image = tempSlotObject.GetComponent<Image>();

        image.enabled = false;
    }

    private void UpdateSlotSelected()
    {
        int selectedSlotID = m_PocketModel.getSelectedID();

        string slotName;
        GameObject tempSlot;
        Image image;

        for (int i = 0; i <numberOfSlots; i++)
        {
            slotName = getSlotName(i);
            tempSlot = gameObject.transform.Find(slotName).gameObject;
            image = tempSlot.GetComponent<Image>();

            if (selectedSlotID == i)
            {
                image.color = Color.white;
            }
            else
            {
                image.color = Color.black;
            }
        }
    }

    private void SetSlotImage(PocketItemType itemType, int index)
    {
        string slotName = getSlotName(index);

        pocketItemData itemData = Database.pItem.FindItem(itemType);

        GameObject tempSlotObject = getImage(index);
        Image image = tempSlotObject.GetComponent<Image>();

        image.enabled = true;
        tempSlotObject = itemData.TypePrefab;
        Sprite sprite = tempSlotObject.GetComponentInChildren<SpriteRenderer>().sprite;

        image.sprite = sprite;
    }

    private GameObject getImage(int index)
    {
        string slotName = getSlotName(index);
        GameObject tempSlot = gameObject.transform.Find(slotName).gameObject;
        GameObject tempObject = tempSlot.transform.GetChild(0).gameObject;

        return tempObject;
    }

    private string getSlotName(int index)
    {
        string slotName = "Slot" + index.ToString();

        return slotName;
    }
}
