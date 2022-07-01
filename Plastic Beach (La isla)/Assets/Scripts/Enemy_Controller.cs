using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Movement_Controller))]
public class Enemy_Controller : MonoBehaviour
{
    public Movement_Controller movement;
    public Transform jugador;
    public float rangeofDetection = 15f;
    public Vector3 player;
    public Vector3 forward;

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, jugador.position);
        

        if (distance <= rangeofDetection)
        {
            player = (transform.position - jugador.position).normalized;
            forward = (transform.TransformDirection(Vector3.forward));

            if(Vector3.Dot(forward,player) < 0)
            {
                movement.Rotate(-1);
            }

            if(Vector3.Dot(forward,player) > 0)
            {
                movement.Rotate(1);
            }

            //movement.Move(1, 0);
        }
    }

}
