using UnityEngine;
using System.Collections;

public class MakeTrees : MonoBehaviour {
	private float TreeNumber;
	public GameObject Treat;
	private float Left;
	private float Up;
	private GameObject tree;

	//determine which wall we're placing the object on, left or right. (1 or 2).
	public int wallSide;

	private Vector3 rotationAngle;

	// Use this for initialization
	void Start () {

		rotationAngle = new Vector3(rotationAngle.x, rotationAngle.y + 180,rotationAngle.z);
		TreeNumber = Random.Range (0, 4);
		for(int i=0 ; i < TreeNumber; i ++)
		{
			tree = Instantiate(Treat,transform.position , Quaternion.identity) as GameObject;
			if (wallSide == 1)
			{
				tree.transform.rotation = transform.rotation;
				tree.transform.Rotate(new Vector3(0,180f,0),Space.World);
			}
			else
			{
				tree.transform.rotation = transform.rotation;
			}
		}

	}
}
/*
			Left = Random.Range(0,2);
			Up = Random.Range(0,4);

			if (Up<=2)
			{
				if (Left>=1)
				{
					tree = Instantiate(Treat,transform.position + new Vector3(0,Random.Range(0.156f,0.5f),-0.35f+Random.Range(-0.497f,0.495f)), Quaternion.identity) as GameObject;
					tree.transform.LookAt(transform.position);
				}
				else
				{
					var instantiatedPrefab = Instantiate(Treat,transform.position + new Vector3(0.5f,Random.Range(0.156f,0.5f),Random.Range(-0.497f,0.495f)),Quaternion.Euler(0, 270, 0)) as GameObject;
					instantiatedPrefab.transform.localScale = new Vector3(-1,1,1);
				}
			}
			else
			{
				if (Left>=1f)
				{
					Instantiate(Treat,transform.position + new Vector3(Random.Range(0.221f,0.4f),0.156f,Random.Range(-0.492f,0.492f)), Quaternion.Euler(0, 0, 90));

				}
				else
				{
					var instantiatedPrefab = Instantiate(Treat,transform.position + new Vector3(Random.Range(-0.221f,-0.4f),0.156f,Random.Range(-0.492f,0.492f)),Quaternion.Euler(0, 0, 90)) as GameObject;
					instantiatedPrefab.transform.localScale = new Vector3(1,-1,1);
				}
			}*/