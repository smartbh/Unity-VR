using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMech : MonoBehaviour
{
    BoxCollider bc;
    private GameObject rootFire;

    // Start is called before the first frame update
    void Start()
    {
        bc = this.GetComponent<BoxCollider>();
        bc.isTrigger = true; // is trigger üũ
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Chiiiik() // �� ������ �Լ�
    {
        rootFire = this.transform.parent.gameObject;
        rootFire.gameObject.SetActive(false);
        // setactive(false)
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Exting")) // ��ȭ�� �±� �����ſ� ������ �����
        {
            // ��ȭ�⸦ ������ ������ ����
            //other.GetComponent<AudioSource>().Play();
            //other.gameObject.SetActive(false);
            Chiiiik();
          
        }
    }
}
