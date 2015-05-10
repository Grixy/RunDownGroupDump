using UnityEngine;
using System.Collections;

public class RandomSprite : MonoBehaviour {
	public Sprite Rock1;
	public Sprite Rock2;
	public Sprite Rock3;
	public Sprite Rock4;


	// Use this for initialization
	void Start () {

					int chosen = Random.Range(1,4);
					switch (chosen) {
				case (1):
						gameObject.GetComponent<SpriteRenderer> ().sprite = Rock1; 
						break;
				case (2):
						gameObject.GetComponent<SpriteRenderer> ().sprite = Rock2; 
						break;
				case (3):
						gameObject.GetComponent<SpriteRenderer> ().sprite = Rock3; 
						break;
				case (4):
						gameObject.GetComponent<SpriteRenderer> ().sprite = Rock4; 
						break;
				}

					//gameObject.GetComponent<SpriteRenderer> ().sprite = RandomSprite(Rock1, Rock2, Rock3, Rock4);

				}
	// Update is called once per frame
	void Update () {
	
	}
}
