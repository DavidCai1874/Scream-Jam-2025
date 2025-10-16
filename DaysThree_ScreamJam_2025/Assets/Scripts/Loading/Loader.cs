using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{

    private static Scene targetScene;

    public enum Scene
    {
        Main_Menu_Scene,
        Loading_Scene_Normal,
        Loading_Scene_Redemption,
        Day1_Scene,
        Day2_Scene,
        Ending_Normal,
        Ending_Redemption
    }

    public static void LoadNormal(Scene targetScene)
    {
        Loader.targetScene = targetScene;

        SceneManager.LoadScene(Scene.Loading_Scene_Normal.ToString());
    }

    public static void LoadHidden(Scene targetScene)
    {
        Loader.targetScene = targetScene;

        SceneManager.LoadScene(Scene.Loading_Scene_Redemption.ToString());
    }


    public static void LoaderCallback()
    {
        SceneManager.LoadScene(targetScene.ToString());
    }


}

