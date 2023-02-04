using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{

    private Rabbit thisRabbit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    private void OnCollisionEnter(Collision collision)
    {

        thisRabbit = collision.gameObject.GetComponent<Rabbit>();
        Debug.Log("fox collided with rabbit");
        thisRabbit.KillRabbit();
    }
}
