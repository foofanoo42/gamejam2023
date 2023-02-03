using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotSpawnPoint : MonoBehaviour
{

    private Carrot myCarrot;

    public bool Spawn(Carrot carrotPrefab, out Carrot newCarrot)
    {

        if (myCarrot is not null)
        {
            newCarrot = myCarrot;
            return false;
        }

        newCarrot = myCarrot = GameObject.Instantiate(carrotPrefab);
        newCarrot.transform.position = transform.position;
        return true;

    }

}
