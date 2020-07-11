using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(Shooter))]
public class Player : MonoBehaviour
{

    [SerializeField]
    public float rotationSpeed = 80.0f; 
    
    [SerializeField]
    public float thrustSpeed = 10.0f;



    Rigidbody rigidBody;
    private Shooter _shooter;

    private void Awake()
    {
        _shooter = GetComponent<Shooter>();
    }

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        handleInput();
        if (Input.GetButtonDown("Fire1"))
        {
            _shooter.Shoot(transform.position, transform.rotation.eulerAngles.y);
        }
        Debug.DrawRay(transform.position, transform.rotation.eulerAngles);
        HandleInput();
    }

    private void HandleInput()
    {
        float ha = Input.GetAxis("Horizontal");
        float thrust = Input.GetAxis("Thrust");
        
        if (ha != 0)
        {
            HandleRotation(ha);
        }

        if (thrust != 0)
        {
            HandleThrust();
        }

    }

    private void HandleThrust()
    {
        print("Velocity : " + rigidBody.velocity);
        rigidBody.velocity = new Vector3(rigidBody.velocity.x + thrustSpeed, 0, rigidBody.velocity.z + thrustSpeed);
    }

    private void HandleRotation(float inputRotation)
    {
        Vector3 rotationalVelocity = new Vector3();

        if (inputRotation > 0)
        {
            rotationalVelocity.y = rotationSpeed;
        }
        else if (inputRotation < 0)
        {
            rotationalVelocity.y = -rotationSpeed;
        }

        Quaternion deltaRotation = Quaternion.Euler(rotationalVelocity * Time.deltaTime);
        rigidBody.MoveRotation(rigidBody.rotation * deltaRotation);
        print("Rotation " + rigidBody.rotation);
    }


}
