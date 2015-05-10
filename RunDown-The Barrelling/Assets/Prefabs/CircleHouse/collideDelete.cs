using UnityEngine;
using System.Collections;

public class collideDelete : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//Debug.Log("ben11");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter (Collider col)
	{
		if(col.gameObject.name == "ColideRemover")
		{
			Destroy(gameObject);
			//Debug.Log ("contact1");
		}
		if(col.gameObject.name == "LandPrefab")
		{
			Destroy(gameObject);
			Debug.Log ("contact2");
		}
	}
}
