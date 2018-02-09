using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class InteractableChest : InteractableBase
{
    public Sprite OpenChestSprite;
    public ItemType ItemInChest;
    public int Amount;
    public string Text;
    public SaveLoadSystem saveLoadSystem;

    private bool m_IsOpen;
    private SpriteRenderer m_Renderer;

    void Awake()
    {
        m_Renderer = GetComponentInChildren<SpriteRenderer>();
    }

    public override void OnInteract( Character character )
    {
        if (DialogBox.IsVisible() == true)
        {
            SaveLoadSystem.control.SaveGame();
            character.Movement.SetFrozen(false, false, true);
            DialogBox.Hide();
        }
        else
        {
            character.Movement.SetFrozen(true, true, true);
            DialogBox.Show(Text);
        }
    }

    IEnumerator jolt()
    {
        yield return null;
        
    }
}

