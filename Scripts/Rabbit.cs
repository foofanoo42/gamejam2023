using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : MonoBehaviour
{

    [SerializeField] private CharacterController characterController;

    //private Vector3 playerVelocity = Vector3.Forward;
    private bool groundedPlayer;
    private float playerSpeed = 15.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    // Update is called once per frame
    void Update()
    {
        //groundedPlayer = controller.isGrounded;
        //if (groundedPlayer && playerVelocity.y < 0)
        //{
        //    playerVelocity.y = 0f;
        //}

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        Debug.Log(move);

        characterController.Move(move * Time.deltaTime * playerSpeed);
    }

}
