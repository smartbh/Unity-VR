using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEvent1 : MonoBehaviour
{
    public FireControll FC;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) // ��ȭ�� �±� �����ſ� ������ �����
        {
            FC.ignite(1);
        }
    }
}
