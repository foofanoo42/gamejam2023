using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotSpawner : MonoBehaviour
{

    [SerializeField] private Carrot carrotPrefab;

    [SerializeField] private int spawnInterval;

    private float _countDown = 0;

    private CarrotSpawnPoint[] _spawnPoints;

    void Start()
    {
        _countDown = spawnInterval;
        _spawnPoints = GetComponentsInChildren<CarrotSpawnPoint>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (_countDown <= 0)
        {
            Debug.Log($"Spawning Carrot");

            int randomIndex = (int) (Random.Range(0, _spawnPoints.Length));
            _spawnPoints[randomIndex].Spawn(carrotPrefab, out Carrot newCarrot);
            _countDown = spawnInterval;
        } else
        {
            _countDown -= Time.deltaTime;

            Debug.Log($"{_countDown} {Time.deltaTime}");

        }
    }
}
