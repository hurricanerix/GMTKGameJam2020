using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEditor;
using UnityEngine;

public class Thruster : MonoBehaviour
{

    [SerializeField] private float _thrustSpeed = 10.0f;
    [SerializeField] private int _cost = 1;

    private Rigidbody _rb;
    private Energy _energy;

    private float _thrustCostInterval;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _energy = GetComponent<Energy>();
    }

    public void Thrust()
    {
        print("ThrustCostInterval: " + _thrustCostInterval);
        var radians = (transform.rotation.eulerAngles.y) * Mathf.Deg2Rad;
        var dir = new Vector3(Mathf.Sin(radians), 0f, Mathf.Cos(radians));
        _rb.AddForce(dir * _thrustSpeed, ForceMode.Acceleration);

        if (_thrustCostInterval < Time.time)
        {
            _energy.Drain(_cost);
            _thrustCostInterval = Time.time + 1.0f;
        }
    }
}
