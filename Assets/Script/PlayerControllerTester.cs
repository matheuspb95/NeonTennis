using UnityEngine;
using System.Collections;

public class PlayerControllerTester : MonoBehaviour {
	public enum Player {Left, Right};
	public Player Side;
	public float Force;
	private GameStarter StartReference;
	// Use this for initialization
	void Start () {
		StartReference = GameObject.Find ("Manager").GetComponent<GameStarter> ();
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			Vector3 TouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			if(TouchPosition.x < 0 && Side == Player.Left){
				if(StartReference.started){
					GetComponent<Rigidbody2D>().velocity = Vector2.zero;
					GetComponent<Rigidbody2D>().AddForce(new Vector2(Force,0));
				}else{
					StartReference.StartGame(GetComponent<PlayerController>().Side);
				}
			}else if(TouchPosition.x > 0 && Side == Player.Right){
				if(StartReference.started){
					GetComponent<Rigidbody2D>().velocity = Vector2.zero;
					GetComponent<Rigidbody2D>().AddForce(new Vector2(-Force,0));
				}else{
					StartReference.StartGame(GetComponent<PlayerController>().Side);
				}
			}
		}
	}
}
