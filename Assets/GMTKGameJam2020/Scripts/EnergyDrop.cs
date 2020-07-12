using System;
using System.Collections;
using UnityEngine;

public class EnergyDrop : MonoBehaviour
{
    [SerializeField] private int _amount;
    [SerializeField] private AudioClip _collectClip;

    private AudioSource _as;

    private bool _collected = false;

    private void Start()
    {
        _as = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_collected)
        {
            return;
        }

        Energy oe = other.GetComponent<Energy>();
        if (oe == null) return;
        if (_as != null && _collectClip != null)
        {
            _as.PlayOneShot(_collectClip);
        }
        _collected = true;
        transform.localScale = Vector3.zero;
        oe.Charge(_amount);
        StartCoroutine("Destroy");
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

}
