using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {
	public float speed;
	private float height;
	private float Sensitivity;

	public enum RotationAxes { 
		MouseXAndY = 0, 
		MouseX = 1, 
		MouseY = 2 }
	
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 15F;
	public float sensitivityY = 15F;
	public float minimumX = -360F;
	public float maximumX = 360F;
	public float minimumY = -60F;
	public float maximumY = 60F;
	float rotationY = 0F;

	// Use this for initialization
	void Start () {

		height = transform.position.y;
		Sensitivity = transform.localScale.x *140;

	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (transform.position.x, height, transform.position.z);
		//movement
		if (Input.GetKey(KeyCode.S))
		{
			transform.position -= transform.forward * speed * Sensitivity;

		}
		if (Input.GetKey(KeyCode.W))
		{
			transform.position += transform.forward * speed * Sensitivity;

		}
		if (Input.GetKey(KeyCode.A))
		{
			transform.position -= transform.right * speed/3*2 * Sensitivity;

		}
		if (Input.GetKey(KeyCode.D))
		{
			transform.position += transform.right * speed/3*2 *Sensitivity;

		}

		//solution taken from slack overflow.com accessed 27 April 2015 http://stackoverflow.com/questions/21945082/make-player-move-forward-right-left-and-backwards-based-on-camera-angle
			if (axes == RotationAxes.MouseXAndY)
			{
				float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
				rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
				rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
				transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
			}
			
			else if (axes == RotationAxes.MouseX)
			{
				transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
			}
			
			else
			{
				rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
				rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
				transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
			}

	}
}
