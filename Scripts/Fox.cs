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
    

    private Rabbit thisRabbit;

    // Start is called before the first frame update
    void Start()
    {
        moveDirection = new Vector3(Random.Range(-1f, 1f),0f, Random.Range(-1f, 1f));
        moveDirection.Normalize();
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

        }

        
    }

    void FixedUpdate()
    {
        if (moveMode)
        {
            rigidbodyComponent.AddForce(moveDirection * Time.fixedDeltaTime * foxSpeed);

            if (rigidbodyComponent.velocity.magnitude > 1) ;
            {
                rigidbodyComponent.velocity = rigidbodyComponent.velocity.normalized * 1; 
            }

        }
    }


    private void OnCollisionEnter(Collision collision)
    {

        thisRabbit = collision.gameObject.GetComponent<Rabbit>();
        Debug.Log("fox collided with rabbit");
        thisRabbit.KillRabbit();
    }
}
