using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void LevelEasy() => LevelManager.LevelEasy();

    public void LevelMedium() => LevelManager.LevelMedium();

    public void LevelHard() => LevelManager.LevelHard();

    public void LevelExtreme() => LevelManager.LevelExtreme();

    public void LevelMadness() => LevelManager.LevelMadness();

    public void Exit() => Application.Quit();
}
