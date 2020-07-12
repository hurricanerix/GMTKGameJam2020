using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.GMTKGameJam2020.Scripts.Helpers;

using Random = UnityEngine.Random;

[RequireComponent(typeof(Health))]
public class Drop : MonoBehaviour
{
    [SerializeField] private List<GameObject> _drops;
    [SerializeField] private int _dropCount;

    private void Start()
    {
        GetComponent<Health>().AddOnDieListener(OnDie);
    }

    private void OnDie()
    {
        Debug.LogFormat("Health({0}:{1}).OnDie()", gameObject.name, gameObject.GetInstanceID());
        for (var i = 0; i < _dropCount; i++)
        {
            var drop = GetRandomDrop();
            var go = Instantiate(drop, transform.position, Quaternion.identity);
            var v = Helpers.GetRandomVelocity( Vector3.one * 5, Vector3.one * 5);
            go.GetComponent<Rigidbody>().AddForceAtPosition(v, v, ForceMode.VelocityChange);
        }
    }

    private GameObject GetRandomDrop()
    {
        var i = Random.Range(0, _drops.Count);
        Debug.LogFormat("Health({0}:{1}).GetRandomDrop(): {2}", gameObject.name, gameObject.GetInstanceID(), i);
        return _drops[i]; 
    }
}
