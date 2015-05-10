using UnityEngine;
using System.Collections;

public class cameraMove : MonoBehaviour {
	public float PlusSin;
	private bool Pressed = true;
	private float countDown;
	private bool turn = false;
	private bool FistRun = true;
	public GameObject Parent;
	private float Sensitivity;

	// Use this for initialization
	void Start () {
		Sensitivity = GameObject.FindGameObjectWithTag("Player") .transform.localScale.x*140;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.W))
		{
			PlusSin+=0.3f;
			transform.position += new Vector3(0,Mathf.Sin(PlusSin)/150*Sensitivity,0);
			Pressed = true;
		}
		else
		if (Pressed == true)
		{
			PlusSin += 0.05f;
			transform.position += new Vector3(0,Mathf.Sin(PlusSin)/800*Sensitivity,0);
		}

		if (Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.D))
		{
			if (turn == false)
			{
				turn = true;
				FistRun = true;
			}
		}


		if(turn == true)
		{

			if (FistRun == true)
			{
				countDown = Mathf.PI*2;
			}
			if (countDown >=0)
			{
				FistRun = false;
				countDown -=0.1f;
				transform.Rotate(new Vector3(0,Mathf.Sin(countDown)/20*Sensitivity,0));
			}
			else
			{
				turn =false;
				transform.rotation = Parent.transform.rotation;
			}
		}

	}
}
