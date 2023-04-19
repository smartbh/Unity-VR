using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEvent1 : MonoBehaviour
{
    public FireControll FC;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) // 소화기 태그 가진거에 맞으면 사라짐
        {
            FC.ignite(1);
        }
    }
}
