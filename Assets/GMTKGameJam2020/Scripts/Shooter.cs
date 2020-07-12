using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject _ammo;
    public float rad = 0f;

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

        var go = Instantiate(_ammo, pos, Quaternion.Euler(0f, angle, 0f));
    }
}
