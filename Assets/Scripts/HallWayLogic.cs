using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallWayLogic : MonoBehaviour {

    public GameObject player;

    public GameObject Pos;
    public ParticleSystem PS;

    // Use this for initialization
    void Start ()
    {
        GameLogic.instance.UpdateHUDMessage("Gaze and Tap on any door\nto access it", 2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void KnockCorrectDoor()
    {
        GameLogic.instance.LoadMainHall();
    }

    public void KnockWrongDoor(int num)
    {
        this.GetComponent<Animator>().SetTrigger("unlock");
        float start = Time.time;
        StartCoroutine(animationDelay(1));
    }

    IEnumerator animationDelay(int t)
    {
        print(Time.time);
        yield return new WaitForSecondsRealtime(3);
        switch (t)
        {
            case 1:
                StartCoroutine(enterRoom(Pos, PS));
                break;
            case 2:
                StartCoroutine(enterRoom(Pos, PS));
                break;
            case 3:
                StartCoroutine(enterRoom(Pos, PS));
                break;
        }
        print(Time.time);
    }

    private IEnumerator enterRoom(GameObject playerDeathPosition, ParticleSystem curr)
    {
        iTween.MoveTo(player,
            iTween.Hash(
                    "position", playerDeathPosition.transform.position,
                    "time", 4,
                    "easetype", "linear"
                        )
            );
        print(Time.time);
        yield return new WaitForSecondsRealtime(1);
        curr.Play();
        print(Time.time);
        StartCoroutine(Killed());
    }

    private IEnumerator Killed()
    {
        yield return new WaitForSecondsRealtime(1);
        GameLogic.instance.Death();
    }
}
