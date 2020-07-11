using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _ttl = 2f;

    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        StartCoroutine("SelfDestruct");
        var radians = (transform.rotation.eulerAngles.y) * Mathf.Deg2Rad;
        var dir = new Vector3(Mathf.Sin(radians), 0f, Mathf.Cos(radians));
        Debug.DrawRay(transform.position, dir * 10, Color.red, 1f);        
        _rb.AddForce(dir * 10000, ForceMode.Acceleration);
    }

    private IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(_ttl);
        Destroy(gameObject);
    }
}
