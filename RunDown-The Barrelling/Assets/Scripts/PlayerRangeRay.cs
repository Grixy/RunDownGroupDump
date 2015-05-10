using UnityEngine;
using System.Collections;

public class PlayerRangeRay : MonoBehaviour {

	public RaycastHit shootRayHit;
	public RaycastHit interactRayHit;

	public Vector3 shotObject;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//Raycast for Interaction
		Ray interactRay = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2, 0));
		Ray shootRay = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2, 0));

		//Gate Interaction
		if(Physics.Raycast(interactRay, out interactRayHit, 1))
		{
			if (interactRayHit.collider.gameObject.GetComponent<GateInteract>() != null)
			{
				//hit.collider.gameObject.GetComponent<GateInteract>().OnInteract();
				if (Input.GetKeyDown (KeyCode.E) == true)
					interactRayHit.collider.gameObject.GetComponent<GateInteract>().interactEnable = true;
			}
		}

		if (Physics.Raycast(shootRay, out shootRayHit, 20))
		{
				if (Input.GetKeyDown (KeyCode.Space) == true)
				{
				Debug.Log(shootRayHit.point);
					shotObject = shootRayHit.point;
					gameObject.GetComponent<Shoot>().ShootBullet();
					//bulletClone = Instantiate(bulletObject, new Vector3 (bulletSpawnPoint.transform.position.x, bulletSpawnPoint.transform.position.y, bulletSpawnPoint.transform.position.z), transform.rotation) as GameObject;
					//shootRayHit.collider.gameObject.GetComponent<getShotBehaviour>().shootBullet(xPos, yPos);
				}
		}
	}
}
