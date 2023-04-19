using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Event4 : MonoBehaviour
{
    Rigidbody rb; // Rigidbody 값 (오브젝트들 배열 값)
    public GameObject door; // Rigidbody 값 (문을 열기 위해 Kinematic을 해제할 예정 값)
    private GameObject rootDoort;
    public shaketest manager; // 다른 shaketest 스크립트
    public flickering[] farray; // (Toilet 안의) Light들 담는 배열

    public GameObject[] array; // 게임 오브젝트 (DMG3 && Toilet_Object)들 담는 배열
    public GameObject[] array2; // 게임 오브젝트 (DMG3 && Toilet_Object)들 담는 배열
    //public GameObject door; // 문을 열기 위해 Kinematic을 해제할 예정

    public Text t; // Text 값 가져오기

    public bool check = false; // false면 텍스트 다 지우고, true면 없앨 걸


    // Start is called before the first frame update
    void Start()
    {

    }

    public void chnC() // 종료 시 실행할 함수
    {
        Debug.Log("chnC 실행");
        t.text = ""; // 텍스트 비우고

        for (int i = 0; i < farray.Length; i++) // 불 깜빡이는거 중단
        {
            farray[i].stopped(); // 각 불빛들 전부 끄라고 명령
        }
        rootDoort = door.transform.parent.gameObject; //최상위 부모
        rootDoort.gameObject.SetActive(false);//부모 포함 전부 게임에서 없애줌
    }


    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        array = GameObject.FindGameObjectsWithTag("DMG4");
        array2 = GameObject.FindGameObjectsWithTag("DMG4-1");
        Debug.Log("DMG4의 오브젝트 개수는 " + array.Length + "이다.");

        if (manager.sit4 == false) // 상황4가 한번도 실행 안 된 상태만 아래의 스크립트 실행됨
        {
            manager.sit4 = true; // 상황4가 더 이상 실행되지 않도록 true로 잠궈버리기
            manager.check3 = true;

            t.text = "이곳엔 책상이 없습니다!\n떨어질 물건이 없는 곳으로 피하십시오!";

            GetComponent<AudioSource>().Play(); // 지진 사운드 실행
            manager.limitTimer = 2.8f; // 지진의 실행 시간이 5초가 되도록 shaketest 쪽의 limitTimer 값 5초로 설정하기
            manager.pointer = true; // 지진 실행하도록 shaketest 쪽의 pointer 값 바꾸기

            for (int i = 0; i < array.Length; i++) // 가져온 오브젝트들 (배열) 에다가 Rigidbody 주기
            {
                rb = array[i].AddComponent<Rigidbody>(); // 하나하나씩 Rigibody 부여
                rb.mass = 5f; // 무게 값은 5로 설정
            }
            for (int i = 0; i < array2.Length; i++) // 가져온 오브젝트들 (배열) 에다가 Rigidbody 주기
            {
                rb = array2[i].AddComponent<Rigidbody>(); // 하나하나씩 Rigibody 부여
                rb.mass = 100f; // 무게 값은 5로 설정
            }

            for (int i = 0; i < farray.Length; i++)
            {
                farray[i].flick = false;
            }
        }

    }
}
