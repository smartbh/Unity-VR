using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class cshTimerTrigger : MonoBehaviour
{
    private float fDestroyTime = 5f; private float fTickTime;

    public Text textbox3;
    public Text textbox2;
    public float realEvent = 1;
    private GameObject beltL, beltR;
    public float deleteTime = 2.0f;

    private void OnCollisionEnter(Collision collision)
    {

        /*   if (collision.gameObject.tag == "belt")
           {
            cshTimerTrigger realEvent = GameObject.Find("genMask").GetComponent<cshTimerTrigger>();
            realEvent.realEvent = 2;//Destroy(collision.gameObject);

        }
        if (collision.gameObject.tag == "Enemy")
        {
            cshTimerTrigger realEvent = GameObject.Find("genMask").GetComponent<cshTimerTrigger>();
            realEvent.realEvent = 2;//Destroy(collision.gameObject);

        }*/
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("belt"))
        {
            cshTimerTrigger realEvent = GameObject.Find("genMask").GetComponent<cshTimerTrigger>();
            realEvent.realEvent = 2;// Destroy(other.gameObject);
            Destroy(gameObject);
            // Destroy(gameObject, deleteTime);

        }
        if (other.CompareTag("Enemy"))
        {
            cshTimerTrigger realEvent = GameObject.Find("genAccess").GetComponent<cshTimerTrigger>();
            realEvent.realEvent = 3;// Destroy(other.gameObject);
            Destroy(gameObject);// Destroy(gameObject, deleteTime);

        }
        if (other.CompareTag("acces"))
        {
            cshTimerTrigger realEvent = GameObject.Find("genAccess").GetComponent<cshTimerTrigger>();
            realEvent.realEvent = 4; Destroy(other.gameObject);
            //Destroy(gameObject, deleteTime);



        }
        if (other.CompareTag("fivesecond"))
        {
            // cshTimerTrigger realEvent = GameObject.Find("genAccess").GetComponent<cshTimerTrigger>();
            //realEvent.realEvent = 4;//Destroy(other.gameObject);
            Invoke("Escape3", 5.0f);


        }
        if (other.CompareTag("ct"))
        {


            cshTimerTrigger realEvent = GameObject.Find("genAccess").GetComponent<cshTimerTrigger>();
            realEvent.realEvent = 9;
           // Destroy(other.gameObject);
        }

            if (other.CompareTag("escape"))
            {
             
              
                //Destroy(other.gameObject);
            }



            /*
               if (other.gameObject.tag == "belt")
               {
                cshTimerTrigger realEvent = GameObject.Find("genMask").GetComponent<cshTimerTrigger>();
                realEvent.realEvent = 2;
                 Destroy(other.gameObject);
               } */
       
    }

    /* private void OnTriggerExit(Collider collision)
     {
         if (collision.CompareTag("BreakableObject") || collision.CompareTag("Enemy"))
         {
             colliders.Remove(collision);
         }
     } */
    // Start is called before the first frame update

    public GameObject obj, obj2, obj3; //ChickBallPrefab 설정
    public float interval = 60.0f; //다음에 함수가 호출될 인터벌


    void Start()
    {
        //   Destroy(gameObject, fDestroyTime);

        cshMoveLimit realEvent = GameObject.Find("OVRPlayerController").GetComponent<cshMoveLimit>();
        realEvent.realEvent = 1;

        //SpawnObj함수를 게임이 실행된 0.1초 후에 호출, 이후 interval초 마다 호출 된다.

    }




    private void Update()
    {
      

        //Player 이동 (이동 범위를 movableRange로 제한)
        transform.Translate(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0, 0);
        transform.position
        = new Vector2(Mathf.Clamp(transform.position.x, -moveableRange, moveableRange), transform.position.y);

        if (Input.GetKeyDown(KeyCode.Space))  //스페이스키 버튼 이벤트 처리
        {
            Shoot(); //Shoot함수 호출
        }


        //  Mathf.Round(timestart).ToString()


 
        if (realEvent == 2) { textbox2.text = "사고 발생, 마스크 착용"; InvokeRepeating("SpawnObj", 0.1f, interval);
            realEvent = 2.5f;
          
        }

        if (realEvent == 3) { textbox2.text = "장신구를 벗어야 합니다."; InvokeRepeating("SpawnObj2", 0.1f, interval); realEvent = 3.5f; }
        if (realEvent == 4) {   textbox2.text = "충격을 대비해 천천히 몸을 웅크리세요"; InvokeRepeating("SpawnObj3", 5f, interval); realEvent = 4.5f; }
        if (realEvent == 6) { textbox2.text = " "; }
        if (realEvent == 7) { textbox2.text = " "; }
        if (realEvent == 8) { 
            textbox2.text = "화살표를 따라 신속히 이동하기";  
            fTickTime += Time.deltaTime;
            if (fTickTime >= fDestroyTime) {
               // Invoke("Escape", 5.0f);
            }  
            
        }
        if (realEvent == 9) {
            textbox2.text = "뛰어내리기";
            fTickTime += Time.deltaTime;
            if (fTickTime >= fDestroyTime)
            {
                cshTimerTrigger realEvent = GameObject.Find("genAccess").GetComponent<cshTimerTrigger>();
            realEvent.realEvent = 10;
            }

        }
        if (realEvent == 10) {

           
            fTickTime += Time.deltaTime;
            if (fTickTime >= fDestroyTime*2)
            {
                textbox2.text = "구명보트 탑승";
                cshMoveLimit realEvent = GameObject.Find("OVRPlayerController").GetComponent<cshMoveLimit>();
                realEvent.realEvent = 101;

            }
            //  Invoke("Escape2", 5.0f); 
           
            //  Invoke("Escape4", 5.0f); 
        }
            if (realEvent == 11) {
                fTickTime += Time.deltaTime;
                if (fTickTime >= fDestroyTime)
                {
                    cshMoveLimit realEvent = GameObject.Find("OVRPlayerController").GetComponent<cshMoveLimit>();
                    realEvent.realEvent = 104;
                   // textbox2.text = "구명보트 탑승";
                }
            }
            if (realEvent == 200)
            {
              textbox2.text = "축하합니다. 탈출하셨습니다."; 

        }

        }

   
    public GameObject cannonBall; //Player에서 발사할 weapon
    public Transform spawnPoint; //weapon 발사 지점

    public float speed = 0.1f;//Player의 이동 속도
    public float moveableRange = 8f; // 이동 가능한 범위
    public float power = 200f; // waapon 발사하는 힘




    void Shoot()
    {
        //새 weapon을 생성하여 newBullet에 할당
        GameObject newBullet = Instantiate(cannonBall, spawnPoint.position, Quaternion.identity) as GameObject;
        //newBullet의 Rigidbody2D를 참조하여 AddForce 함수로 물리적으로 발사
        newBullet.GetComponent<Rigidbody2D>().AddForce(Vector2.right * power);
    }

    private List<Collider> colliderList = new List<Collider>();

    // Start is called before the first frame update

    // Update is called once per frame

    public List<Collider> colliders
    {
        get
        {
            if (0 < colliderList.Count)
            {
                //  현재 colliders 리스트에 객체중 null인 것은 제거하여 colliderList에 저장 후 반환
                colliderList.RemoveAll(c => c == null);
            }
            return colliderList;
        }

    }
    //SpawnObj함수는 ChickBallPrefab을 생성한다.
    void SpawnObj()
    {
        float rnd = Random.Range(0.0f, 1.0f); //(0.0에서 5.0사이의 랜덤값을 생성)
        float rnd2 = Random.Range(0.0f, 1.0f);

        Vector3 pos = new Vector3(transform.position.x + rnd, transform.position.y, transform.position.z + rnd2);


         
         
                for (float y = 0; y < 3 ; y++)
                {
                    Instantiate(obj, new Vector3(transform.position.x + y, transform.position.y, transform.position.z  ), transform.rotation);
                   
           }

        Instantiate(obj2, new Vector3(-2.623f, 6.616f, 0.01f), transform.rotation);

    }
    void SpawnObj2()
    {
        float rnd = Random.Range(0.0f, 1.0f); //(0.0에서 5.0사이의 랜덤값을 생성)
        float rnd2 = Random.Range(0.0f, 1.0f);

        Vector3 pos = new Vector3(transform.position.x + rnd, transform.position.y, transform.position.z + rnd2);

         
                Instantiate(obj, new Vector3(-2.482f, 6.455f, 0.071f), transform.rotation);
                Instantiate(obj2, new Vector3(-2.081f, 6.294f, 0.0f), transform.rotation);
            
 


    }
    void SpawnObj3()
    {
        float rnd = Random.Range(0.0f, 1.0f); //(0.0에서 5.0사이의 랜덤값을 생성)
        float rnd2 = Random.Range(0.0f, 1.0f);

        Vector3 pos = new Vector3(transform.position.x + rnd, transform.position.y, transform.position.z + rnd2);


        Instantiate(obj3, new Vector3(-20.482f, 60.455f, 20.071f), transform.rotation);

        realEvent = 8;
    }

    void Escape()
    {
        cshTimerTrigger realEvent = GameObject.Find("genMask").GetComponent<cshTimerTrigger>();
        fTickTime = 0;
        realEvent.realEvent = 9;
    }
    void Escape2()
    { 
         fTickTime =0; 
        cshTimerTrigger realEvent = GameObject.Find("OVRPlayerController").GetComponent<cshTimerTrigger>();
        realEvent.realEvent = 10;
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Translate(Vector3.down * speed * Time.deltaTime);

    }
    void Escape3()
    {
        cshTimerTrigger realEvent = GameObject.Find("genMask").GetComponent<cshTimerTrigger>();
        fTickTime = 0; realEvent.realEvent =8;
    }
    void Escape4()
    {
        cshTimerTrigger realEvent = GameObject.Find("genAccess").GetComponent<cshTimerTrigger>();
        realEvent.realEvent = 11;
    }




}
