using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    private int Max { get; set; }
    private int Min { get; set; }
    private int Guess { get; set; }

    // Use this for initialization
    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        Max = 1000;
        Min = 1;
        Guess = 500;

        print("=====================");
        print("Welcome to the number wizard.");
        print("Pick a number in your head, but don't tell me.");

        print(string.Format("The highest number that you can pick is {0}", Max));
        print(string.Format("The lowest number that you can pick is {0}", Min));

        print(string.Format("Is the number higher or lower than {0}?", Guess));
        print("Up = higher, down = lower, return = equal");

        Max++;
    }

    void NextGuess()
    {
        Guess = Random.Range(Min, Max);
        print(string.Format("Is the number higher or lower than {0}?", Guess));
        print("Up = higher, down = lower, return = equal");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Min = Guess;
            NextGuess();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Max = Guess;
            NextGuess();
        }
        else if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            print("I won");
            StartGame();
        }
    }
}
