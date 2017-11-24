using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
	public void LoadLevel(string name)
    {
        Brick.BreakableCount = 0;
        Debug.Log("Level load requested for:" + name);
        SceneManager.LoadScene(name);
    }

    public void ReturnToStart()
    {
        Debug.Log("Returning to start screen");
        SceneManager.LoadScene("Start");
    }

    public void QuitGame()
    {
        Debug.Log("Game quitting");
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BrickDestroyed()
    {
        if (Brick.BreakableCount <= 0)
        {
            LoadNextLevel();
        }
    }
}
