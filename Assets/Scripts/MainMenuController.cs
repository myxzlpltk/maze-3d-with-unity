using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainObject;
    public GameObject optionObject;
    public GameObject levelObject;

    // Start is called before the first frame update
    void Start()
    {
        Main();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Main()
    {
        mainObject.SetActive(true);
        optionObject.SetActive(false);
        levelObject.SetActive(false);
    }

    public void Option()
    {
        mainObject.SetActive(false);
        optionObject.SetActive(true);
        levelObject.SetActive(false);
    }

    public void Level()
    {
        mainObject.SetActive(false);
        optionObject.SetActive(false);
        levelObject.SetActive(true);
    }

    public void levelEasy()
    {
        openGame(6, 4);
    }

    public void levelMedium()
    {
        openGame(10, 4);
    }

    public void levelHard()
    {
        openGame(14, 3);
    }

    public void levelExtreme()
    {
        openGame(20, 3);
    }

    public void levelMadness()
    {
        openGame(40, 2);
    }

    void openGame(int size, int speed)
    {
        GameStorage.Set("size", size);
        GameStorage.Set("speed", size);
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
