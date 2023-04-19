using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour
{
    public shaketest manager; // shaketest 함수 
    public playerSeo play; // playr 함수

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
        GetComponent<AudioSource>().Play();
    }

    private void OnTriggerEnter(Collider other)
    {

        //// && this.gameObject.transform.position.y > 0.0f
        //if (other.gameObject.CompareTag("Player"))
        //{
        //    Debug.Log("PHit Activated!!!");
        //    play.PHit(10);
        //}
    }
}
