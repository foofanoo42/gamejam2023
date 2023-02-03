using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotSpawnPoint : MonoBehaviour
{

    public carrot Spawn(carrot carrot)
    {

        var newCarrot = GameObject.Instantiate(carrot);

        return newCarrot;

    }

}
