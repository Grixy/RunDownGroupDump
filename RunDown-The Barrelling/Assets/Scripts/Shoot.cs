using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	private GameObject bulletClone;
	public GameObject bulletObject;
	public GameObject bulletSpawnPoint;

	//public Vector3 travelLocation;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	public void ShootBullet () {

		//travelLocation = gameObject.GetComponent<PlayerRangeRay>().shotObject;
		bulletClone = Instantiate(bulletObject, new Vector3 (bulletSpawnPoint.transform.position.x, bulletSpawnPoint.transform.position.y, bulletSpawnPoint.transform.position.z), transform.rotation) as GameObject;

	}
}
