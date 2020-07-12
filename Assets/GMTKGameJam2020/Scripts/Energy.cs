using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour
{
    [SerializeField] private int _max = 100;
    [SerializeField] private int _upkeep = 1;

    [SerializeField] private Image _ui;
    
    [SerializeField]
    [Range(0, 1)]
    private float _uiT = 0.9f;

    public int Current {get { return _current; }}

    private int _current;

    private void Start()
    {
        _current = _max;
        if (_ui != null)
        {
            _ui.fillAmount = 1;
        }
        StartCoroutine("Upkeep");
    }

    private IEnumerator Upkeep()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            Drain(_upkeep);
        }
    }

    public void Drain(int amount)
    {
        _current = Mathf.Max(0, _current - amount);
    }

    public void Charge(int amount)
    {
        print("Charging " + amount);
        _current = Mathf.Min(_max, _current - amount);
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
