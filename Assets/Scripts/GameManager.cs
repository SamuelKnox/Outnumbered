using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [Tooltip("The number of player lives remaining")]
    public int PlayerLives;
    [Tooltip("Score that the player has accumulated")]
    public float Score;

    public int GhostLives { get; set; }

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
