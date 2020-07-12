using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class Scorer : MonoBehaviour
{

    [SerializeField]
    private int _incrementValue = 1;

    private Player _player;
    private Text _score;
    private Health _health;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _score = GameObject.FindGameObjectWithTag("Score").GetComponentInChildren<Text>();
        _health = GetComponent<Health>();
        _health.AddOnDieListener(Increment);
    }


    public void Increment()
    {
        _player.Score += _incrementValue;
        _score.text = "Score : " + _player.Score;
    }

}
