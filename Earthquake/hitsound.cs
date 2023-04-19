using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitsound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<AudioSource>().Play(); // (hit) 사운드 실행

    }
}
