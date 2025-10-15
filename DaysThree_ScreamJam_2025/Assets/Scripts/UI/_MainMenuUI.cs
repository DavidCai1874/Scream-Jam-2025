using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{

    [SerializeField] private Button playButton;


    private void Awake()
    {
        playButton.onClick.AddListener(() =>
        {
            Loader.LoadNormal(Loader.Scene.Day1_Scene);
        });
    }

}
