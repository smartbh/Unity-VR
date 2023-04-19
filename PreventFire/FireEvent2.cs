using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEvent2 : MonoBehaviour
{
    public FireControll FC;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FC.ignite(2);
        }
    }
}
