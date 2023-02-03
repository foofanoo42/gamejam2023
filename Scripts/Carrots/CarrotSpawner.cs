using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotSpawner : MonoBehaviour
{

    [SerializeField] private carrot carrotPrefab;

    [SerializeField] private CarrotSpawnPoint[] spawnPoints;

    [SerializeField] private int spawnInterval;

    private int _countDown = 0;

    void Start()
    {
        _countDown = spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (_countDown <= 0)
        {
            int randomIndex = (int) (Random.Range(0, spawnPoints.Length));
            spawnPoints[randomIndex].Spawn(carrotPrefab);
            _countDown = spawnInterval;
        } else
        {
            _countDown -= (int) Time.deltaTime;
        }
        

    }
}
