using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorsound : MonoBehaviour
{
    bool check = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SoundBox") && check == false)
        {
            check = true;
            GetComponent<AudioSource>().Play(); // (hit) 사운드 실행
        }       
    }
}
