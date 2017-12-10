using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameStarter : MonoBehaviour {
	public bool started = false;
	public GameObject ballPrefab, ball;
	float gravity;
	public Text InitText;
	public static int players;
	public PlayerController playerLeft, playerRight;
	// Use this for initialization
	void Start () {
		GetComponent<SoundController> ().PlayStartSound ();
		gravity = ballPrefab.GetComponent<Rigidbody2D>().gravityScale;
		if(players == 1){
			playerLeft.SetAI(false);
			playerRight.SetAI(true);
		} else if(players == 2){
			playerLeft.SetAI(false);
			playerRight.SetAI(false);
		} else {
			print("Valor de player errado");
			playerLeft.SetAI(true);
			playerRight.SetAI(true);
		}
		StartCoroutine(AutoStart());
	}
	
	// Update is called once per frame
	void Update () {

	}

	public static void setPlayers(int p){
		players = p;
	}

	public void StartGame(){
		StopAllCoroutines();
		if(!started){
			started = true;
			if(ball == null){
				ball = Instantiate (ballPrefab, new Vector3 (-5, 0, 0), Quaternion.identity);
				InitText.text = "0x0";	
			} else {
				ball.GetComponent<Rigidbody2D>().gravityScale = gravity;
			}
		}
	}


	public void StartGame(PlayerController.Player side){
		if(!started){
			started = true;
			if(ball == null){
				if (side == PlayerController.Player.Left) {
					ball = Instantiate (ballPrefab, new Vector3 (-5, 0, 0), Quaternion.identity);
				} else if (side == PlayerController.Player.Right) {
					ball = Instantiate (ballPrefab, new Vector3(5, 0, 0), Quaternion.identity);
				}
				InitText.text = "0x0";	
			} else {
				ball.GetComponent<Rigidbody2D>().gravityScale = gravity;
			}
		}
	}

	public void ResetBall(bool isLeft){
		
		if(isLeft){
			ball.transform.position = new Vector3 (-5, 0, 0);
		}else{
			ball.transform.position = new Vector3 (5, 0, 0);
		}
		ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		ball.GetComponent<Rigidbody2D>().gravityScale = 0;
		StartCoroutine(AutoStart());
		//Destroy(ball);
		started = false;
	}

	IEnumerator AutoStart(){
		yield return new WaitForSeconds(3);
		StartGame();
	}
}