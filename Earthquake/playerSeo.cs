using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class playerSeo : MonoBehaviour
{
    // 1. Character Controller 는 캐릭터의 몸, 행동 범위, 충돌 판정
    // 2. Transfrom.Scale 은 카메라의 위치 
    public shaketest manager; // shaketest 함수 

    bool timer = false; // time 변수에 값을 넣고 실행되는 여부를 결정하는 bool 값

    float scax; // 스케일 변수, 일어서거나 앉을 때 크기 조정
    float scay; // 스케일 변수, 일어서거나 앉을 때 크기 조정
    float scaz; // 스케일 변수, 일어서거나 앉을 때 크기 조정

    float time; // 시간 변수, 나중에 값을 넣고 실행 됨
    int hp = 100; // 체력, 초기값은 100으로 설정, 0 밑으로 떨어지면 종료 하도록 구현 예정 

    private bool isPause = true;
    public bool hitcheck = false; // 타격 판정
    bool deadCheck = false; // 죽었는지 확인해서 죽었으면 재시작 가능하도록 하는 변수
    public bool endCheck = false; // 끝낼 수 있는 변수
    public bool crouchCan = true; // 앉는 게 가능하면 true, 불가능하면 false. 기본값은 true
    public bool croushStatus = false; // 서있으면 false, 앉아있으면 true. 기본 값은 false

    int itd = 0;

    public OVRScreenFade scrFade;

    CharacterController cont = null; // 캐릭터 컨트롤러, 이걸로 플레이어의 높이 지정하려고 함
    // 원래 Character Controller의 radius랑 height 값 저장하는 변수 2개


    public Camera cam;
    public Text myscr;

    void FStart()
    {
        myscr.text = "게임이 시작되었습니다.";
        StartCoroutine(Ye());
    }

    void Crouch()
    {
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) && croushStatus == false && crouchCan == true)
        {
            cont.height = 0.3f; // Character Controller 높이 낮추기
            cont.detectCollisions = false; // 다른 물체들이랑 충돌에서 안 튕기게 설정
            this.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            // ※ 사람 크기보다 넓은 책상 만들어야 앉아서 지나갈 수 있음

            //head.center = new Vector3(0.0f, 0.25f, 0.0f);
            //head.radius = 0.25f;

            //Stone.transform.position = new Vector3(0.0f, 0.25f, 0.0f);

            croushStatus = true; // 앉아있는 상태
        }
        else if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) && croushStatus == true && crouchCan == true)
        {
            cont.height = 2f; // Character Controller 높이 키우기
            cont.detectCollisions = false;
            this.transform.localScale = new Vector3(scax, scay, scaz);

            //head.center = new Vector3(0.0f, 0.7f, 0.0f);
            //head.radius = 0.5f;

            //Stone.transform.position = new Vector3(0.0f, 0.7f, 0.0f);

            croushStatus = false; // 서있는 상태
        }
        if (OVRInput.GetDown(OVRInput.Button.Two) && deadCheck == true)
        {
            // 현재 씬 재시작
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //SceneManager.LoadScene(0);

        }
    }

    void PDead() // HP 변수가 0 이하로 떨어져서 죽으면 실행하는 함수
    {
        Debug.Log("YOU DIED!!!!!!!!!!!!!!");
        // 할 것 구현

        StartCoroutine((Fade(Color.white, Color.black, 1f)));
        myscr.color = Color.red;
        myscr.text = "사망하셨습니다!\n 재시작 하시려면 B버튼을 누르세요!";
        deadCheck = true;
        hitcheck = true;
        StartCoroutine(Hold());

    }

    public void PHit(int Damage)
    {
        scrFade.fadeColor = Color.red;
        scrFade.FadeIn();
        // 맞으면 0.3초동안 스크린이 Red Color로 Fade되도록 설정

        GetComponent<AudioSource>().Play(); // (hit) 사운드 실행


        hp -= Damage;
        if (hp <= 0)
        {
            PDead(); // 죽으면 함수 실행
        }
        Debug.Log("YOU HIT!!!!");
        // ※ 맞을 때마다 체력 표시, 혈흔 시각 효과


    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        hp = 100;
        hitcheck = false;
        deadCheck = false;
        endCheck = false;
        // 값들 초기화하고 시작 (재시작도 염두해 둬야 하기 때문)

        cont = this.GetComponent<CharacterController>(); // Character Controller를 제어할 수 있게 cont 변수에다 초기화

        scax = this.transform.localScale.x;
        scay = this.transform.localScale.y;
        scaz = this.transform.localScale.z; // 스케일 x,y,z 값들 변수에 저장

        FStart(); // 시작하면 텍스트 출력하는 거 설정

    }

    // Update is called once per frame
    void Update()
    {
        Crouch();
        if (timer == true)
        {
            time -= Time.deltaTime; // 매 프레임마다 time 변수 까기
            Debug.Log("time is " + time);
        }

        if (time < 0.0f) // time이 0 밑으로 내려가면
        {
            time = 0.0f; // 일단 time 변수는 0 으로 만들고
            timer = false; // timer 작동하지 않도록 설정
            manager.pointer = false; // shaketest에서 지진 발생 멈추기
            Debug.Log("TIMER END!!!!!!!!!!!!");
        }
        if (OVRInput.Get(OVRInput.Button.One) && endCheck == true)
        {
            SceneManager.LoadScene("MainMenu");
            this.gameObject.SetActive(false);
        }

    }


    IEnumerator Hold()
    {
        yield return new WaitForSeconds(3);
        Time.timeScale = 0;
    }
    IEnumerator Ye()
    {
        for (int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(5);
            if (i == 0) { myscr.text = "지진이 곧 있으면 발생할겁니다"; }
            else if (i == 1) { myscr.text = "간단한 시뮬레이션으로,\n 몇 가지 안전수칙만 지키면 \n대피할 수 있습니다"; }
            else if (i == 2) { myscr.text = "오른쪽 트리거를 당기면 앉아서\n책상 밑으로 대피할 수 있습니다."; }
            else if (i == 3) { myscr.text = "무거운 물체에는 깔리지\n않도록 조심하십시오"; }
        }
        myscr.text = "";
        manager.sit1 = false; // 이제 Event1 이 실행 될수 있도록 잠금 해제
    }
    IEnumerator Fade(Color from, Color to, float tim)
    {
        float speed = 1 / tim;
        float percent = 0;

        // Debug.Log("게임 오버 Speed is " + speed);
        while (percent < 1)
        {
            //Debug.Log("게임 오버 실행 중....." + percent);
            //percent += Time.deltaTime * speed;
            percent += Time.deltaTime;
            scrFade.fadeColor = Color.Lerp(from, to, percent);
            scrFade.FadeIn();
            //Debug.Log(scrFade.fadeColor);
            yield return null;
        }
        //scrFade.FadeOut();

        Debug.Log("게임 End");
    }
}
