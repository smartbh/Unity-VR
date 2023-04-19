using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerFire : MonoBehaviour
{
    public double hp; // ü��
    public bool hitCheck = false;
    public OVRScreenFade ScrFade;
    public bool deadCheck = false; // �׾����� Ȯ���ؼ� �׾����� ����� �����ϵ��� �ϴ� ����
    public Text text;

    void dead()
    {
        // backsound.deathSound();
        // PDead() ��������
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
            // ���� �� �����
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
            Debug.Log("hp�� = "+ hp);
        } 
        //if (other.gameObject.tag == "Fog")
        //{
        //    /*GetComponent<AudioSource>().Play();*/
        //}
        // �� ������ ������
    }
    IEnumerator Hold()
    {
        yield return new WaitForSeconds(3);
        Time.timeScale = 0;
        text.color = Color.red;
        text.text = "����ϼ̽��ϴ�!\n ����� �Ͻ÷��� BŰ�� �����ʽÿ�!";
    }
}
