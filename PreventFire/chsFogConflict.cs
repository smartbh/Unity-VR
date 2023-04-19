using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chsFogConflict : MonoBehaviour
{
    private double hp;
    // Start is called before the first frame update
    void Start()
    {
        playerFire playerFire = this.GetComponent<playerFire>();
        hp = playerFire.hp;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("남은 hp는 : " + hp);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Fog")
        {
                hp -= 0.01;
                Debug.Log("연기속 hp는 = " + hp);
        }
    }
}
