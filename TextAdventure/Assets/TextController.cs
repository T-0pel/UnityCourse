using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum State
{
    Vestibule_NoKeyCard,
    MainDoor_NoKeyCard,
    Stairs_NoKeyCard,
    GuardRoom,
    Vestibule_KeyCard,
    MainDoor_KeyCard,
    Stairs_KeyCard,
    Hall,
    View,
    Wall,
    DirectorOffice_NoRecording,
    Desk_NoRecording,
    Closet_NoRecording,
    Safe,
    DirectorOffice_Recording,
    Desk_Recording,
    Closet_Recording,
    End
}

public class TextController : MonoBehaviour
{
    public Text MainText;
    private State State { get; set; }

    // Use this for initialization
    void Start()
    {
        State = State.Vestibule_NoKeyCard;
    }

    // Update is called once per frame
    void Update()
    {
        print(State);
        switch (State)
        {
            case State.Vestibule_NoKeyCard:
                Vestibule_NoKeyCard();
                break;
            case State.MainDoor_NoKeyCard:
                MainDoor_NoKeyCard();
                break;
            case State.Stairs_NoKeyCard:
                Stairs_NoKeyCard();
                break;
            case State.GuardRoom:
                GuardRoom();
                break;
            case State.Vestibule_KeyCard:
                Vestibule_KeyCard();
                break;
            case State.MainDoor_KeyCard:
                MainDoor_KeyCard();
                break;
            case State.Stairs_KeyCard:
                Stairs_KeyCard();
                break;
            case State.Hall:
                Hall();
                break;
            case State.View:
                View();
                break;
            case State.Wall:
                Wall();
                break;
            case State.DirectorOffice_NoRecording:
                DirectorOffice_NoRecording();
                break;
            case State.Desk_NoRecording:
                Desk_NoRecording();
                break;
            case State.Closet_NoRecording:
                Closet_NoRecording();
                break;
            case State.Safe:
                Safe();
                break;
            case State.DirectorOffice_Recording:
                DirectorOffice_Recording();
                break;
            case State.Desk_Recording:
                Desk_Recording();
                break;
            case State.Closet_Recording:
                Closet_Recording();
                break;
            case State.End:
                End();
                break;
            default:
                break;
        }
    }

    private void End()
    {
        MainText.text = "As you press play, you watch the voting room through the cameras. Just as the voting was about to begin, all the screens start showing a recording " +
                        "of the director ordering a murder of his rival. You also broadcast this video over the internet and to the local police. " +
                        "Seeing the look on the director's face finally brings some peace to you. \n\n" +
                        "CONGRATULATIONS! You have successfully completed the game. \n\n" +
                        "Press P to play again";
        if (Input.GetKeyDown(KeyCode.P)) State = State.Vestibule_NoKeyCard;
    }

    private void Closet_Recording()
    {
        MainText.text = "The closet is very messy, you search it thouroughly, but you do not find anything incriminating. This certainly is not the place to use the evidence you just found. \n\n" +
                        "Press R to return to the office";
        if (Input.GetKeyDown(KeyCode.R)) State = State.DirectorOffice_Recording;
    }

    private void Desk_Recording()
    {
        MainText.text = "The desk is very clean, and the only thing that is usable is the computer. You type in the password 'password123' and it works..." +
                        "The director should really use stronger passwords. You hack all the screens in the voting area, and you are ready to play the evidence. \n\n" +
                        "Press P to play the evidence, R to return to the office";
        if (Input.GetKeyDown(KeyCode.R)) State = State.DirectorOffice_Recording;
        else if (Input.GetKeyDown(KeyCode.P)) State = State.End;
    }

    private void DirectorOffice_Recording()
    {
        MainText.text = "You hacked the safe and you found the incriminationg evidence on a harddrive. Now you just need to show it to the rest of the world. " +
                        "to show it to everyone.  There is a safe on the wall, a desk with a computer, and a closet. \n\n" +
                        "Press D to inspect the desk, C to inspect the closet";
        if (Input.GetKeyDown(KeyCode.D)) State = State.Desk_Recording;
        else if (Input.GetKeyDown(KeyCode.C)) State = State.Closet_Recording;
    }

    private void Safe()
    {
        MainText.text = "The safe is very sturdy, but it has a keypad and you should be able to hack it. \n\n" +
                        "Press H to hack the safe, R to return to the office";
        if (Input.GetKeyDown(KeyCode.R)) State = State.DirectorOffice_NoRecording;
        else if (Input.GetKeyDown(KeyCode.H)) State = State.DirectorOffice_Recording;
    }

    private void Closet_NoRecording()
    {
        MainText.text = "The closet is very messy, you search it thouroughly, but you do not find anything incriminating. \n\n" +
                        "Press R to return to the office";
        if (Input.GetKeyDown(KeyCode.R)) State = State.DirectorOffice_NoRecording;
    }

    private void Desk_NoRecording()
    {
        MainText.text = "The desk is very clean, and the only thing that is usable is the computer. You type in the password 'password123' and it works..." +
                        "The director should really use stronger passwords. You hack all the screens in the voting area, but you still need to find the evidence to show. \n\n" +
                        "Press R to return to the office";
        if (Input.GetKeyDown(KeyCode.R)) State = State.DirectorOffice_NoRecording;
    }

