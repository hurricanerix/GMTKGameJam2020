using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Shooter))]
public class Player : MonoBehaviour
{

    [SerializeField]
    public float rotationSpeed = 80.0f;

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
    }

    private void handleInput()
    {
        float ha = Input.GetAxis("Horizontal");
        Vector3 rotationalVelocity = new Vector3();

        if (ha > 0)
        {

            rotationalVelocity.y = rotationSpeed;
            //rotation.y = rotationSpeed * Time.deltaTime;
        } else if (ha < 0)
        {
            rotationalVelocity.y = -rotationSpeed;
        }

        Quaternion deltaRotation = Quaternion.Euler(rotationalVelocity * Time.deltaTime);
        rigidBody.MoveRotation(rigidBody.rotation  * deltaRotation);

    }
}
