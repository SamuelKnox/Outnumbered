﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }
    private int currentFrame;
    public int CurrentFrame
    {
        get { return currentFrame; }
    }

    void LateUpdate()
    {
        currentFrame++;
    }

    /// <summary>
    /// Sets the Current Frame to 0.
    /// </summary>
    public void ResetCurrentFrame()
    {
        currentFrame = 0;
    }
}
