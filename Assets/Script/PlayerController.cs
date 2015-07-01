using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public enum Player {Left, Right};
	public Player Side;
	public float Force;
	private GameStarter StartReference;
	public bool AI;
	// Use this for initialization
	void Start () {
		StartReference = GameObject.Find ("Manager").GetComponent<GameStarter> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!AI) {
			foreach (Touch ActualTouch in Input.touches) {
				if (ActualTouch.phase == TouchPhase.Began) {
					Vector3 TouchPosition = Camera.main.ScreenToWorldPoint (ActualTouch.position);
					if (TouchPosition.x < 0 && Side == Player.Left) {
						if (StartReference.started) {
							Attack (Vector2.right);
						} else {
							StartReference.StartGame (Side);
						}
					} else if (TouchPosition.x > 0 && Side == Player.Right) {
						if (StartReference.started) {
							Attack (Vector2.left);
						} else {
							StartReference.StartGame (Side);
						}
					}
				}
			}
		}
	}

	public void Attack(Vector2 direction){
		GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		GetComponent<Rigidbody2D>().AddForce(direction * Force);
	}
}
