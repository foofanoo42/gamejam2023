using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Ui;

public class Rabbit : MonoBehaviour
{

    //[SerializeField] private CharacterController characterController;

    [SerializeField] private Animator animator;
    
    [SerializeField] private Rigidbody rigidbodyComponent;

    [SerializeField] private float rotSpeed = 50f;
    [SerializeField] private SoundManager soundMan;
    
    [SerializeField] private ScoreBoard scoreBoard;


    //private Vector3 playerVelocity = Vector3.Forward;
    private bool groundedPlayer;
    private float playerSpeed = 900f;
    private float playerWithoutCarrotSpeed = 900f;
    private float playerWithCarrotSpeed = 600f;
        
    
   // private float jumpHeight = 1.0f;
    //private float gravityValue = -9.81f;

    //private float turnSpeed = 10f;

    private Carrot thisCarrot;

    private bool _holdingCarrot = false;
    private bool _alive = true;
    private float _maxspeed = 1f;


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
            _maxspeed = 1f;

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

    public void KillRabbit()
    {
        //_holdingCarrot = true;
        //thisCarrot = carrot;

        if (_alive)
        {
            soundMan.PlaySound(10);
            scoreBoard.QuickHunger();
        }

        _alive = false;
        transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        //SceneManager.LoadScene(SceneUtil.ScoreScene);

        
        

        //rigidbodyComponent.AddForce(new Vector3(0f, 10f, 0f));

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
                
                // the interactable is not a carrot we do not care
                if (thisCarrot is null)
                {
                    return;
                }

                thisCarrot.UnPop();

                soundMan.PlaySound(1);



                //play some sound
                _holdingCarrot = true;

                //should base on carrot size
                playerSpeed = playerWithCarrotSpeed;
                _maxspeed = 0.5f;
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


        if (_alive)
        {

            //move the rabbit
            rigidbodyComponent.AddForce(move * Time.fixedDeltaTime * playerSpeed);

            //check and apply max speed
            if (rigidbodyComponent.velocity.magnitude > _maxspeed)
            {
                rigidbodyComponent.velocity = rigidbodyComponent.velocity.normalized * _maxspeed;
            }

        }
        //max speed
       


                //scale it to max speed


            //Vector3 m_EulerAngleVelocity = new Vector3(10, 0, 0);

            //Vector3 findturn = new Vector3(0f,0f,0f);
        Vector3 turn = rigidbodyComponent.velocity;

        turn.y = 0f;
        turn.Normalize();



        move.y = 0f;
        move.Normalize();


        Vector3 modelRot = transform.rotation* Vector3.forward;
        //Vector3 x = Vector3.Cross(oldPoint.normalized, newPoint.normalized);

        Vector3 x = Vector3.Cross(modelRot, turn) ;

        float c = Vector3.Dot(modelRot, turn);
        float s = x.y;
        
        if(c<0)
        {
            if (s < 0)
            {
                x.y = -1f;
            }

            else
            {
                x.y = 1f;
            }
        }
        x *= Time.fixedDeltaTime * rotSpeed;


        //Debug.Log("turn is: "+ turn + x + "rotation is:" + transform.rotation);

        rigidbodyComponent.AddTorque(x);

        
        //Vector3 q = Vector3.Scale(rigidbody.inertiaTensor, (Quaternion.Inverse(q) * w));


        //Vector3 x = Vector3.Cross(rigidbodyComponent.velocity.normalized, move.normalized);

        //float turnSpeed = Mathf.Asin(x.magnitude);

        //Vector3 w = x.normalized * theta / Time.fixedDeltaTime;

        //Quaternion q = transform.rotation * rigidbody.inertiaTensorRotation;


        //Quaternion deltaRotation = Quaternion.Euler((move * Time.fixedDeltaTime*10)-);

        //Quaternion deltaRotation;
        //deltaRotation.SetFromToRotation(rigidbodyComponent.velocity, move);


        //float turn = Vector3.Angle(rigidbodyComponent.velocity.normalised, move.normalised);

        //rigidbodyComponent.MoveRotation(deltaRotation);

        //oldPoint = new 

        //rigidbodyComponent.AddTorque(Vector3.up * turn);





        //float theta = Mathf.Asin(x.magnitude);
        // Vector3 w = x.normalized * theta / Time.fixedDeltaTime;

        //if (thisCarrot != null) thisCarrot.transform.position = this.transform.position;




        //apply the torque to the rabbit - direction is up, magnitude is speed and anticlockwise/clockwise




    }

}
