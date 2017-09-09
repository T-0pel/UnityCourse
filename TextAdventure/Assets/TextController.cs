using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {
    public Text MainText;

    private enum States
    {
        Vestibule_NoKeyCard,
        MainDoor_0,
        Stairs_0,
        GuardRoom,
        Vestibule_KeyCard,
        MainDoor_1,
        Stairs_1,
        Hall,
        ViewingRoom,
        Wall,
        DirectorOffice_NoRecording,
        Desk
    }

	// Use this for initialization
	void Start () {
        Vestibule_NoKeyCard();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }
	}

    private void Vestibule_NoKeyCard()
    {
        MainText.text = "You have just entered the vestibule. You know there is not much time, the inaguration will start soon, and if you do not " +
                            "find the incriminating evidence, this country shall became a hell to live in. You cannot let that happen. \n\n" +
                            "Press M to check the main door, S to go to the stairs, G to go to the guard room";
    }
}
