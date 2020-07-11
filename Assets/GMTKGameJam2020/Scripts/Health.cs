using UnityEngine;

public class Health : MonoBehaviour
{
    public delegate void destroyedFunc(bool destroyed);

    [SerializeField] private int _hp = 1;

    public void Damage(int amount)
    {
        Damage(amount, null);
    }

    public void Damage(int amount, destroyedFunc callback)
    {
        Debug.LogFormat("Health({0}:{1}).Damage({2})", gameObject.name, gameObject.GetInstanceID(), amount);
        _hp = Mathf.Max(0, _hp - amount);
        if (_hp != 0)
        {
            callback(false);
            return;
        }

        if (callback != null)
        {
            callback(true);
        }
        Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
