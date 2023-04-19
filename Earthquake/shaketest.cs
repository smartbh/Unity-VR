using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class shaketest : MonoBehaviour
{
    public Event1 ev1; // Event1 스크립트를 가져온 이유는, 여기에서 text를 삭제하라고 명령을 내릴거이기 때문
    public Event2 ev2; // Event1 스크립트를 가져온 이유는, 여기에서 text를 삭제하라고 명령을 내릴거이기 때문
    public Event3 ev3; // Event1 스크립트를 가져온 이유는, 여기에서 text를 삭제하라고 명령을 내릴거이기 때문
    public Event4 ev4; // Event1 스크립트를 가져온 이유는, 여기에서 text를 삭제하라고 명령을 내릴거이기 때문
    public Event5 ev5; // Event1 스크립트를 가져온 이유는, 여기에서 text를 삭제하라고 명령을 내릴거이기 때문

    float sin = 0.1f; // 좌우로
    float csin = 0.3f; // 위아래로
    float zsin = 0.1f; // 상하로

    // float xsin = 0.05f; // 각도 조정

    float rnd1; // sin
    float rnd2; // csin
    float rnd3; // zsin
    //float rnd4; // xsin

    float freq = 15;

    Vector3 fro; // from, 여기서부터 시작
    Vector3 to; // to, 여기를 끝 지점으로

    float fromx;
    float fromy;
    float fromz; // x,y,z 좌표들의 초기 위치 값들

    public bool pointer = true; // 지진 실행 여부, 기본 값은 false로 해야 함!, true로 바꾸면 지진이 실행됨
    public bool sit1 = true; // 이것만 맨 처음에 true로 한 것은 맨 처음 20초 save를 위해!
    public bool sit2 = false;
    public bool sit3 = false;
    public bool sit4 = false;
    public bool sit5 = false;
    // 각 이벤트 실행 변수들

    public bool check1 = false;
    public bool check2 = false;
    public bool check3 = false;
    public bool check4 = false;
    public bool check5 = false;

    public float limitTimer = 0.0f;

    private IEnumerator coroutine;

    public void PlaySound()
    {
        GetComponent<AudioSource>().Play(); // (quake) 사운드 실행, 외부 (player 스크립트)에서 실행함
    }

    // Start is called before the first frame update
    void Start()
    {
        fro = this.transform.position; // 초기 위치값들 저장
        fromx = fro.x;
        fromy = fro.y;
        fromz = fro.z;
    }

    // Update is called once per frame
    void Update()
    {
        //time += Time.deltaTime;
        if (pointer == true) // pointer가 true 일때만 동작함
        {
            Debug.Log("shaketest 실행");
            coroutine = Shaking(limitTimer);
            StartCoroutine(coroutine);
            pointer = false;



        }
    }

    // 코루틴으로 10초동안 0.003초 간격으로 실행하도록 설정한 것.
    IEnumerator Shaking(float maxtime)
    {
        float time = 0f;

        while (time < maxtime)
        {
            rnd1 = Random.Range(fromx - sin, fromx + sin); // 좌우 흔들림 범위 
            rnd2 = Random.Range(fromy - csin, fromy + csin); // 위아래 흔들림 범위
            rnd3 = Random.Range(fromz - zsin, fromz + zsin); // 상하 흔들림 범위

            to = new Vector3(rnd1, rnd2, rnd3); // target은 맵이 움직일 (흔들릴 장소를 저장)

            this.transform.position = Vector3.Lerp(this.transform.position, to, 0.002f); // 위치 지정후 해당 장소로 이동

            yield return new WaitForSeconds(0.002f);

            time += 0.002f;

            if (time < maxtime / 1.33)
            {
                if (sin < 4.0f) { sin += 0.01f; }
                if (csin < 2.5f) { csin += 0.01f; }
                if (zsin < 3.0f) { zsin += 0.01f; }
                // 점진적으로 높이기
            }


            if (time >= maxtime / 1.33)
            {
                if (sin > 0.1f) { sin -= 0.01f; }
                if (csin > 0.3f) { csin -= 0.01f; }
                if (zsin > 0.1f) { zsin -= 0.01f; }
                // 점진적으로 내리기
            }



        }
        Debug.Log("shaketest 종료");

        to = new Vector3(fromx, fromy, fromz);
        this.transform.position = Vector3.Lerp(this.transform.position, to, 1);

        sin = 0.1f;
        csin = 0.3f;
        zsin = 0.1f;
        yield return new WaitForSeconds(2);
        if (sit1 == true && check1 == false) { ev1.chnC(); } // Event1 스크립트로 가서 text 없애라고 하기, 잠겨있는 문 열기
        if (sit2 == true && check2 == false) { ev2.chnC(); }
        if (sit3 == true && check3 == false) { ev3.chnC(); }
        if (sit4 == true && check4 == false) { ev4.chnC(); }
        if (sit5 == true) { ev5.chnC(); }

    }
}
