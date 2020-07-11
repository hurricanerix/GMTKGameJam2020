using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public delegate void destroyedFunc(bool destroyed);

    [SerializeField] private int _max = 1;

    [SerializeField] private Image _ui;

    [SerializeField]
    [Range(0, 1)]
    private float _uiT = 0.9f;

    private int _current;

    private void Start()
    {
        _current = _max;
    }

    public void Damage(int amount)
    {
        Damage(amount, null);
    }

    public void Damage(int amount, destroyedFunc callback)
    {
        Debug.LogFormat("Health({0}:{1}).Damage({2})", gameObject.name, gameObject.GetInstanceID(), amount);
        _current = Mathf.Max(0, _current - amount);
        if (_current != 0)
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
        // TODO: make sure health is updated before destroying.
        Destroy(gameObject);
    }

    private void LateUpdate()
    {
        if (_ui == null)
        {
            return;
        }
        _ui.fillAmount = Mathf.Lerp(((float)_current) / _max, _ui.fillAmount, _uiT);        
    }
}
