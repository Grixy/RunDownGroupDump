using UnityEngine;
using System.Collections;

//Description: Code to cause a GameObject to follow a different GameObject.
//Reference: Code inspired by Sunrise Kingdom - "Unity 3D Tutorial - Follow Player AI", https://www.youtube.com/watch?v=W0Ux7XKk3O4
//Date: 05/05/2015
//Author: Ruan Gates

public class FollowPlayer : MonoBehaviour {

	//The object to follow, in this instance, the player.
	public GameObject player;

	//Control variables for follow-state
	public float speed;
	public float distance;

	//Smoothing for AI movement
	private float smoothing = 2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log("Dist: " + Vector3.Distance (player.transform.position, transform.position));
		if (Vector3.Distance (player.transform.position, transform.position) >= distance)
			{
			Debug.Log(Vector3.Distance (player.transform.position, transform.position));
			//renderer.material.color = Color.red;
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.transform.position - transform.position), Time.deltaTime);
			transform.position = Vector3.MoveTowards (transform.position, player.transform.position, player.GetComponent<move>().speed * Time.deltaTime);
			}
		else
			{
				//renderer.material.color = Color.blue;
			}
		}
}
