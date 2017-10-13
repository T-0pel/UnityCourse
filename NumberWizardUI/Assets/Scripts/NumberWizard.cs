using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour
{
    private int Max { get; set; }
    private int Min { get; set; }
    private int Guess { get; set; }
    public int MaxGuessesAllowed = 5;
    public Text NumberText;

    // Use this for initialization
    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        Max = 1000;
        Min = 1;
        Max++;
        Guess = Random.Range(Min, Max);
        NumberText.text = Guess.ToString();
    }

    public void GuessHigher()
    {
        Min = Guess;
        NextGuess();
    }

    public void GuessLower()
    {
        Max = Guess;
        NextGuess();
    }

    void NextGuess()
    {
        Guess = Random.Range(Min, Max);
        NumberText.text = Guess.ToString();
        MaxGuessesAllowed--;
        if (MaxGuessesAllowed <= 0)
        {
            SceneManager.LoadScene("Win");
        }
    }

    public void GuessCorrect()
    {
        SceneManager.LoadScene("Lose");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
