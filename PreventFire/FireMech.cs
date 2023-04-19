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
        bc.isTrigger = true; // is trigger 체크
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Chiiiik() // 불 꺼지는 함수
    {
        rootFire = this.transform.parent.gameObject;
        rootFire.gameObject.SetActive(false);
        // setactive(false)
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Exting")) // 소화기 태그 가진거에 맞으면 사라짐
        {
            // 소화기를 던져서 맞으면 실행
            //other.GetComponent<AudioSource>().Play();
            //other.gameObject.SetActive(false);
            Chiiiik();
          
        }
    }
}
