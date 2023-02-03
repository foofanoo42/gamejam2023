using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : MonoBehaviour
{

    [SerializeField] private CharacterController characterController;

    [SerializeField] private Rigidbody rigidbodyComponent;

    //private Vector3 playerVelocity = Vector3.Forward;
    private bool groundedPlayer;
    private float playerSpeed = 100000.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    private GameObject thisCarrot;
   

    // Update is called once per frame
    void Update()
    {
        //groundedPlayer = controller.isGrounded;
        //if (groundedPlayer && playerVelocity.y < 0)
        //{
        //    playerVelocity.y = 0f;
        //}

        //Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //Debug.Log(move);

        //characterController.Move(move * Time.deltaTime * playerSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(" collided");

        thisCarrot = collision.gameObject;


        //foreach (ContactPoint contact in collision.contacts)
        //{

        //}
        //if (collision.relativeVelocity.magnitude > 2)

    }

    void FixedUpdate()
    {
        //if (rigidbodyComponent == null) rigidbodyComponent = GetComponent<Rigidbody>();
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        
        rigidbodyComponent.AddForce(move * Time.deltaTime * playerSpeed);

        if (thisCarrot != null) thisCarrot.transform.position = this.transform.position;
    }

}
