using UnityEngine;
using System.Collections;

public class CircleSpawn : MonoBehaviour {
	public GameObject CircleWall;
	private int rota;
	// Use this for initialization
	void Start () {
		for (int i =0; i<=120; i++)
		{
			Instantiate(CircleWall,transform.position,Quaternion.Euler(0,rota,0));
			rota+=3;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
