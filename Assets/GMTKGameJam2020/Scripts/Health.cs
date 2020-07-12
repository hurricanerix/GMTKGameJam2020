using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using System.Collections;

public class Health : MonoBehaviour
{
    private UnityEvent _onDie = new UnityEvent();

    [SerializeField] private int _max = 1;

    [SerializeField] private Image _ui;

    [SerializeField]
    [Range(0, 1)]
    private float _uiT = 0.9f;

    [SerializeField] private AudioClip _damageClip;
    [SerializeField] private AudioClip _deathClip;

    [SerializeField] private GameObject _destroyFX;

    private AudioSource _as;

    public bool Destroyed { get { return _current <= 0; } }

    private int _current;
    private GameObject _destroyFXInstance = null;

    private void Start()
    {
        _current = _max;
        _as = GetComponent<AudioSource>();
    }

    public void AddOnDieListener(UnityAction call)
    {
        _onDie.AddListener(call);
    }

    public void Damage(int amount)
    {
        Debug.LogFormat("Health({0}:{1}).Damage({2})", gameObject.name, gameObject.GetInstanceID(), amount);
        _current = Mathf.Max(0, _current - amount);
        if (_current != 0)
        {
            if (_as != null && _damageClip != null)
            {
                _as.PlayOneShot(_damageClip);
            }
            return;
        }       
        Die();
    }

    public void Die()
    {
        Debug.LogFormat("Health({0}:{1}).Die()", gameObject.name, gameObject.GetInstanceID());
        _onDie.Invoke();
        transform.localScale = Vector3.zero;
        if (_as != null && _deathClip != null)
        {
            _as.PlayOneShot(_deathClip);
        }
        if (_destroyFX != null)
        {
            _destroyFXInstance = Instantiate(_destroyFX, transform.position, Quaternion.identity);
        }
        StartCoroutine("Destroy");
    }
  
    private void LateUpdate()
    {
        if (_ui == null)
        {
            return;
        }
        _ui.fillAmount = Mathf.Lerp(((float)_current) / _max, _ui.fillAmount, _uiT);        
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(5);
        Debug.LogFormat("Health({0}:{1}).Destroy()", gameObject.name, gameObject.GetInstanceID());
        Destroy(_destroyFXInstance);
        Destroy(gameObject);
    }
}
