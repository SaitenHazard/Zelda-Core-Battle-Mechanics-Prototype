using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlotCreator : MonoBehaviour {
    public int numberOfQuickSlots;
    public float slotWidth = 120f;
    public GameObject slotPrefab;
     
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
        for ( int i = 0; i < numberOfQuickSlots; i++)
        {
            float tempWidth = slotWidth * i;

            GameObject temp = Instantiate(slotPrefab);
            temp.name = "Slot" + (i + 1).ToString();
            temp.transform.parent = gameObject.transform;

            RectTransform tempRect = temp.GetComponent<RectTransform>();
            //temp.transform.localScale = new Vector3(1f, 1f, 1f);
            //temp.transform.localPosition = new Vector2(i * slotWidth, 0f);
            tempRect.localScale = new Vector3(1f, 1f, 1f);
            tempRect.anchorMin = new Vector2(0f, 0);
            tempRect.anchorMax = new Vector2(0f, 0f);
            tempRect.pivot = new Vector2(0f, 0f);

            tempRect.anchoredPosition = new Vector2(tempWidth, 0f);
            Debug.Log(tempWidth);
        }
    }

    void setInventoryHolderSize()
    {
        (gameObject.GetComponent<RectTransform>()).sizeDelta = new Vector2(slotWidth * numberOfQuickSlots, slotWidth);
    }

	void Update ()
    {
		
	}
}
