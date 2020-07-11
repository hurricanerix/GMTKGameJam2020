using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    private Mover mover;


    private void Awake()
    {
        mover = GetComponent<Mover>();
    }
    // Update is called once per frame
    void Update()
    {
       if (Input.GetAxis("Horizontal") != 0)
       {
            mover.Move(false, Input.GetAxis("Horizontal"));
       }
       if (Input.GetAxis("Vertical") != 0)
       {
            Debug.Log("I just moved " + Input.GetAxis("Horizontal"));
       }
    }


}

