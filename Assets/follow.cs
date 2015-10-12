using UnityEngine;
using System.Collections;

public class follow : MonoBehaviour
{
	//public CNAbstractController RotateJoystick;
	//public float RotationSpeed = 10f;
	
	//private Transform _transformCache;
	//private Transform _parentTransformCache;


	//######
	public float distanceAway;			// distance from the back of the craft
	public float distanceUp;			// distance above the craft
	public float smooth;				// how smooth the camera movement is
	
	private Vector3 targetPosition;		// the position the camera is trying to be in
	
	Transform camera;
	//#####




	
	// Use this for initialization
	void Start()
	{
		//_transformCache = GetComponent<Transform>();
		//_parentTransformCache = _transformCache.parent;

		//###
		camera = GameObject.FindWithTag ("Player").transform;	
		//###
	}
	
	// Update is called once per frame
	void Update()
	{/*
		if (RotateJoystick != null)
		{
			float rotationX = RotateJoystick.GetAxis("Horizontal") * RotationSpeed * Time.deltaTime;
			float rotationY = RotateJoystick.GetAxis("Vertical") * RotationSpeed * Time.deltaTime;
			_parentTransformCache.Rotate(0f, rotationX, 0f, Space.World);
			_parentTransformCache.Rotate(-rotationY, 0f, 0f);
		}*/

	}

	//###
	void LateUpdate ()
	{
		// setting the target position to be the correct offset from the hovercraft
		//targetPosition = camera.position + Vector3.up * distanceUp;// + camera.forward * distanceAway;
		targetPosition = camera.position + Vector3.up * distanceUp - camera.forward * distanceAway;

		
		// making a smooth transition between it's current position and the position it wants to be in
		transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smooth);
		
		// make sure the camera is looking the right way!
		transform.LookAt (camera.transform.position+camera.transform.forward*6);
		//transform.LookAt(camera);
	}
	//###

}






/*



using UnityEngine;
using System.Collections;

public class follow : MonoBehaviour
{
	public float distanceAway;			// distance from the back of the craft
	public float distanceUp;			// distance above the craft
	public float smooth;				// how smooth the camera movement is
	
	private Vector3 targetPosition;		// the position the camera is trying to be in
	
	Transform camera;
	
	void Start(){
		camera = GameObject.FindWithTag ("Player").transform;	
	}
	
	void LateUpdate ()
	{
		// setting the target position to be the correct offset from the hovercraft
		targetPosition = camera.position + Vector3.up * distanceUp;// + camera.forward * distanceAway;
		
		// making a smooth transition between it's current position and the position it wants to be in
		transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smooth);
		
		// make sure the camera is looking the right way!
		transform.LookAt (camera.transform.position+camera.transform.forward*6);
		//transform.LookAt(camera);
	}
}




*/