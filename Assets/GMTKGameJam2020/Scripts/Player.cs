using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(Shooter))]
public class Player : MonoBehaviour
{

    [SerializeField] private float rotationSpeed = 80.0f; 
    [SerializeField] private float thrustSpeed = 10.0f;

    private Rigidbody _rb;
    private Shooter _shooter;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _shooter = GetComponent<Shooter>();
    }

    private void Update()
    {
        HandleRotation(Input.GetAxis("Horizontal"));
        if (Input.GetButton("Thrust")) HandleThrust();
        if (Input.GetButtonDown("Fire1")) HandleFire();
    }

    private void HandleThrust()
    {
        Debug.LogFormat("Velocity: {0}", _rb.velocity);
        var radians = (transform.rotation.eulerAngles.y) * Mathf.Deg2Rad;
        var dir = new Vector3(Mathf.Sin(radians), 0f, Mathf.Cos(radians));
        _rb.AddForce(dir * thrustSpeed, ForceMode.Acceleration);
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
        _rb.MoveRotation(_rb.rotation * deltaRotation);
        Debug.LogFormat("Rotation: {0}", _rb.rotation);
    }

    private void HandleFire()
    {
        _shooter.Shoot(transform.position, transform.rotation.eulerAngles.y);
    }
}
