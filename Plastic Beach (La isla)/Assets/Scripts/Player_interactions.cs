using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_interactions : MonoBehaviour
{
    public Transform cameraplayer;
    public Transform objetoVacioCaja;
    public LayerMask lm;
    public Transform objetoVacioArma;
    public float rayDistance;

    private void Update()
    {
        if (Input.GetButtonDown("Agarrar"))
        {
            if (objetoVacioCaja.childCount > 0)
            {
                objetoVacioCaja.GetComponentInChildren<Rigidbody>().isKinematic = false;
                objetoVacioCaja.DetachChildren();
                if (objetoVacioArma.childCount > 0)
                {
                    objetoVacioArma.GetChild(0).gameObject.SetActive(true);
                }
            }
            else
            {
                Debug.DrawRay(cameraplayer.position, cameraplayer.forward, Color.red);
                

                if (Physics.Raycast(cameraplayer.position, cameraplayer.forward, out RaycastHit hit, rayDistance, lm))
                {         
                        hit.transform.GetComponent<Rigidbody>().isKinematic = true;
                        hit.transform.parent = objetoVacioCaja;
                        hit.transform.localPosition = Vector3.zero;
                    hit.transform.localRotation = Quaternion.identity;
                    Debug.Log(hit.transform.name);
                    if(objetoVacioArma.childCount > 0)
                    {
                        objetoVacioArma.GetChild(0).gameObject.SetActive(false);
                    }

                }

            }
        }      
        
    }

    public Player_stadistics player_Stadistics;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Puerta" && player_Stadistics.battery_count >= 4)
        {
            other.GetComponentInParent<Puerta>().OnOpenDoor();
        }
        
        if (other.tag == "Linterna")
        {
            other.GetComponentInParent<Chao_linterna>().OnGetBattery();
            player_Stadistics.battery_count++;
        }

        if (other.tag == "Arma")
        {
            other.transform.parent = objetoVacioArma;
            other.transform.localRotation = Quaternion.identity;
            other.transform.localPosition = Vector3.zero;
            if (objetoVacioCaja.childCount > 0)
            {
                other.gameObject.SetActive(false);
            }
            
        }
    }
        
}
