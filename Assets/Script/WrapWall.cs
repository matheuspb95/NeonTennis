using UnityEngine;
using System.Collections;

public class WrapWall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collision){
		GameObject other = collision.gameObject;
		if (other.CompareTag ("Ball")) {
			Vector3 position = other.transform.position;
			other.transform.position = new Vector3(-0.9f*position.x, position.y, position.z);
		}
	}
}
