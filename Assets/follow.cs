using UnityEngine;
using System.Collections;

public class follow : MonoBehaviour
{
	public float distanceAway;			// Distance from the back of the player
	public float distanceUp;			// Distance above the player
	public float smooth;				// How smooth the camera movement is
	private Vector3 targetPosition;		// The position the camera is trying to be in
	
	Transform camera;
    
	// Use this for initialization
	void Start()
	{
		camera = GameObject.FindWithTag ("Player").transform;	
	}

	void LateUpdate ()
	{
		// Setting the target position to be the correct offset from the hovercraft
		targetPosition = camera.position + Vector3.up * distanceUp - camera.forward * distanceAway;
		
		// Making a smooth transition between it's current position and the position it wants to be in
		transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smooth);
		
		// Make sure the camera is looking the right way!
		transform.LookAt (camera.transform.position+camera.transform.forward*6);
	}
}