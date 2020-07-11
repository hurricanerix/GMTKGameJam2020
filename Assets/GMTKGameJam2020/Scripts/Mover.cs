using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]
    public float rotationSpeed = 1.0f;
    
    [SerializeField]
    public float thrustSpeed = 1.0f;
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(bool thrust, float rotate)
    {

        if (rotate > 0){
            transform.Rotate(0.0f,  rotationSpeed * Time.deltaTime, 0.0f, Space.Self);
        } else if (rotate < 0)
        {
            transform.Rotate(0.0f,-rotationSpeed * Time.deltaTime, 0.0f, Space.Self);
        }
    }
}
