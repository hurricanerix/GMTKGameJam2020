using Assets.GMTKGameJam2020.Scripts.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorHealth : Health
{

    [SerializeField] private List<GameObject> _spawnables;


    private void Fragment(Vector3 position)
    {
        foreach ( GameObject spawnable in _spawnables)
        {
            print("I GOT HERE!");
            var fragment = Instantiate(spawnable, position, Quaternion.identity);
            var rv = Helpers.GetRandomVelocity( Vector3.one * 5, Vector3.one * 5);
            print("Random Velocity " + rv);
            fragment.GetComponent<Rigidbody>().AddForceAtPosition(rv, rv, ForceMode.VelocityChange);
        }
        return;
    }

    public override void Die()
    {
        Fragment(transform.position);
        Destroy(gameObject);
    }
}
