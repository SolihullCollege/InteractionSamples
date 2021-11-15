using UnityEngine;
using System.Collections;

public class navscript : MonoBehaviour {

	public UnityEngine.AI.NavMeshAgent agent;
	public GameObject player;
	Animator anim;

	public enum MoveState {awake, Locomotion}
	public MoveState moveState;



	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player");
		agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent> ();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {


		if (Vector3.Distance(transform.position, player.transform.position)<10)
		{ 
			agent.SetDestination(player.transform.position);
		}
		if(agent.hasPath)
		{ 
			moveState = MoveState.Locomotion;
			anim.SetBool("hasPath", true);
		}
		else
			moveState = MoveState.awake;

		if(agent.remainingDistance<1.7f)
        {
			anim.SetTrigger("Attack");
        }
	}

    private void OnTriggerEnter(Collider other)
    {
		if(other.CompareTag("Player"))
			Debug.Log("Hit");
    }
}
