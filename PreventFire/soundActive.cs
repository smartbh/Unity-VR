using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundActive : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
         if (other.gameObject.tag == "Fire")
         {
            GetComponent<AudioSource>().Play(); // (hit) 사운드 실행
            this.gameObject.SetActive(false);
         }
    }

}
