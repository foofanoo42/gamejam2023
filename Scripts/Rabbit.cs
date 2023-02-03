using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : MonoBehaviour
{

    //[SerializeField] private CharacterController characterController;

    [SerializeField] private Rigidbody rigidbodyComponent;

    //private Vector3 playerVelocity = Vector3.Forward;
    private bool groundedPlayer;
    private float playerSpeed = 100000.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    private Carrot thisCarrot;

    private bool _holdingCarrot = false;


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

        if (!_holdingCarrot)
        {
            return;
        }

        Debug.Log("Holding");

        if (!Input.GetKey("space"))
        {
            _holdingCarrot = false;
            thisCarrot = null;

            Debug.Log("Dropping Carrot");

            return;

        }

        if (_holdingCarrot && thisCarrot is not null)
        {
            thisCarrot.DragToRabbit(this);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(" collided");

        //thisCarrot = collision.gameObject;

        //thisCarrot.transform.rotation = Quaternion.Euler(90, 0,0);

        //foreach (ContactPoint contact in collision.contacts)
        //{

        //}
        //if (collision.relativeVelocity.magnitude > 2)

    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log(" colliding");


        if (Input.GetKey("space"))
        {
            if (thisCarrot == null)
            {
                thisCarrot = collision.gameObject.GetComponent<Carrot>();
                //thisCarrot.transform.rotation = Quaternion.Euler(90, 0, 0);
                _holdingCarrot = true;
            }

            //if (thisCarrot != null)
            //{
            //    thisCarrot.transform.position = this.transform.position + new Vector3(0.5f, 0, 0);
            //}
        }


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

        //if (thisCarrot != null) thisCarrot.transform.position = this.transform.position;
    }

}
