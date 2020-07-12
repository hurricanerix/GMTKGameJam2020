using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(Shooter))]
public class Player : MonoBehaviour
{

    [SerializeField] private float rotationSpeed = 80.0f; 


    private Rigidbody _rb;
    private Shooter _shooter;
    private Thruster _thruster;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _shooter = GetComponent<Shooter>();
        _thruster = GetComponent<Thruster>();
    }

    private void Update()
    {
        HandleRotation(Input.GetAxis("Horizontal"));
        if (Input.GetButton("Thrust")) _thruster.Thrust();
        if (Input.GetButtonDown("Fire1")) HandleFire();
    }

    // TODO: Should this be pulled into a component??
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
        _rb.MoveRotation(_rb.rotation * deltaRotation);
    }

    private void HandleFire()
    {
        _shooter.Shoot(transform.position, transform.rotation.eulerAngles.y);
    }
}
