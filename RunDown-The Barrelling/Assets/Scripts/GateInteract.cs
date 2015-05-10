using UnityEngine;
using System.Collections;

public class GateInteract : MonoBehaviour {

	//Determines which way the gate should move
	private bool backAndForth = false;

	//Determines if the gate is allowed to open
	public bool interactEnable = false;

	//Handles timer status and refresh value.
	private float timerStatus;
	public float gateTimer;

	//Handle how far the gate should open per increment. For now, this is a integer value.
	public int gateOpenDistance;

	// Use this for initialization
	void Start () {
		timerStatus = gateTimer;
	}
	
	// Update is called once per frame
	void Update () {

		//If the gate is allowed to move, move for a certain amount of time (regulated by object length).
		//When done moving, reset all values to allow movement again later.
		if (interactEnable == true)
		{
			if (timerStatus >= 0)
			{
				timerStatus -= Time.deltaTime;
				OnInteract();
			}

			if (timerStatus < 0)
			{
				interactEnable = false;
				backAndForth = !backAndForth;
				timerStatus = gateTimer;
			}

		}
	}

	public void OnInteract()
	{	
		//Move the gate in the right direction, as controlled in Update.
		if (backAndForth == false)
		{
			transform.Translate(new Vector3(gateOpenDistance * Time.deltaTime,0,0));
		}
		else
		{
			transform.Translate(new Vector3(-gateOpenDistance * Time.deltaTime,0,0));
		}
	}
}
