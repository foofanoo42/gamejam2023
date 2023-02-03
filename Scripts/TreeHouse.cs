using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeHouse : MonoBehaviour
{

    //[SerializeField] private LayerMask layer; 

	public delegate void PointsGainedHandler(int pointsGained);

	public static event PointsGainedHandler OnPointsGained; 

    private void OnTriggerEnter(Collider other)
    {
        
        Debug.Log($"Collided with {other.gameObject.name} {other.gameObject.layer}");
    
        if (LayerMask.NameToLayer("Carrot") == other.gameObject.layer) {

            Debug.Log("Carrot Point Score");

			Carrot collidedCarrot = other.gameObject.GetComponent<Carrot>();
			OnPointsGained.Invoke(collidedCarrot.Size);

			// If the rabbit is still holding the carrot get it to drop the carrot
			if (collidedCarrot.Holder is not null)
			{
				collidedCarrot.Holder.DropCarrot();
			} 

			Object.Destroy(other.gameObject);
	

        }
        else {
              Debug.Log("Not a Carrot");
        }
        
    }
    
}
