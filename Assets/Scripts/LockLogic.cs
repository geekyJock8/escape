using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockLogic : MonoBehaviour {

    public GameObject[] lockPadNum = new GameObject[10];
    private string enteredCode;
    public Text lockText;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TapButton(GameObject pressedButton)
    {
        for(int i = 0; i < 10; i++)
        {
            if(pressedButton == lockPadNum[i])
            {
                enteredCode = enteredCode + i.ToString();
                break;
            }
        }

        print(enteredCode);
        lockText.text = enteredCode;
    }

    public void Unlock(string correctCode)
    {
        if(string.Compare(enteredCode, correctCode) == 0)
        {
            print("Door Unlocked");
            lockText.text = "DOOR UNLOCKED";
            GameLogic.instance.UnlockFirstRoomDoor();
        }
        else
        {
            print("Try Again");
            lockText.text = "TRY AGAIN";
        }

        enteredCode = "";
    }

    public void TurnTripWireOff(string correctCode)
    {
        if (string.Compare(enteredCode, correctCode) == 0)
        {
            print("Trip wire off");
            lockText.text = "TRIP WIRE OFF";
            GameLogic.isTripWireOff = true;
        }
        else
        {
            print("Try Again");
            lockText.text = "TRY AGAIN";
        }

        enteredCode = "";
    }

    public void TurnGasOff(GameObject gasSystem)
    {
        if (string.Compare(enteredCode, "8") == 0)
        {
            print("Gas Turned Off");
            lockText.text = "GAS TURNED OFF";
            Destroy(gasSystem);
            GameLogic.isGasOff = true;
        }
        else
        {
            print("Try Again");
            lockText.text = "TRY AGAIN";
        }

        enteredCode = "";
    }

}
