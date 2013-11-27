﻿using UnityEngine;
using System.Collections;

public class CameraRotation : MonoBehaviour
{
	
		public GameObject startObject;
		public GameObject endObject;
		public int speed;
		public float anglesToChange;
	
		private Vector3 movement;
		private Vector3 inverseMovement;
		private Vector3 rotate;

		private Quaternion startRotation;
		private Quaternion endRotation;
		private Quaternion targetRotation;
		private Quaternion currentFixedRotation;


		void Start ()
		{
		
				transform.LookAt (startObject.transform.position);
				
				startRotation = Quaternion.Euler (transform.eulerAngles.x, transform.eulerAngles.y, 0);
				transform.rotation = startRotation;
				//print ("Starting Z rotation:" + transform.rotation.eulerAngles.z);
		
				transform.LookAt (endObject.transform.position);

				endRotation = Quaternion.Euler (transform.eulerAngles.x, transform.eulerAngles.y, 0);
				/*movement = new Vector3 (endRotation.x - startRotation.x, endRotation.y - startRotation.y, 0);
				movement.z = 0;
				inverseMovement = new Vector3 (-movement.x, -movement.y, 0);
				inverseMovement.z = 0;*/
		
				//rotate = movement;
		
				//Debug.Log ("Start: x:" + startRotation.x + " y:" + startRotation.y + " z:" + startRotation.z);
				//Debug.Log ("End: x:" + endRotation.x + " y:" + endRotation.y + " z:" + endRotation.z);
				transform.rotation = startRotation;
				targetRotation = endRotation;
		}

		void Update ()
		{
				if (endObject != null) {
						ChangePosition (); 
				}
		}
	
		void ChangePosition ()
		{
				transform.rotation = Quaternion.RotateTowards (transform.rotation, targetRotation, speed * Time.deltaTime);
				currentFixedRotation = Quaternion.Euler (transform.eulerAngles.x, transform.eulerAngles.y, 0);
				transform.rotation = currentFixedRotation;
				
				//Target control
				if (Quaternion.Angle (transform.rotation, targetRotation) <= anglesToChange) {
						targetRotation = targetRotation == startRotation ? endRotation : startRotation;
				}
		}

}