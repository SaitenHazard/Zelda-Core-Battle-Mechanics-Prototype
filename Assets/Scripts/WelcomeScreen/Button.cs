using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;


public class Button : MonoBehaviour {

    public GameObject buttonStart, buttonLoad;

    private bool newGame = true;
    private bool saveDataExists = false;

    // Use this for initialization
    void Start()
    {
        if (File.Exists(Application.dataPath + "/save.dat"))
        {
            saveDataExists = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        buttonInput();
        View();
    }

    private void buttonInput()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (saveDataExists == false) return;

            if (newGame == true) newGame = false;
            else newGame = true;
        }

        if(Input.GetKeyDown(KeyCode.Return))
        {
            if (newGame == true)
            {
                loadScript();
            }
            else
            {
                SaveLoadSystem.control.setLoadGame();
                loadScript();
            }
        }
    }

    private void loadScript()
    {
        SceneManager.LoadScene("New Scene 1", LoadSceneMode.Single);
    }

    private void View()
    {
        if (saveDataExists == false)
            buttonLoad.SetActive(false);

        if(newGame == true)
        {
            buttonStart.GetComponent<Image>().color = Color.white;
            buttonLoad.GetComponent<Image>().color = Color.black;
        }
        else
        {
            buttonStart.GetComponent<Image>().color = Color.black;
            buttonLoad.GetComponent<Image>().color = Color.white;
        }
    }
}
