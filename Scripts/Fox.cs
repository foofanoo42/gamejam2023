using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{

    [SerializeField] private Rigidbody rigidbodyComponent;
    [SerializeField] private float foxSpeed = 1000;

    private float moveTime = 2;
    private bool moveMode = false;
    private Vector3 moveDirection;
    private Quaternion newDirection;
    

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
            
            //find a new random direction
            moveDirection.x = Random.Range(-1f, 1f);
            moveDirection.z = Random.Range(-1f, 1f);
            moveDirection.Normalize();
            moveDirection *= 10f;

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
        
        Debug.Log("fox collided with rabbit");
        thisRabbit.KillRabbit();

    }
}
