using System.Collections;
using UnityEngine;
using Assets.GMTKGameJam2020.Scripts.Helpers;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _spawnPool;
    [SerializeField] private float _rate = 5f;
    [SerializeField] private float _variation = 1f;
    [SerializeField] private Vector3 _minVelocity = Vector3.one * -20;
    [SerializeField] private Vector3 _maxVelocity = Vector3.one * 20;

    private void Start()
    {
        StartCoroutine("SpawnLoop");
    }

    private IEnumerator SpawnLoop()
    {
        while(true)
        {
            yield return new WaitForSeconds(_rate + Random.Range(_variation * -1, _variation));
            var spawnIndex = SelectSpawn();
            Spawn(spawnIndex);
        }
    }

    private int SelectSpawn()
    {
        return Random.Range(0, _spawnPool.Length -1);
    }

    private void Spawn(int index)
    {
        var pos = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0,Screen.width), Random.Range(0,Screen.height), Camera.main.farClipPlane/2));
        pos.y = 0f;
        var go = Instantiate(_spawnPool[index], pos, GetRandomRotation());
        var rb = go.GetComponent<Rigidbody>();
        var v = Helpers.GetRandomVelocity(_maxVelocity, _minVelocity);
        rb.AddForceAtPosition(v, v, ForceMode.VelocityChange);
    }

    private Quaternion GetRandomRotation()
    {
        // TODO: nice to have.
        return Quaternion.identity;
    }

}
