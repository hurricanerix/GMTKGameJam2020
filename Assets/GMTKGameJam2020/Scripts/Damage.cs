using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private int _damage = 1;
    [SerializeField] private string[] _tags;

    private void OnTriggerEnter(Collider other)
    {
        Debug.LogFormat("Damage({0}:{1}).OnTriggerEnter({2})", gameObject.name, gameObject.GetInstanceID(), other.tag);
        if (IgnoreDamage(other.tag))
        {
            Debug.LogFormat("Damage({0}:{1}).OnTriggerEnter: IgnoreDamage", gameObject.name, gameObject.GetInstanceID());
            return;
        }

        var h = other.GetComponent<Health>();
        if (h == null)
        {
            Debug.LogFormat("Damage({0}:{1}).OnTriggerEnter: No Health", gameObject.name, gameObject.GetInstanceID());
            return;
        }

        h.Damage(_damage);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.LogFormat("Damage({0}:{1}).OnCollisionEnter({2})", gameObject.name, gameObject.GetInstanceID(), collision.gameObject.tag);
        if (IgnoreDamage(collision.gameObject.tag))
        {
            Debug.LogFormat("Damage({0}:{1}).OnCollisionEnter: IgnoreDamage", gameObject.name, gameObject.GetInstanceID());
            return;
        }

        var h = collision.gameObject.GetComponent<Health>();
        if (h == null)
        {
            Debug.LogFormat("Damage({0}:{1}).OnCollisionEnter: No Health", gameObject.name, gameObject.GetInstanceID());
            return;
        }

        h.Damage(_damage);
    }

    private bool IgnoreDamage(string tag)
    {
        for (var i = 0; i < _tags.Length; i++)
        {
            if (tag == _tags[i])
            {
                return false;
            }
        }
        return true;
    }
}
