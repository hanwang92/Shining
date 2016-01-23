using UnityEngine;
using System.Collections;

public class end_collide : MonoBehaviour {
	
	public GameObject end;
	float fadeSpeed = 0.003f;   
	public Color TextColor;
	bool endgame = false;
	public GameObject cuber;
	public AudioSource audioE;
	bool playend;

	void Update()
	{
		end.GetComponent<Renderer>().material.color = TextColor;
		if (endgame) {
			if(playend == false)
			   {
				audioE.Play (500);
				playend = true;
			}
			StartCoroutine (Begin ());
			StartCoroutine (End ());
		}
	}

	void Start () 
	{
		FadeOut();
		playend = false;
	}
	
	void OnTriggerEnter(Collider other)
	{
		print("Detected collision Enter");
		AudioSource audioS = (AudioSource)cuber.GetComponent("AudioSource");
		audioS.Stop ();
		endgame = true;
	}
	
	void OnTriggerStay(Collider other)
	{
		print("Detected collision Stay");
	}
	
	void OnTriggerExit(Collider other)
	{
		print("Detected collision Exit");
	}

	void FadeIn()     
	{         
		TextColor.a += fadeSpeed;     
	}

	void FadeOut()
	{
		TextColor.a = 0.0f;     
	}

	IEnumerator Begin ()
	{
		yield return new WaitForSeconds (1);
		FadeIn ();
	}

	IEnumerator End ()
	{
		yield return new WaitForSeconds (5);
		audioE.Stop ();
		yield return new WaitForSeconds (2);
		Application.LoadLevel(0);
	}
}
