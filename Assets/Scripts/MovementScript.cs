using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class MovementScript : MonoBehaviour {

    private GameObject player;

    private NavMeshAgent navMeshAgent;

    private NavMeshHit navMeshHit;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        if(player == null)
        {
            print("Player Not Found");
        }
        else
        {
            print("Player Found");
            navMeshAgent = player.GetComponent<NavMeshAgent>();
            if(navMeshAgent == null)
            {
                print("Nav Mesh Agent Not Found");
            }
            else
            {
                print("Nav Mesh Agent Found");
            }
        }     
	}
	
	public void OnPointerDown()
    {
        print("OnPointerDown Called!");
        RaycastHit hit;

        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 100f))
        {
            Debug.DrawLine(navMeshAgent.gameObject.transform.position, hit.point, Color.red, 10f);
            navMeshAgent.SetDestination(hit.point);
        }
    }
}
