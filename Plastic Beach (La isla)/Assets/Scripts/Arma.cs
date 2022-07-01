using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    public GameObject prefab_bala;
    public Transform spawn_point;
    public float force;
    public int cartuchoMax = 30;
    public int cartuchoActual;

    //instancear un objeto

    //aplicarle fuerza al rigidbody

    private void Start()
    {
        cartuchoActual = cartuchoMax;
    }


    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && cartuchoActual > 0)
        {
            GameObject go = Instantiate(prefab_bala, spawn_point.position, spawn_point.rotation);
            go.GetComponent<Rigidbody>().AddForce(spawn_point.forward * force, ForceMode.Impulse);
            Destroy(go, 2f);
            cartuchoActual--;
        }

        if (Input.GetButtonDown("Recarga"))
        {
            Reload();
        }
    }

    void Reload()
    {
        cartuchoActual = cartuchoMax;
    }



}
