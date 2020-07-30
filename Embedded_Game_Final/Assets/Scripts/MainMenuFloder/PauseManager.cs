using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject PauseScreen;
    public GameObject OptionScreen;
    public string levelselect, mainmenu;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnPaused();
        }

     
    }

    public void PauseUnPaused()
    {
        if (PauseScreen.activeInHierarchy)
        {
            PauseScreen.SetActive(false);
            CloseOption();
            Time.timeScale = 1f;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            PauseScreen.SetActive(true);
            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

    }

    public void Resume()
    {
        PauseUnPaused();
    }

    public void OpenOption()
    {
        OptionScreen.SetActive(true);
    }

    public void CloseOption()
    {
        OptionScreen.SetActive(false);
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene(levelselect);
        Time.timeScale = 1f;
    }

    public void Mainmenu()
    {
        SceneManager.LoadScene(mainmenu);
        Time.timeScale = 1f;
    }


}
