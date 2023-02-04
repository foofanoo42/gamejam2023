using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : MonoBehaviour
{

    //[SerializeField] private CharacterController characterController;

    [SerializeField] private Rigidbody rigidbodyComponent;

    //private Vector3 playerVelocity = Vector3.Forward;
    private bool groundedPlayer;
    private float playerSpeed = 500000f;
    private float playerWithoutCarrotSpeed = 500000f;
    private float playerWithCarrotSpeed = 300000f;
   // private float jumpHeight = 1.0f;
    //private float gravityValue = -9.81f;

    //private float turnSpeed = 10f;

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

        //Debug.Log("Holding");

        if (!((Input.GetKey("space")) || (Input.GetButton("Fire1"))))
        {
            _holdingCarrot = false;
            thisCarrot = null;
            playerSpeed = playerWithoutCarrotSpeed;

            //Debug.Log("Dropping Carrot");

            return;

        }

        if (_holdingCarrot && thisCarrot is not null)
        {
            thisCarrot.DragToRabbit(this);
        }

    }

	public void DropCarrot()
	{
		_holdingCarrot = false;
        thisCarrot = null;
	}

	public void PickUpCarrot(Carrot carrot)
	{
		_holdingCarrot = true;
        thisCarrot = carrot;
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
        //Debug.Log(" colliding");


        if (((Input.GetKey("space"))|| (Input.GetButton("Fire1"))))
        {
            if (thisCarrot == null)
            {
                //needs to check whether it is a carrot
                thisCarrot = collision.gameObject.GetComponent<Carrot>();
                

                thisCarrot.UnPop();

                //play some sound
                _holdingCarrot = true;

                //should base on carrot size
                playerSpeed = playerWithCarrotSpeed;
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
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        
        rigidbodyComponent.AddForce(move * Time.fixedDeltaTime * playerSpeed);

        //Vector3 m_EulerAngleVelocity = new Vector3(10, 0, 0);

        //Vector3 findturn = new Vector3(0f,0f,0f);
        //turn = rigidbodyComponent.velocity;

        //Vector3 x = Vector3.Cross(rigidbodyComponent.velocity.normalized, move.normalized);
        
        //float turnSpeed = Mathf.Asin(x.magnitude);

        //Vector3 w = x.normalized * theta / Time.fixedDeltaTime;

        //Quaternion q = transform.rotation * rigidbody.inertiaTensorRotation;
        //T = q * Vector3.Scale(rigidbody.inertiaTensor, (Quaternion.Inverse(q) * w));

        //Quaternion deltaRotation = Quaternion.Euler((move * Time.fixedDeltaTime*10)-);

        //Quaternion deltaRotation;
        //deltaRotation.SetFromToRotation(rigidbodyComponent.velocity, move);
        
        
        //float turn = Vector3.Angle(rigidbodyComponent.velocity.normalised, move.normalised);

        //rigidbodyComponent.MoveRotation(deltaRotation);

        //rigidbodyComponent.AddTorque(Vector3.up * turn);

        //Vector3 x = Vector3.Cross(oldPoint.normalized, newPoint.normalized);
        //float theta = Mathf.Asin(x.magnitude);
        // Vector3 w = x.normalized * theta / Time.fixedDeltaTime;

        //if (thisCarrot != null) thisCarrot.transform.position = this.transform.position;




        //apply the torque to the rabbit - direction is up, magnitude is speed and anticlockwise/clockwise

        //rigidbodyComponent.AddTorque(transform.up * turnspeed);


    }

}
