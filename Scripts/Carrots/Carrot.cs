using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{

    //[SerializeField] private CharacterController controller;

    [SerializeField] private Rigidbody rigidbodyComponent;

	[SerializeField] private int size;
	public int Size => size;

	public Rabbit Holder { get; set; }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(" collided");
        
        

        //foreach (ContactPoint contact in collision.contacts)
        //{

        //}
        //if (collision.relativeVelocity.magnitude > 2)

    }

    public void DragToRabbit(Rabbit rabbit)
    {
        //controller.Move(rabbit.transform.position - transform.position * 0.7f  );
        //transform.position += (rabbit.transform.position - transform.position) * 0.7f;
        //controller.Move(  );

        //Debug.Log("Dragging Carrot");

        rigidbodyComponent.AddForce((rabbit.transform.position - transform.position) * 5.7f);



    }


}
