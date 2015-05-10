using UnityEngine;
using System.Collections;

public class moveBack2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.position += new Vector3 (Random.Range(0,-0.1f),0,0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
