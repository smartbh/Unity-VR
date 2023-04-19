using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerFire : MonoBehaviour
{
    public double hp; // 체력
    public bool hitCheck = false;
    public OVRScreenFade ScrFade;
    public bool deadCheck = false; // 죽었는지 확인해서 죽었으면 재시작 가능하도록 하는 변수
    public Text text;

    void dead()
    {
        // backsound.deathSound();
        // PDead() 가져오기
        deadCheck = true;
        hitCheck = true;
        StartCoroutine(Hold());
    }

    void Start()
    {
        deadCheck = false;
        hitCheck = false;
        Time.timeScale = 1;
    }

    void Update()
    {
        if (hp <= 0)
        {
            dead();
        }
        if (OVRInput.GetDown(OVRInput.Button.Two) && deadCheck == true)
        {
            // 현재 씬 재시작
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //SceneManager.LoadScene(0);

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Fire") && hitCheck == false)
        {
            GetComponent<AudioSource>().Play();
            ScrFade.fadeColor = Color.red;
            ScrFade.FadeIn();

            hp -=1;
            Debug.Log("hp는 = "+ hp);
        } 
        //if (other.gameObject.tag == "Fog")
        //{
        //    /*GetComponent<AudioSource>().Play();*/
        //}
        // 불 닿으면 데미지
    }
    IEnumerator Hold()
    {
        yield return new WaitForSeconds(3);
        Time.timeScale = 0;
        text.color = Color.red;
        text.text = "사망하셨습니다!\n 재시작 하시려면 B키를 누르십시오!";
    }
}