    private void DirectorOffice_NoRecording()
    {
        MainText.text = "It worked! You managed to bypass the security and now you are in the director's office. You need to find the evidence and find a way " +
                        "to show it to everyone.  There is a safe on the wall, a desk with a computer, and a closet. \n\n" +
                        "Press D to inspect the desk, S to inspect the safe, C to inspect the closet";
        if      (Input.GetKeyDown(KeyCode.D)) State = State.Desk_NoRecording;
        else if (Input.GetKeyDown(KeyCode.S)) State = State.Safe;
        else if (Input.GetKeyDown(KeyCode.C)) State = State.Closet_NoRecording;
    }

    private void Wall()
    {
        MainText.text = "Since you cannot bypass the laser sensors, you turn your attention to the wall, where you see a ventilation shaft." +
                        "It is very narrow, but you might be able to use it to get to the director's office. \n\n" +
                        "Press V to use the ventilation shaft, R to return to the hall";
        if      (Input.GetKeyDown(KeyCode.R)) State = State.Hall;
        else if (Input.GetKeyDown(KeyCode.V)) State = State.DirectorOffice_NoRecording;
    }

    private void View()
    {
        MainText.text = "There is a huge crows gathered in the room below, and they are ready to cast their votes." +
                        "There is almost no time left, you need to hurry! \n\n" +
                        "Press R to return to the hall";
        if      (Input.GetKeyDown(KeyCode.R)) State = State.Hall;
    }

    private void Hall()
    {
        MainText.text = "The keycard allowed you to use the stairs, and now you find yourself in a great hall. The doors leading to the director's office are " +
                        "protected by a complex layer of laser sensors. You will not be able to bypass these, you need to find another way in. " +
                        "There is also big window overlooking the voting area. \n\n" +
                        "Press V to take a look out of the window, W to inspect the wall";
        if      (Input.GetKeyDown(KeyCode.V)) State = State.View;
        else if (Input.GetKeyDown(KeyCode.W)) State = State.Wall;
    }

    private void Stairs_KeyCard()
    {
        MainText.text = "The stairs that lead up to your target are protected by laser sensors. There is a keypad which can turn it off, but " +
                        "your hacking skills are not good enough to bypass it. But now you have the keycard, it should allow you to bypass the protection. \n\n" +
                        "Press K to use the keycard, R to return to the vestibule";
        if      (Input.GetKeyDown(KeyCode.R)) State = State.Vestibule_KeyCard;
        else if (Input.GetKeyDown(KeyCode.K)) State = State.Hall;
    }

    private void MainDoor_KeyCard()
    {
        MainText.text = "These are the main doors of the office building. Your fake identity allowed you to get in, and now you have got " +
                        "a job to do. You have found the keypass, but this is not the place to use it. \n\n" +
                        "Press R to return to the vestibule";
        if      (Input.GetKeyDown(KeyCode.R)) State = State.Vestibule_KeyCard;
    }

    private void Vestibule_KeyCard()
    {
        MainText.text = "You are back in the vestibule with the keycard you stole from the incapacitated guard. " +
                        "Time is running out, you need to find the evidence soon. \n\n" +
                        "Press M to check the main door, S to go to the stairs";
        if      (Input.GetKeyDown(KeyCode.M)) State = State.MainDoor_KeyCard;
        else if (Input.GetKeyDown(KeyCode.S)) State = State.Stairs_KeyCard;
    }

    private void GuardRoom()
    {
        MainText.text = "You use the cloaking ability of your nanosuit and enter the guard room. It is almost empty, but there is one guard on duty. " +
                        "He is sitting with his back to you and is oblivious to your presence. You can see a keypass lying on his desk, but first you need " +
                        "to take care of the guard. \n\n" +
                        "Press S to stun the guard, R to return to the vestibule";
        if      (Input.GetKeyDown(KeyCode.R)) State = State.Vestibule_NoKeyCard;
        else if (Input.GetKeyDown(KeyCode.S)) State = State.Vestibule_KeyCard;
    }

    private void Stairs_NoKeyCard()
    {
        MainText.text = "The stairs that lead up to your target are protected by laser sensors. There is a keypad which can turn it off, but " +
                        "your hacking skills are not good enough to bypass it. You will need to find another way to turn it off. \n\n" +
                        "Press R to return to the vestibule";
        if      (Input.GetKeyDown(KeyCode.R)) State = State.Vestibule_NoKeyCard;
    }

    private void MainDoor_NoKeyCard()
    {
        MainText.text = "These are the main doors of the office building. Your fake identity allowed you to get in, and now you have got " +
                        "a job to do. You cannot leave just yet. \n\n" +
                        "Press R to return to the vestibule";
        if      (Input.GetKeyDown(KeyCode.R)) State = State.Vestibule_NoKeyCard;
    }

    private void Vestibule_NoKeyCard()
    {
        MainText.text = "You have just entered the vestibule. You know there is not much time, the vote will start soon, and if you do not " +
                        "find the incriminating evidence, this company shall be ruled by a ruthless killer who killed your father. You cannot let that happen. \n\n" +
                        "Press M to check the main door, S to go to the stairs, G to go to the guard room";
        if      (Input.GetKeyDown(KeyCode.M)) State = State.MainDoor_NoKeyCard;
        else if (Input.GetKeyDown(KeyCode.S)) State = State.Stairs_NoKeyCard;
        else if (Input.GetKeyDown(KeyCode.G)) State = State.GuardRoom;
    }
}
