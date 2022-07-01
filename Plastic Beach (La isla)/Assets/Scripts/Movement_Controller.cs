using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Controller : MonoBehaviour
{
    [Header("Movimiento del personaje")]
    public float speedMovement;
    public Vector3 direccion;
    public CharacterController controller;

    
    [Header("Gravedad")]
    public Vector3 movimientoY;
    public float gravity = -9.8f;
    public float jumpHeight;

    [Header("Rotacion")]
    public float rotacionPlayerY;


    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
       movimientoY.y += gravity * 1.2f * Time.deltaTime;

        controller.Move(movimientoY * Time.deltaTime);

        if (controller.isGrounded && movimientoY.y < 0)
        {
            movimientoY.y = -2f;
        }

        if (controller.isGrounded && Input.GetButton("Jump"))
        {
            movimientoY.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }


    }

    public void Move(float vertical, float horizontal)
    {
        direccion.x = horizontal;
        direccion.z = vertical;

        direccion = transform.TransformDirection(direccion);

        controller.Move(direccion * Time.deltaTime * speedMovement);
    }

    public void Rotate(float rotateValue)
    {
        rotacionPlayerY += rotateValue;

        controller.transform.rotation = Quaternion.Euler(0, rotacionPlayerY, 0);
    }
   


}
