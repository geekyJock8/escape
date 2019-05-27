using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour {

    public static bool scissorStatus = false;
    public static bool lighterStatus = false;
    public static bool breifcaseStatus = false;
    public static bool mediKitStatus = false;
    public static bool firstRoomDoorStatus = false;
    public static bool isBunnyDead = false;
    public static bool isHealHeartTaken = false;
    public static bool isTripWireOff = false;
    public static bool isGasOff = false;

    private static float playerHealth = 100;
    private float startTime = 0;
    private float timeDiff;
    private bool flag = false;

    public static GameLogic instance;
    public Text HUDMessage;

    // Use this for initialization
    void Awake ()
    {
		if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
	}

    // Update is called once per frame
    private void Update()
    {
        //print("UpdateCalled");
        //print(Time.time);
        if(string.Compare(HUDMessage.text, "") != 0 && flag == false)
        {
            flag = true;
            startTime = Time.time;
        }

        if(flag == true)
        {
            //print(Time.time - startTime);
            //print(timeDiff);
            if(Time.time - startTime >= timeDiff)
            {
                HUDMessage.text = "";
                startTime = 0;
                flag = false;
            }
        }

        if(!isHealHeartTaken)
        {
            UpdateHealth(0.004f, 0);
            print(playerHealth);
        }

        if(playerHealth < 25)
        {
            UpdateHUDMessage("Your Health is " + playerHealth.ToString(), 1);
        }

        if(playerHealth < 0)
        {
            UpdateHUDMessage("You Died", 2);
            Death();
        }
    }

    public void UnlockFirstRoomDoor()
    {
        firstRoomDoorStatus = true;
        print("Now You can proceed to hallway!");
    }

    public void LoadHallWay()
    {
        if(firstRoomDoorStatus)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            print("Door Locked");
            UpdateHUDMessage("Door is Locked", 1);
        }
    }

    public void LoadMainHall()
    {
        print("Loading Main Hall");
        SceneManager.LoadScene(2);
    }

    public void PickupObject(int i)
    {
        if(i != 1 && breifcaseStatus == false)
        {
            UpdateHUDMessage("Pickup the briefcase first to\ncarry items", 2);
            return;
        }
        switch(i)
        {
            case 1: breifcaseStatus = true;
                print("PickedUp Breifcase");
                break;
            case 2: scissorStatus = true;
                print("PickedUp Scissors");
                break;
            case 3: lighterStatus = true;
                print("PickedUp Lighter");
                break;
            case 4: mediKitStatus = true;
                print("PickedUp Medikit");
                playerHealth = playerHealth + 25;
                break;
        }
    }

    public void UpdateHUDMessage(string message, int t)
    {
        HUDMessage.text = message;
        timeDiff = t;
        print("UpdateHUDMessageCalled");
    }

    public void UpdateHealth(float amount, int choice)
    {
        if(choice == 0)
        {
            playerHealth = playerHealth - amount;
        }
        else
        {
            playerHealth = playerHealth + amount;
        }
    }

    public void Death()
    {
        SceneManager.LoadScene(3);
    }
}
