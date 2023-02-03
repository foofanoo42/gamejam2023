using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotSpawnPoint : MonoBehaviour
{

    [SerializeField] private Carrot spawnedCarrot;

    public bool Spawn(Carrot carrotPrefab, out Carrot newCarrot)
    {

        if (spawnedCarrot is not null)
        {
            newCarrot = spawnedCarrot;
            return false;
        }

        newCarrot = spawnedCarrot = GameObject.Instantiate(carrotPrefab);
        newCarrot.transform.position = transform.position;
        return true;

    }

    void OnTriggerExit(Collider other)
    {
        // unlink the spawned carrot 
        spawnedCarrot = null;
    }
    
}
