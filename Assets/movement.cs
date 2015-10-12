using System;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]


public class movement : MonoBehaviour {
	
	
	protected Animator animator;
	public float DirectionDampTime = .25f;
	public bool ApplyGravity = true; 
	public float smooth;
	public CNAbstractController MovementJoystick;
	public Color TextColor;
	public GameObject start;




	bool fadeIn = false;     
	bool fadeOut = false;     
	float fadeSpeed = 0.02f;     
	float minAlpha = 0.0f;     
	float maxAlpha = 1.0f;

	// Use this for initialization
	void Start () 
	{
		animator = GetComponent<Animator>();

		TextColor =  start.GetComponent<Renderer> ().material.color;
		
		if(animator.layerCount >= 2)
			animator.SetLayerWeight(1, 1);
	}
	
	// Update is called once per frame
	void Update () 
	{
		var movement = new Vector3(
			MovementJoystick.GetAxis("Horizontal"),
			0f,
			MovementJoystick.GetAxis("Vertical"));

		start.GetComponent<Renderer> ().material.color = TextColor;

		if (animator)
		{
			//AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);			
			
			
			//float h = Input.GetAxis("Horizontal");
			//float v = Input.GetAxis("Vertical");
			
			//animator.SetFloat("Speed", h*h+v*v);
			//animator.SetFloat("Speed", h);
			//transform.position += transform.forward * Time.deltaTime * 5;
			FadeOut();

			if ((movement.z > 0)&&(Mathf.Abs(movement.x) < 0.4)){
				//iTween.FadeTo(start, iTween.Hash("alpha", 1, "oncompletetarget", start, "oncomplete", "destroy"));
				//iTween.ValueTo(start, iTween.Hash("from", 1.0f, "to", 0.0f,"time", 3f, "easetype", "linear","onupdate", "setAlpha"));
				//iTween.FadeTo(gameObject, iTween.Hash("alpha", 0, "delay", 3));

				//TextColor.a = TextColor.a-0.1f; 
				//gameObject.renderer.material.color = TextColor;
				//Fade.use.Alpha(GetComponent(TextMesh).renderer.material, 0.0, 1.0, 2.0);
				//FadeOut();
				transform.position += transform.forward * Time.deltaTime * 5;

			}
			if ((movement.z < 0)&&(Mathf.Abs(movement.x) < 0.4)){
				//iTween.FadeTo(start, iTween.Hash("alpha", 1, "oncompletetarget", start, "oncomplete", "destroy"));
				//iTween.FadeTo(gameObject, iTween.Hash("alpha", 0, "delay", 3)); 
				//FadeOut();

				//iTween.ValueTo(start, iTween.Hash("from", 1.0f, "to", 0.0f,"time", 3f, "easetype", "linear","onupdate", "setAlpha"));
				transform.position -= transform.forward * Time.deltaTime * 5;

			}
			if ((movement.x < 0)&&(Mathf.Abs(movement.z) < 0.4)){
				//iTween.FadeTo(gameObject, iTween.Hash("alpha", 0, "delay", 3)); 
				//FadeOut();

				//iTween.FadeTo(start, iTween.Hash("alpha", 1, "oncompletetarget", start, "oncomplete", "destroy"));
				//iTween.ValueTo(start, iTween.Hash("from", 1.0f, "to", 0.0f,"time", 3f, "easetype", "linear","onupdate", "setAlpha"));
				animator.transform.Rotate(0.0f, -60.0f*Time.deltaTime, 0.0f);

			}
			if ((movement.x > 0)&&(Mathf.Abs(movement.z) < 0.4)){
				//iTween.FadeTo(gameObject, iTween.Hash("alpha", 0, "delay", 3)); 
				//FadeOut();

				//iTween.FadeTo(start, iTween.Hash("alpha", 1, "oncompletetarget", start, "oncomplete", "destroy"));
				//iTween.ValueTo(start, iTween.Hash("from", 1.0f, "to", 0.0f,"time", 3f, "easetype", "linear","onupdate", "setAlpha"));
				animator.transform.Rotate(0.0f, 60.0f*Time.deltaTime, 0.0f);

			}

			/*

			if (Input.GetButton("Horizontal")){
				transform.position += transform.forward * Time.deltaTime * 5;
				//animator.transform.Translate(0.0f, 90.0f*Time.deltaTime, 0.0f);
				//animator.SetFloat("bodyRotation", 90);
			}
			if (Input.GetButton("Vertical")){
				transform.position -= transform.forward * Time.deltaTime * 5;
				//animator.SetFloat("bodyRotation", 90);
			}
			if (Input.GetButton("Mouse X")){
				animator.transform.Rotate(0.0f, -90.0f*Time.deltaTime*2, 0.0f);
				//animator.SetFloat("bodyRotation", 90);
			}
			if (Input.GetButton("Mouse Y")){
				animator.transform.Rotate(0.0f, 90.0f*Time.deltaTime*2, 0.0f);
				//animator.SetFloat("bodyRotation", 90);
			}
			
			*/


			//animator.SetFloat("Direction", h, DirectionDampTime, Time.deltaTime);	
		}


		
		
		if (Input.GetButton("Submit"))
			Application.LoadLevel(0);
	}

	void FadeIn()     
	{         
		TextColor.a += fadeSpeed;     
	}          
	void FadeOut()     
	{         
		//while (TextColor.a > minAlpha) {
		StartCoroutine (Begin ());
		

			//TextColor.a -= fadeSpeed;
		//}
		     
	}

	IEnumerator Begin ()
	{
		yield return new WaitForSeconds (2);
		TextColor.a -= fadeSpeed;

	}
	



}

