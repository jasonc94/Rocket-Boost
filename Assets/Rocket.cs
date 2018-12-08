using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{

    Rigidbody rigidBody;
    AudioSource audioSource;
    [SerializeField] float rcsThrust = 200f;
    [SerializeField] float thrustPower = 20f;

    // initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Thrust();
        Rotate();
    }


    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                print("ok");
                break;
            default:
                print("dead");
                break;
        }
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.W))
        {
          
            rigidBody.AddRelativeForce(Vector3.up * thrustPower);
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
    }
    void Rotate()
    {
        rigidBody.freezeRotation = true;    //manual rotation

        float rotationSpeed = Time.deltaTime * rcsThrust;
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationSpeed);
            print("left");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationSpeed);
        }

        rigidBody.freezeRotation = false;  //physic rotaion
    }


}
