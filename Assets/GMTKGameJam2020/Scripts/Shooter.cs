using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject _ammo;
    [SerializeField] private int _cost = 1;
    public float rad = 0f;

    public void Shoot(Vector3 pos, float angle)
    {
        var d = GetComponent<Energy>();
        if (d != null)
        {
            d.Drain(_cost);
        }

        var go = Instantiate(_ammo, pos, Quaternion.Euler(0f, angle, 0f));
    }
}
