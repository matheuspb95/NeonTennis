using UnityEngine;
using System.Collections;

public class AdjustPositionToCamera : MonoBehaviour {
	public Vector2 ViewPort;
	// Use this for initialization
	void Start () {
		transform.position = Camera.main.ViewportToWorldPoint (ViewPort);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
