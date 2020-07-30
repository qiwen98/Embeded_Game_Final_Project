using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject RulesScreen;
    public GameObject LevelSelect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Quit()
    {
        Application.Quit();
    }

    public void OpenOption()
    {
       RulesScreen.SetActive(true);
    }

    public void CloseOption()
    {
        RulesScreen.SetActive(false);
    }

    public void OpenLevelSelect()
    {
       LevelSelect.SetActive(true);
    }

    public void CloseLevelSelect()
    {
       LevelSelect.SetActive(false);
    }

    public void playlevelOne()
    {


        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void playlevelTwo()
    {


        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void playlevelThree()
    {


        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);

    }

    public void playlevelFour()
    {


        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);

    }

    public void playlevelFive()
    {


        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);
    }




}
