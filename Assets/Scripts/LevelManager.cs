using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelManager
{
    static readonly int[] sizes = {6, 10, 14, 20, 40};
    static readonly float[] speeds = { 2, 2, 1.5f, 1.5f, 1 };
    static int currentLevel = 0;

    public static int size = sizes[0];
    public static float speed = speeds[0];
    public static string name = "Easy";

    public static void LevelEasy()
    {
        LevelManager.name = "Easy";
        LevelManager.currentLevel = 0;
        LevelManager.OpenGame();
    }

    public static void LevelMedium()
    {
        LevelManager.name = "Medium";
        LevelManager.currentLevel = 1;
        LevelManager.OpenGame();
    }

    public static void LevelHard()
    {
        LevelManager.name = "Hard";
        LevelManager.currentLevel = 2;
        LevelManager.OpenGame();
    }

    public static void LevelExtreme()
    {
        LevelManager.name = "Extreme";
        LevelManager.currentLevel = 3;
        LevelManager.OpenGame();
    }

    public static void LevelMadness()
    {
        LevelManager.name = "Madness";
        LevelManager.currentLevel = 4;
        LevelManager.OpenGame();
    }

    public static void NextLevel()
    {
        switch (LevelManager.currentLevel)
        {
            case 0:
                LevelManager.LevelMedium();
                break;
            case 1:
                LevelManager.LevelHard();
                break;
            case 2:
                LevelManager.LevelExtreme();
                break;
            case 3:
                LevelManager.LevelMadness();
                break;
        }
    }

    public static bool IsLastLevel => LevelManager.currentLevel == 4;

    static void OpenGame()
    {
        LevelManager.size = LevelManager.sizes[LevelManager.currentLevel];
        LevelManager.speed = LevelManager.speeds[LevelManager.currentLevel];
        SceneManager.LoadScene(1);
    }
}
