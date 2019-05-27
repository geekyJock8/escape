using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainHallLogic : MonoBehaviour {

    public GameObject trap;
    public GameObject player;
    public GameObject tripWire;
    public GameObject tripWireEffect;
    public GameObject healheart;
    public GameObject bunny;
    public ParticleSystem bunnyExplosion;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Vector2.Distance(new Vector2(player.transform.position.x, player.transform.position.z), new Vector2(trap.transform.position.x, trap.transform.position.z)) < 2)
        {
            trap.GetComponent<Rigidbody>().useGravity = true;
            GameLogic.instance.UpdateHUDMessage("You were crushed by Spike Trap", 2);
            GameLogic.instance.Death();
        }

        if(player.transform.position.z < -5 && !GameLogic.isTripWireOff)
        {
            print("You died");
            GameLogic.instance.Death();
        }

        if(!GameLogic.isGasOff)
        {
            GameLogic.instance.UpdateHealth(0.005f, 0);
        }

        if(player.transform.position.z < -42.48f)
        {
            if(!GameLogic.isBunnyDead)
            {
                bunny.transform.position = player.transform.position;
                GameLogic.instance.UpdateHUDMessage("Bunny Killed You!", 2);
                GameLogic.instance.Death();
            }
            else
            {
                GameLogic.instance.UpdateHUDMessage("Congratulations!\n You survived", 10);
            }
        }
	}

    public void TripWireHover()
    {
        GameLogic.instance.UpdateHUDMessage("Tap to Cut the TripWire", 1);
    }

    public void TripWireTap()
    {
        if(GameLogic.scissorStatus)
        {
            tripWire.SetActive(false);
            GameLogic.instance.UpdateHUDMessage("TripWire Removed", 2);
            GameLogic.isTripWireOff = true;
            GameLogic.instance.UpdateHealth(25, 1);
            Destroy(tripWireEffect);
        }
        else
        {
            GameLogic.instance.UpdateHUDMessage("You don't have tools to cut it", 2);
        }
    }

    public void HeartHeal()
    {
        if (Vector2.Distance(new Vector2(player.transform.position.x, player.transform.position.z), new Vector2(healheart.transform.position.x, healheart.transform.position.z)) < 0.7f)
        {
            print("Healed");
            GameLogic.isHealHeartTaken = true;
            GameLogic.instance.UpdateHUDMessage("Posion Antidode Taken", 2);
            Destroy(healheart);
        }
    }

    public void KillBunny()
    {
        bunnyExplosion.Play();
        StartCoroutine(Killdelay());
        GameLogic.isBunnyDead = true;
    }

    IEnumerator Killdelay()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        Destroy(bunny);
    }
}
