using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour
{
    public shaketest manager; // shaketest �Լ� 
    public playerSeo play; // playr �Լ�

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
