using System.Collections;
using UnityEngine;

public class Transporter : MonoBehaviour
{
    [SerializeField] private Vector2 _bounds = new Vector2(100, 60);

    private void Start()
    {
        StartCoroutine("TransportLoop");
    }

    private IEnumerator TransportLoop()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);

            var x = transform.position.x;
            if (Mathf.Abs(x) > _bounds.x)
            {
                x *= -1;
            }

            var z = transform.position.z;
            if (Mathf.Abs(z) > _bounds.y)
            {
                z *= -1;
            }

            transform.position = new Vector3(x, transform.position.y, z);
        }
    }
}
