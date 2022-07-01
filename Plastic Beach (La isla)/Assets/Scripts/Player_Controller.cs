using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Movement_Controller))]
public class Player_Controller : MonoBehaviour
{
    [Header("Movimiento de la cámara")]
    public Vector2 mouseMovement;
    public Camera playerCamera;
    public float rotacionCamaraX;
    public float rotacionPlayerY;
    public float sensibilidadDelRaton;

    [Header("Movement Controller")]
    public Movement_Controller movement;
    public Movement_Controller rotacion;

    private void Update()
    {
        mouseMovement = new Vector2(Input.GetAxis("Mouse X") * sensibilidadDelRaton, Input.GetAxis("Mouse Y") * sensibilidadDelRaton);

        rotacionCamaraX -= mouseMovement.y;
        rotacionPlayerY += mouseMovement.x;

        rotacionCamaraX = Mathf.Clamp(rotacionCamaraX, -40, 40);

        playerCamera.transform.localRotation = Quaternion.Euler(rotacionCamaraX, 0, 0);

        movement.Move(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
        rotacion.Rotate(Input.GetAxis("Mouse X"));
        
    }
}
