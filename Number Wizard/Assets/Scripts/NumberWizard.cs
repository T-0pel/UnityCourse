using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    private string MaxString { get; set; }
    private string MinString { get; set; }
    private int Max { get; set; }
    private int Min { get; set; }
    private int Guess { get; set; }
    private bool IsMinPicked { get; set; }
    private bool IsMaxPicked { get; set; }
    private bool IsGameStarted { get; set; }
    private List<KeyCode> numberCodes
    {
        get
        {
            return new List<KeyCode> {
                KeyCode.Alpha0,
                KeyCode.Alpha1,
                KeyCode.Alpha2,
                KeyCode.Alpha3,
                KeyCode.Alpha4,
                KeyCode.Alpha5,
                KeyCode.Alpha6,
                KeyCode.Alpha7,
                KeyCode.Alpha8,
                KeyCode.Alpha9,
            };
        }
    }

    // Use this for initialization
    void Start()
    {
        PreStart();
    }

    private void PreStart()
    {
        MinString = "";
        MaxString = "";
        print("=====================");
        print("Welcome to the number wizard.");
        print("First you have to pick the number range.");
        print("Type in the lowest number you want in the range and press Enter");
    }

    void StartGame()
    {
        Guess = Random.Range(Min, Max);
        print("Pick a number in your head, but don't tell me.");

        print(string.Format("The highest number that you can pick is {0}", Max));
        print(string.Format("The lowest number that you can pick is {0}", Min));

        print(string.Format("Is the number higher or lower than {0}?", Guess));
        print("Up = higher, down = lower, return = equal");

        Max++;
        IsGameStarted = true;
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
        if (IsGameStarted)
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
                IsGameStarted = false;
                IsMaxPicked = false;
                IsMinPicked = false;
                PreStart();
            }
        }
        else if (!IsMinPicked)
        {
            for (int i = 0; i < numberCodes.Count; i++)
            {
                if (Input.GetKeyDown(numberCodes[i]))
                {
                    MinString += i;
                    print("The lowest number will be " + MinString);
                }
            }
            if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
            {
                Min = int.Parse(MinString);
                IsMinPicked = true;
                print("Type in the highest number you want in the range and press Enter");
            }
        }
        else
        {
            for (int i = 0; i < numberCodes.Count; i++)
            {
                if (Input.GetKeyDown(numberCodes[i]))
                {
                    MaxString += i;
                    print("The highest number will be " + MaxString);
                }
            }
            if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
            {
                Max = int.Parse(MaxString);
                if (Max <= Min)
                {
                    print("The highest number in the range must be higher than the lowest number");
                }
                else
                {
                    IsMaxPicked = true;
                    StartGame();
                }
            }
        }
    }
}
