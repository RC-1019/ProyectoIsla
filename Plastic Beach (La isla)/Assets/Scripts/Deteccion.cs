using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deteccion : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Se entró al trigger");
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Se permanece en el trigger");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Se salió del trigger");
    }
}
