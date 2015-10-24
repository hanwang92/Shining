using UnityEngine;
using System.Collections;

public class getsprite : MonoBehaviour {

	public Sprite spriteImage;

	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer> ().sprite = spriteImage;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
