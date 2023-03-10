using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{

    [SerializeField] private Rigidbody rigidbodyComponent;
    [SerializeField] private float foxSpeed = 1000;
    [SerializeField] private Rabbit theRabbit;

    private float moveTime = 2;
    private int huntTime = 10;
    private bool moveMode = false;
    private bool huntMode = false;
    private Vector3 moveDirection;
    private Quaternion newDirection;

    [SerializeField] private SoundManager soundMan;

    private Rabbit thisRabbit;
     
    
    // Start is called before the first frame update
    void Start()
    {
        moveDirection = new Vector3(Random.Range(-1f, 1f),0f, Random.Range(-1f, 1f));
        moveDirection.Normalize();

        newDirection = Quaternion.Euler(moveDirection);
        transform.rotation = newDirection;
        moveDirection *= 10f;

    }

    // Update is called once per frame
    void Update()
    {

        moveTime -= Time.deltaTime;

        if (moveTime <= 0)
        {
            //switch to stopping
            moveMode = !moveMode;
            

            //reset time
            moveTime = 2;
            huntMode = false;

            //find a new random direction
            moveDirection.x = Random.Range(-1f, 1f);
            moveDirection.z = Random.Range(-1f, 1f);
            moveDirection.Normalize();
            moveDirection *= 10f;

            huntTime--;

            Debug.Log("steps 'till hunting: " + huntTime);

            if (huntTime <=0)
            {
                soundMan.PlaySound(3);
                moveMode = false;
                moveTime = 8;
                huntMode = true;
                huntTime = 8 + (int)Random.Range(0,10);

            }


            // Find the angle from point on a x z plane
            float radianAngle = Mathf.Atan2(moveDirection.x, moveDirection.z);
            float angle = 180 * radianAngle / Mathf.PI;
            
            transform.rotation = Quaternion.Euler(0, angle, 0);

        }

        
    }

    void FixedUpdate()
    {
        if (moveMode)
        {
            rigidbodyComponent.AddForce(moveDirection * Time.fixedDeltaTime * foxSpeed);
            //transform.rotation = newDirection;

            if (rigidbodyComponent.velocity.magnitude > 1)
            {
                rigidbodyComponent.velocity = rigidbodyComponent.velocity.normalized * 1;
                //transform.rotation = Quaternion.Euler(rigidbodyComponent.velocity.normalized);
                //transform.rotation = Quaternion.FromToRotation(Vector3.zero,  rigidbodyComponent.velocity);
            }

        }

        if (huntMode)

        {
            Debug.Log("hunting mode");
            //find direction towards the rabbit.
            Vector3 rabbitDir = new Vector3();
                
            rabbitDir.x = theRabbit.transform.position.x- this.transform.position.x;
            rabbitDir.y = 0;
            rabbitDir.z = theRabbit.transform.position.z - this.transform.position.z;
            transform.rotation = Quaternion.FromToRotation(Vector3.forward, rabbitDir);

            rabbitDir.Normalize();
            rabbitDir *= 10f;

            rigidbodyComponent.AddForce(rabbitDir * Time.fixedDeltaTime * foxSpeed*0.7f);
            //transform.rotation = newDirection;

            if (rigidbodyComponent.velocity.magnitude > 0.7f)//huntmode moves slower
            {
                rigidbodyComponent.velocity = rigidbodyComponent.velocity.normalized * 0.7f;
                //transform.rotation = Quaternion.Euler(rigidbodyComponent.velocity.normalized);
                //transform.rotation = Quaternion.FromToRotation(Vector3.zero,  rigidbodyComponent.velocity);
            }
        }
                
                //transform.rotation *= Quaternion.Euler(0, Time.fixedDeltaTime,0);
        //Debug.Log($"{transform.rotation}");
        
    }


    private void OnCollisionEnter(Collision collision)
    {

        thisRabbit = collision.gameObject.GetComponent<Rabbit>();
        if (thisRabbit is null)
        {
            return;
        }


        if (foxSpeed > 0f)
        {
            Debug.Log("fox collided with rabbit");
            thisRabbit.KillRabbit();
            foxSpeed = 0f;
        }

    }
}
