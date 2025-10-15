using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.CullingGroup;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    public AudioSource sfxPlayer;

    public int interactedCount = 0;

    void Awake()
    {
        Instance = this;
    }

    public void AddInteraction()
    {
        interactedCount++;
    }
}
