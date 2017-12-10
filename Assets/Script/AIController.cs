using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour {
	public Vector2 direction;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//GetComponent<BoxCollider2D> ().offset = new Vector2 ((-offset-transform.parent.position.x)/divisor, 1);
		transform.localScale = new Vector3 (-transform.parent.position.x, transform.localScale.y, 0);
		
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.CompareTag ("Ball")) {
			Debug.Log("Attack");
			float randomForce = Random.Range(0.8f, 1.2f);
			transform.parent.GetComponent<PlayerController>().Attack(direction, randomForce);
		}
	}

	void OnTriggerStay2D(Collider2D collider){
		if (collider.gameObject.CompareTag ("Ball")) {
			if(collider.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude <= 1f){
				float randomForce = Random.Range(0.8f, 1.2f);
				transform.parent.GetComponent<PlayerController>().Attack(direction, randomForce);
			}
		}
	}
}
