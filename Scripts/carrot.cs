using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carrot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(" collided");
        
        

        //foreach (ContactPoint contact in collision.contacts)
        //{

        //}
        //if (collision.relativeVelocity.magnitude > 2)

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
