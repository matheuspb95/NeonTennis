using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameStarter : MonoBehaviour {
	public bool started = false;
	public GameObject ball;
	public Text InitText;
	// Use this for initialization
	void Start () {
		GetComponent<SoundController> ().PlayStartSound ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void StartGame(PlayerController.Player side){
		started = true;
		if (side == PlayerController.Player.Left) {
			Instantiate (ball, new Vector3 (-5, 2, 0), Quaternion.identity);
		} else if (side == PlayerController.Player.Right) {
			Instantiate(ball, new Vector3(5,2,0), Quaternion.identity);
		}
		InitText.text = "0x0";
	}
}