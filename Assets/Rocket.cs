using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    Rigidbody rigidBody;
    AudioSource audioSource;

	// initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        RocketMovementInput();
	}

     void RocketMovementInput()
    {
        if (Input.GetKey(KeyCode.W))        // thrust
        {
            rigidBody.AddRelativeForce(Vector3.up);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
         
            print("thrust");
        }
        else
        {
            audioSource.Stop();
        }
        if (Input.GetKey(KeyCode.A))        
        {
            transform.Rotate(Vector3.forward);
            print("left");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward);
        }
    }
}
