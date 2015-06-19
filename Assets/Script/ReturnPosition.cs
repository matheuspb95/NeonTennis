using UnityEngine;
using System.Collections;

public class ReturnPosition : MonoBehaviour {
	public float ReturnForce, InitialPositionCameraRelativeX, InitialPositionY;
	// Use this for initialization
	void Start () {
		InitialPositionY = transform.position.y;
		Vector3 position = Camera.main.ViewportToWorldPoint (new Vector3(InitialPositionCameraRelativeX, 0, 0));
		transform.position = new Vector3 (position.x, transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (transform.position.x, InitialPositionY, transform.position.z);
	}

	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.CompareTag ("Rede")) {
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			if(GetComponent<PlayerController>().Side == PlayerController.Player.Left) 
			   GetComponent<Rigidbody2D>().AddForce(new Vector2(-ReturnForce,0));
			if(GetComponent<PlayerController>().Side == PlayerController.Player.Right) 
			   GetComponent<Rigidbody2D>().AddForce(new Vector2(ReturnForce,0));;
		}
	}
}
