using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Move : MonoBehaviour {
	Rigidbody rb;

	void Start(){
		rb = this.GetComponent<Rigidbody>();
	}

	void Update(){
		Vector3 acceleration = Input.acceleration;

		//TODO: use low pass filter
//		if (Math.Abs (acceleration.y) < 10)
//			acceleration.y = 0f;

		rb.AddTorque (new Vector3(acceleration.x,0,acceleration.y), ForceMode.Impulse);
		rb.AddForce (new Vector3(acceleration.x,0,acceleration.y) * 250);
	}
}
