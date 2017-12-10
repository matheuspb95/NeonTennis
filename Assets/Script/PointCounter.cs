using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PointCounter : MonoBehaviour {
	public int PointDireita=0;
	public int PointEsquerda=0;
	public bool FirstTouch = true;
	public bool LastTouchIsLeft = false;
	public PointManager Manager;
	public GameStarter starter;
	public ParticleSystem particles;

	float LastPosition;

	SpriteRenderer floor;
	// Use this for initialization
	void Start () {
		floor = GameObject.FindGameObjectWithTag("Floor").GetComponent<SpriteRenderer>();
		Manager = GameObject.Find("Manager").GetComponent<PointManager>();
		starter = Manager.GetComponent<GameStarter>();
		particles = GameObject.Find("Particle System").GetComponent<ParticleSystem>();
		PointDireita=0;
		PointEsquerda=0;
	}
	
	// Update is called once per frame
	void Update () {
		if(!FirstTouch){
			if((LastPosition < 0 && transform.position.x > 0) || (LastPosition > 0 && transform.position.x < 0)){
				FirstTouch = true;
				floor.color = Color.green;
			}
		}
		
		LastPosition = transform.position.x;
	}

	void OnCollisionEnter2D(Collision2D collider){
		if (collider.gameObject.CompareTag ("Floor")) {			
			particles.transform.position = transform.position;
			particles.startColor = floor.color;
			particles.Play();
			if(FirstTouch){				
				FirstTouch = false;
				floor.color = Color.red;
				Manager.gameObject.GetComponent<SoundController>().PlayNeutralSound();
			}else{
				FirstTouch = true;
				floor.color = Color.green;
				if(transform.position.x < 0) {
					PointDireita++;
					starter.ResetBall(true);
				}
				if(transform.position.x > 0) {
					PointEsquerda++;
					starter.ResetBall(false);
				}
				particles.transform.position = transform.position;
				particles.startColor = collider.gameObject.GetComponent<SpriteRenderer>().color;
				Manager.gameObject.GetComponent<SoundController>().PlayDownSound();
				particles.Play();
				Manager.ActualizeScore (PointEsquerda, PointDireita);
			}
		}
		if (collider.gameObject.CompareTag ("Player")) {
			particles.transform.position = transform.position;
			particles.startColor = collider.gameObject.GetComponent<SpriteRenderer>().color;
			particles.Play();
			Manager.gameObject.GetComponent<SoundController>().PlayUpSound();
			string NamePlayer = collider.gameObject.name;
			if(NamePlayer == "PlayerLeft"){
				//if(!LastTouchIsLeft) 
				LastTouchIsLeft = true;
			}else if(NamePlayer == "PlayerRight"){
				//if(LastTouchIsLeft) 
				LastTouchIsLeft = false;
			}
			FirstTouch = true;
			floor.color = Color.green;
		}
	}
}
