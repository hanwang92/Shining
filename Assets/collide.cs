using UnityEngine;
using System.Collections;
//using System;




public class collide : MonoBehaviour {

	public GameObject object1;
	public GameObject object2; 
	public GameObject object3;
	public GameObject tile1;
	public GameObject tile2; 
	public GameObject tile3;
	public GameObject tile4;
	public GameObject floor17;

	public GameObject end_wall;
	public GameObject end_light;

	private bool hide1show2 = false; // hide object1 when true, object2 otherwise
	int iteration;


	void Start () 
	{
		iteration = 0;
		object1 = GameObject.FindWithTag("Wall1");
		object2 = GameObject.FindWithTag("Wall2");
		object3 = GameObject.FindWithTag("Wall3");
		HideShow(); 
		
	}

	void OnTriggerEnter(Collider other)
	{
		print("Detected collision Enter");


		//hide1show2 = !hide1show2; // toggle hide1show2
		HideShow(); // apply the new hide1show2 state


	}
	
	void OnTriggerStay(Collider other)
	{
		print("Detected collision Stay");

	}
	
	void OnTriggerExit(Collider other)
	{
		print("Detected collision Exit");
	}

	void HideShow()
	{ // hide/show objects
		if (iteration == 0) {
			object1.SetActive (true);
			object2.SetActive (false);
			object3.SetActive (false);

			tile1.SetActive (true);
			tile2.SetActive (false);
			tile3.SetActive (false);
			tile4.SetActive (false);

			end_wall.SetActive (false);
			end_light.SetActive (false);
			//iteration = 3;
		} 

		else {

			if (nfmod (iteration, 3) == 0){
				print("End: ");
				Debug.Log(nfmod (iteration, 3));
				object1.SetActive (false);
				object2.SetActive (true);
				object3.SetActive (false);

				tile1.SetActive (false);
				tile2.SetActive (false);
				tile3.SetActive (true);
				tile4.SetActive (true);

				floor17.SetActive (false);
				end_wall.SetActive (true);
				end_light.SetActive (true);
			}
			if (nfmod (iteration, 3) != 0){
				print("IN LOOP: ");
				Debug.Log(nfmod (iteration, 3));
				object1.SetActive (false);
				object2.SetActive (false);
				object3.SetActive (true);

				tile1.SetActive (false);
				tile2.SetActive (true);
				tile3.SetActive (false);
				tile4.SetActive (false);
			}
		}

		iteration = iteration + 1;
	}

	float nfmod(float a,float b)
	{

		return a - b * Mathf.Floor (a / b);
	}



}
