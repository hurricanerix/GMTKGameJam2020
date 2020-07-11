using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    public float rotationSpeed = 80.0f;

    Rigidbody rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();  
    }


    // Update is called once per frame
    void Update()
    {
        handleInput();
    }

    private void handleInput()
    {
        float ha = Input.GetAxis("Horizontal");
        Vector3 rotation = new Vector3();

        if (ha > 0)
        {
            rigidBody.rotation = Quaternion.Euler(0.0f, rotationSpeed, 0);
            //rotation.y = rotationSpeed * Time.deltaTime;
        } else if (ha < 0)
        {
            rotation.y = -rotationSpeed * Time.deltaTime;
        }

        transform.Rotate(rotation, Space.Self);

    }
}
