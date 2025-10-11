using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{

    private static Scene targetScene;

    public enum Scene
    {
        MainMenuScene,
        Loading_Scene_Normal,
        Day1_Scene,
    }

    public static void Load(Scene targetScene) //send in target scene
    {
        Loader.targetScene = targetScene;

        SceneManager.LoadScene(Scene.Loading_Scene_Normal.ToString());
    }


    public static void LoaderCallback()
    {
        SceneManager.LoadScene(targetScene.ToString());
    }


}

