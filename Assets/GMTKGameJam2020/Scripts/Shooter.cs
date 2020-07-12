using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject _ammo;
    [SerializeField] private int _cost = 1;
    [SerializeField] private AudioClip _fireClip;

    public float rad = 0f;

    private AudioSource _as;

    private void Start()
    {
        _as = GetComponent<AudioSource>();
    }

    public void Shoot(Vector3 pos, float angle)
    {
        var goh = GetComponent<Health>();
        if (goh != null)
        {
            if (goh.Destroyed)
            {
                Debug.LogFormat("Shooter({0}:{1}).Shoot: Destroyed", gameObject.name, gameObject.GetInstanceID());
                return;
            }
        }

        var d = GetComponent<Energy>();
        if (d != null)
        {
            d.Drain(_cost);
        }

        _as.PlayOneShot(_fireClip);
        var go = Instantiate(_ammo, pos, Quaternion.Euler(0f, angle, 0f));
    }
}
