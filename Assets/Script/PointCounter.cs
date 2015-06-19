using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PointCounter : MonoBehaviour {
	public int PointDireita=0;
	public int PointEsquerda=0;
	public bool FirstTouch = true;
	public bool LastTouchIsLeft = false;
	public PointManager Manager;
	public ParticleSystem particles;
	// Use this for initialization
	void Start () {
		Manager = GameObject.Find("Manager").GetComponent<PointManager>();
		particles = GameObject.Find("Particle System").GetComponent<ParticleSystem>();
		PointDireita=0;
		PointEsquerda=0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collider){
		if (collider.gameObject.CompareTag ("Floor")) {
			if(FirstTouch){
				FirstTouch = false;
				Manager.gameObject.GetComponent<SoundController>().PlayNeutralSound();
			}else{
				if(transform.position.x < 0) PointDireita++;
				if(transform.position.x > 0) PointEsquerda++;
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
					FirstTouch = true;
				LastTouchIsLeft = true;
			}else if(NamePlayer == "PlayerRight"){
				//if(LastTouchIsLeft) 
					FirstTouch = true;
				LastTouchIsLeft = false;
			}

		}
	}
}
