using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class cshescape : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ct"))
        {
            cshTimerTrigger realEvent = GameObject.Find("genAccess").GetComponent<cshTimerTrigger>();
            realEvent.realEvent = 9; Destroy(other.gameObject);


        }

        if (other.CompareTag("escape"))
        {
            cshTimerTrigger realEvent = GameObject.Find("genAccess").GetComponent<cshTimerTrigger>();
            realEvent.realEvent = 10; Destroy(other.gameObject);


        }
    }

}
