﻿using UnityEngine;  
using System.Collections;
using System; 


public class CarController : MonoBehaviour { 


	// Car rigidbody COM
	public Transform centerOfMass;

	// Wheel motor for drive the car based on wheelJoint 2D
	JointMotor2D motorBack;  

	// Which wheel to drive with that?
	public WheelJoint2D motorWheel;

	// Store car speed
	public float speed ;   

	// Store is grounded based on the distance of the ground
	public bool isGrounded;

	// How much distance of the ground means cars is grounded? answer=> less than 2.1f
	public float groundDistance = 2.1f ;

	// Motor power, Brake power and deceleration speed
	public float motorPower = 1400f,
	brakePower = -14f,
	 decelerationSpeed = 0.3f;

	// Car max speed
	public float maxSpeed = 14f;

	// inrenal usage
	float motorTemp;

	// Can rotate option. be true value when car is on the fly
	bool canRotate = false;

	// Rotate force on the  fly 
	public float RotateForce = 20f;

	[HideInInspector]public AudioSource EngineSoundS;

	public bool isMobile;
	public bool start = false;

	// Internal usage
	float powerTemp;

	public bool useSmoke;
	public ParticleSystem smoke;
	public float smokeTargetSpeed = 17f;

	public float cameraDistance = 15f;

	void Awake()
	{
		Vector3 posCamera;
		posCamera = Camera.main.transform.position;
		Camera.main.transform.position = new Vector3 (posCamera.x, posCamera.y, - cameraDistance);
	}

	void Start () { 


		// Set car rigidbody's COM
		GetComponent<Rigidbody2D>().centerOfMass = centerOfMass.transform.localPosition;

		// Starting with WheelJoint2D motor
		motorBack = motorWheel.motor; 

		// Cast a ray to find isGrounded 
		StartCoroutine (RaycCast ());

		EngineSoundS = GetComponent<AudioSource> ();

		powerTemp = motorPower;


	}  

	float currentSpeed;    
	//float maxspeed = 300f;

	void FixedUpdate(){
		if (start) {
			// speed limiter based on max speed limit value
			if (speed > maxSpeed)
				motorPower = 0;
			else
				motorPower = powerTemp;
		
			// Moving forward
			if (Input.GetAxis ("Horizontal") > 0 || HoriTemp > 0) {

				// Add force to car back wheel
				if (isGrounded)
					motorBack.motorSpeed = Mathf.Lerp (motorBack.motorSpeed, -motorPower, Time.deltaTime * 1.4f);

				// Wheel particles
				if (isGrounded) {
					if (speed < 4.3f) {

					}
				}

			} else {// Moving backward
				if (Input.GetAxis ("Horizontal") < 0 || HoriTemp < 0) {
					if (speed < -maxSpeed) {
						if (isGrounded)
							motorBack.motorSpeed = Mathf.Lerp (motorBack.motorSpeed, 0, Time.deltaTime * 3f);
					} else {
						if (isGrounded)
							motorBack.motorSpeed = Mathf.Lerp (motorBack.motorSpeed, motorPower, Time.deltaTime * 1.4f);
					}
                                                                                      
				} else {// Releasing car throttle and brake
					if (isGrounded)
						motorBack.motorSpeed = Mathf.Lerp (motorBack.motorSpeed, 0, Time.deltaTime * decelerationSpeed);	
				}

			}

			// Update WheelJoint2D motor inputs

			motorWheel.motor = motorBack; 
			if (isGrounded == false) {
				canRotate = true;
			}
			// Cheack fo rotate on the fly
			if (canRotate) {
				Rotate ();
			}

			#if UNITY_EDITOR
			EngineSoundEditor ();  
			#else
		EngineSoundMobile (); 
			#endif

			if (!isMobile)
				HoriTemp = Input.GetAxis ("Horizontal");

		}
	}

	public void  StartGame(){
		start = true;
	}

	void LateUpdate()
	{

		// Get car speed
		speed = GetComponent<Rigidbody2D>().velocity.magnitude;
		if (Input.GetAxis ("Horizontal") < 0 || HoriTemp < 0) 
			speed = -speed;
	}

	// Rotate car on air based on speed
	public void Rotate()
	{
		float x = Input.acceleration.x;
		if (x != 0) {
			//based on player forward input(Like Hill Climb Racing game)
			if (Input.GetAxis ("Horizontal") < 0 || HoriTemp < 0 || x < 0) {
				GetComponent<Rigidbody2D> ().AddTorque (RotateForce);
			} else {

				if (Input.GetAxis ("Horizontal") > 0.0f || HoriTemp > 0 || x > 0)
					GetComponent<Rigidbody2D> ().AddTorque (-RotateForce);
			}
		}
	}

	// Raycast body to find that car is on the ground or not
	IEnumerator RaycCast()
	{

		while (true) 
		{
			
			yield return new WaitForEndOfFrame();

			RaycastHit2D hit = Physics2D.Raycast (transform.position, -Vector2.up, 1000);

			float distance = Mathf.Abs(hit.point.y - transform.position.y);

		//	canRotate = !isGrounded;  	

		}

	}

	// Engine sound system

	public float Multiplyer = 3f;
	public float minP = 1f;
	public float maxP = 2.4f;
	float HoriTemp;

	public void  EngineSoundMin ()
	{
		if (EngineSoundS.pitch > minP)
			EngineSoundS.pitch -= 1.4f * Time.deltaTime;
	}

	public void EngineSoundMobile ()
	{
		
		if (speed < 40) 
		{
			EngineSoundS.pitch = Mathf.Lerp (EngineSoundS.pitch, Mathf.Clamp (HoriTemp * Multiplyer, minP, maxP), Time.deltaTime * 5);
		} 
		else 
		{
			EngineSoundS.pitch = Mathf.Lerp (EngineSoundS.pitch, Mathf.Clamp (HoriTemp * Multiplyer, minP, maxP), Time.deltaTime * 5);
		}
	}

	public void EngineSoundEditor ()
	{

		if (speed < 40) 
		{
			EngineSoundS.pitch = Mathf.Lerp (EngineSoundS.pitch, Mathf.Clamp (Input.GetAxis ("Horizontal") * Multiplyer, minP, maxP), Time.deltaTime * 5);
		} 
		else 
		{
			EngineSoundS.pitch = Mathf.Lerp (EngineSoundS.pitch, Mathf.Clamp (Input.GetAxis ("Horizontal") * Multiplyer, minP, maxP), Time.deltaTime * 5);
		}
	}

	// Vehicle input system
	//this is public function for car Acceleration UI Button
	public void Acceleration ()
	{
		HoriTemp = 1f;
	}
	//this is public function for car Brake\Backward UI Button
	public void Brake ()
	{
		HoriTemp = -1f;
	}


	//this is for when player both release Brake or Acceleration button
	public void GasBrakeRelease ()
	{
		HoriTemp = 0;
	}

	void AccelometerMove(){
		float x = Input.acceleration.x;
		if (x < 0) {

		} else if (x > 0) {

		} else {
			//Set Zero Rotation
		}
	}
}