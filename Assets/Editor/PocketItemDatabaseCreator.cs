using UnityEngine;
using UnityEditor;
using System.Collections;

public class PocketItemDatabaseCreator : MonoBehaviour
{
    [MenuItem("Let's Code Games/Databases/Create Pocket Item Database")]
    public static void CreateItemDatabase()
    {
        PocketItemDatabase newDatabase = ScriptableObject.CreateInstance<PocketItemDatabase>();
        AssetDatabase.CreateAsset(newDatabase, "Assets/PocketItemDatabase.asset");
        AssetDatabase.Refresh();
    }
}
