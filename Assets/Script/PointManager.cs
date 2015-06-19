using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PointManager : MonoBehaviour {
	public Text ScoreText;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ActualizeScore(int ScoreEsq, int ScoreDir){		
		ScoreText.text = ScoreEsq + "x" + ScoreDir;
		if (ScoreEsq >= 10) {
			ScoreText.text += "\nPlayer 1 Wins";
			GetComponent<EndGame>().endGame();
		}else if(ScoreDir >= 10){
			ScoreText.text += "\nPlayer 2 Wins";
			GetComponent<EndGame>().endGame();
		}
	}
}
