using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshGameRestart : MonoBehaviour
{
    [SerializeField] bool deadCheck;
    // Start is called before the first frame update
    void Start()
    {
        //this.gameObject.SetActive(false); //Äµ¹ö½º ½ÃÀÛ½Ã ¼û±è
        // Renderer.enable
        playerFire playerFire = GameObject.Find("OVRPlayerController").GetComponent<playerFire>();
        deadCheck = playerFire.deadCheck;
        Debug.Log("DeadCheck = " + deadCheck);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("DeadCheck = " + deadCheck);

        if (deadCheck) //true
        {
            this.gameObject.SetActive(true);
        }
    }
}
