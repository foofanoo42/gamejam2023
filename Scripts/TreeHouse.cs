using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeHouse : MonoBehaviour
{

    //[SerializeField] private LayerMask layer; 

    private void OnTriggerEnter(Collider other)
    {
        
        Debug.Log($"Collided with {other.gameObject.name} {layer.value} {other.gameObject.layer}");
    
        if (LayerMask.NameToLayer("Carrot") == other.gameObject.layer) {
            Debug.Log("Carrot Point Score");
        }
        else {
              Debug.Log("Not a Carrot");
        }
        
    }
    
}
