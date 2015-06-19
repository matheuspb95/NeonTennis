using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {
	public AudioSource Down, Up, StartGame, GameOver, Neutral;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void PlayStartSound(){
		StartGame.Play ();
	}

	public void PlayGameOverSound(){
		GameOver.Play ();
	}

	public void PlayDownSound(){
		Down.Play ();
	}

	public void PlayUpSound(){
		Up.Play ();
	}

	public void PlayNeutralSound(){
		Neutral.Play ();
	}
}
