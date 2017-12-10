using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SceneColorController : MonoBehaviour {
	public List<Color> Colors;
	public SpriteRenderer[] Players;
	public SpriteRenderer Floor;
	public Text ScoreText;
	public Image RestartButton;	
	public Image BackButton;
	// Use this for initialization
	void Start () {
		int i = Random.Range (0, Colors.Count - 1);
		Players [0].color = Colors [i];
		Colors.RemoveAt (i);
		i = Random.Range (0, Colors.Count - 1);
		Players [1].color = Colors [i];
		Colors.RemoveAt (i);
		//i = Random.Range (0, Colors.Count - 1);
		//Floor.color = Colors [i];
		//Colors.RemoveAt (i);
		i = Random.Range (0, Colors.Count - 1);
		ScoreText.color = Colors [i];
		Colors.RemoveAt (i);
		i = Random.Range (0, Colors.Count - 1);
		RestartButton.color = Colors [i];
		Colors.RemoveAt (i);
		i = Random.Range (0, Colors.Count - 1);
		BackButton.color = Colors [i];
		Colors.RemoveAt (i);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
