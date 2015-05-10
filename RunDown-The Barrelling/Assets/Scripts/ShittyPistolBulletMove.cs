using UnityEngine;
using System.Collections;

public class ShittyPistolBulletMove : MonoBehaviour {

	new Vector3 travelDestination;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate(Vector3.forward * Time.deltaTime);
		//Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerRangeRay>().shotObject,Time.deltaTime);
	
	}
}
