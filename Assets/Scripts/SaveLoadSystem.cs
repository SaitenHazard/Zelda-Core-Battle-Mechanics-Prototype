using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.SceneManagement;


public class SaveLoadSystem : MonoBehaviour {

    public static SaveLoadSystem control;
    public bool doLoadGame = false;
    private PocketItemType[] array;

	// Use this for initialization
	void Awake () {
		if(control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
	}

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (doLoadGame == true)
        {
            if (File.Exists(Application.dataPath + "/save.dat"))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream file = File.Open(Application.dataPath + "/save.dat", FileMode.Open);
                SaveData data = (SaveData)formatter.Deserialize(file);
                array = data.PocketItemArray;
            }
            else
            {
                Debug.Log("ERROR");
            }
        }
    }

    public PocketItemType[] getLoadData()
    {
        return array;
    }

    public void setLoadGame()
    {
        doLoadGame = true;
    }

    public void SaveGame()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Open(Application.dataPath + "/save.dat", FileMode.Create);

        SaveData data = new SaveData();
        data.PocketItemArray = CharacterPocketModel.instance.getEntireInventory();
        Debug.Log("yo");

        formatter.Serialize(file, data);
        file.Close();
    }
}


[Serializable]
class SaveData
{
    public PocketItemType[] PocketItemArray = new PocketItemType[3];
}
