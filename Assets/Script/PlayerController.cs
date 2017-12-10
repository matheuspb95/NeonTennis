using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public enum Player {Left, Right};
	public Player Side;
	public float Force;
	private GameStarter StartReference;
	public bool AI;
	public GameObject AIcontroller;
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
							Attack (Vector2.right, 1);
							return;
						} else {
							StartReference.StartGame (Side);
							return;
						}
					} else if (TouchPosition.x > 0 && Side == Player.Right) {
						if (StartReference.started) {
							Attack (Vector2.left, 1);
							return;
						} else {
							StartReference.StartGame (Side);
							return;
						}
					}
				}
			}
			if(Input.GetMouseButtonDown(0)){
				Vector3 TouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				if(TouchPosition.x < 0 && Side == Player.Left){
					if(StartReference.started){
						Attack (Vector2.right, 1);
					}else{
						StartReference.StartGame (Side);
					}
					return;
				}else if(TouchPosition.x > 0 && Side == Player.Right){
					if(StartReference.started){
						Attack (Vector2.left, 1);
					}else{
						StartReference.StartGame (Side);
					}
					return;
				}
			}
			if(Input.GetButtonDown("Fire1") && Side == Player.Left){
				if (StartReference.started) {
					Attack (Vector2.right, 1);
					return;
				} else {
					StartReference.StartGame (Side);
					return;
				}
			}
			if(Input.GetButtonDown("Fire2") && Side == Player.Right){
				if (StartReference.started) {
					Attack (Vector2.left, 1);
					return;
				} else {
					StartReference.StartGame (Side);
					return;
				}
			}		}
	}

	public void SetAI(bool value){
		AI = value;
		AIcontroller.SetActive(value);
	}

	public void Attack(Vector2 direction, float forceMultiplier){
		GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		GetComponent<Rigidbody2D>().AddForce(direction * Force * forceMultiplier);
	}
}
