using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshMoveLimit : MonoBehaviour
{
    public float speed = 3f;//Player의 이동 속도
    public float moveableRange = 8f; // 이동 가능한 범위
    public float power = 200f; // waapon 발사하는 힘
    public float realEvent = 1;

    public GameObject cannonBall; //Player에서 발사할 weapon
    public Transform spawnPoint; //weapon 발사 지점
                                 // Start is called before the first frame update

    public Vector3 targetPosition;
    private float fDestroyTime = 5f; private float fTickTime;


   
     
void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (realEvent == 101)
        {
            //  transform.position = new Vector3(-3.99f, 6.55f, -3.31f); 
            // transform.position = new Vector3(transform.position.x-1f, transform.position.y, transform.position.z);
             
            realEvent = 102;

        }
        if (realEvent == 102)
        {

            Invoke("Escape4", 0.1f);
            fTickTime += Time.deltaTime;
            if (fTickTime >= fDestroyTime)
            {
                realEvent = 103;
            }
        }

        if (realEvent == 1)
        {
            // transform.position = new Vector3(Mathf.Clamp(transform.position.x, -10f, 10f), 0, 0);
            if (transform.position.x > -0.46) transform.position = new Vector3(-0.46f, transform.position.y, transform.position.z);
            if (transform.position.x < -3.24)
                transform.position = new Vector3(-3.24f, transform.position.y, transform.position.z);

            if (transform.position.z > 1.5)
                transform.position = new Vector3(transform.position.x, transform.position.y, 1.5f);
            if (transform.position.z < -4.41)
                transform.position = new Vector3(transform.position.x, transform.position.y, -4.41f);

            /*if (transform.position.z > 10)
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            if (transform.position.z < -2)
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);*/



        }
        if (realEvent == 104)
        {
            //  transform.position = new Vector3(-3.99f, 6.55f, -3.31f); 
            // transform.position = new Vector3(transform.position.x-1f, transform.position.y, transform.position.z);

            //  transform.position = new Vector3(-3.99f, 6.55f, -3.31f);
            Invoke("Escape5", 5f);
            fTickTime += Time.deltaTime;
            if (fTickTime >= fDestroyTime)
            {
                realEvent = 103;
            }

        }
    }

    void Escape3()
    {

      //  transform.position = new Vector3(-3.99f, 6.55f, -3.31f);
        

    }
    void Escape4()
    {
        /* cshTimerTrigger realEvent = GameObject.Find("genAccess").GetComponent<cshTimerTrigger>();
         realEvent.realEvent = 11;*/
      
        //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        transform.Translate(Vector3.forward * speed * Time.deltaTime * 10);
        transform.Translate(Vector3.down * speed * Time.deltaTime * 10);
        fTickTime += Time.deltaTime;
        if (fTickTime >= fDestroyTime)
        {
           
            cshTimerTrigger realEvent = GameObject.Find("genAccess").GetComponent<cshTimerTrigger>();
            realEvent.realEvent = 11;
            
        }




    }
    void Escape5()
    {
        transform.position = new Vector3(-21.76f, 6.06f, -10.59f);
        transform.Rotate(0f, 1f, 0.0f, Space.World);
        cshTimerTrigger realEvent = GameObject.Find("genAccess").GetComponent<cshTimerTrigger>();
        realEvent.realEvent = 200;
    }





}
