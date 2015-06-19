using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {
	private GameObject Ball;
	private RestartGame restart;
	private bool CanRestart;
	// Use this for initialization
	void Start () {
		restart = GetComponent<RestartGame> ();
		CanRestart = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Ball == null) {
			Ball = GameObject.FindGameObjectWithTag("Ball");
		}
//		if (CanRestart) {
//			foreach(Touch touch in Input.touches){
//				if(touch.phase == TouchPhase.Began){
//					restart.Restart();
//				}
//			}
//		
//		}
	}

	public void endGame(){
		GetComponent<SoundController> ().PlayGameOverSound ();
		Ball.SetActive (false);
		CanRestart = true;
	}
}
