using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class FirstRoomLogic : MonoBehaviour {

    public GameObject bunny;
    public GvrAudioSource bunnyAudio;
    public GameObject boardMessage;
    public GameObject door;
    public GameObject briefcase;
    public GameObject mediKit;
    public VideoPlayer videoPlayer;
    public GameObject screenMessage;
    public GameObject videoScreen;

    private bool initMessage = false;
    private int bunnySwitch = 0;
    private bool screenToggle = false;

    // Use this for initialization
    void Start ()
    {
        videoPlayer.Play();
	}
	
	// Update is called once per frame
	void Update ()
    {
        print(videoPlayer.isPlaying);
        if (!videoPlayer.isPlaying && initMessage == false && videoPlayer.isPrepared && !GameLogic.breifcaseStatus)
        {
            GameLogic.instance.UpdateHUDMessage("Gaze and Tap at the Briefcase\n to your left", 3);
            bunnyAudio.Play();
            initMessage = true;
        }

        if(!videoPlayer.isPlaying && videoPlayer.isPrepared && screenToggle == false)
        {
            screenToggle = true;
            videoScreen.SetActive(false);
            screenMessage.SetActive(true);
        }
    }

    public void ChangeLevel()
    {
        GameLogic.instance.LoadHallWay();
    }

    public void PickupBriefcase()
    {
        briefcase.SetActive(false);
        GameLogic.instance.PickupObject(1);
        GameLogic.instance.UpdateHUDMessage("You've Picked Up Breifcase", 2);
    }

    public void PickupMedikit()
    {
        mediKit.SetActive(false);
        GameLogic.instance.PickupObject(4);
        GameLogic.instance.UpdateHUDMessage("Picked Up MediKit", 2);
    }

    public void CupBoardSearch()
    {
        GameLogic.instance.PickupObject(2);
        GameLogic.instance.PickupObject(3);
        GameLogic.instance.UpdateHUDMessage("Picked Up Scissors\nPicked Up Lighter", 2);
    }

    public void BunnyAction()
    {
        if(bunnySwitch == 0)
        {
            bunny.transform.position = new Vector3(5.64f, -0.757f, -9.85f);
            bunny.transform.rotation = new Quaternion(0, -106, 0, 1);
            bunnyAudio.Play();
            bunnySwitch = 1;
        }
        else if(bunnySwitch == 1)
        {
            bunny.transform.position = new Vector3(-6.0f, -0.767f, -5.5f);
            bunnyAudio.Play();
            boardMessage.SetActive(true);
            bunnyAudio.loop = false;
            bunnyAudio.Play();
        }
    }
}
