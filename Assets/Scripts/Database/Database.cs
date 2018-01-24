using UnityEngine;
using System.Collections;

public class Database
{
    private static ItemDatabase m_ItemDatabase;
    public static ItemDatabase Item
    {
        get
        {
            if (m_ItemDatabase == null)
            {
                m_ItemDatabase = Resources.Load<ItemDatabase>("Databases/ItemDatabase");
            }

            return m_ItemDatabase;
        }
    }

    private static PocketItemDatabase m_PocketItem;
    public static PocketItemDatabase pItem
    {
        get
        {
            if(m_PocketItem == null)
            {
                m_PocketItem = Resources.Load<PocketItemDatabase>("Databases/PocketItemDatabase");
            }

            return m_PocketItem;
        }
    }
}
