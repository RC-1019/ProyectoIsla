using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    public Animator anim;

    public void OnOpenDoor()
    {
        anim.SetTrigger("OpenDoor");
    }
}
