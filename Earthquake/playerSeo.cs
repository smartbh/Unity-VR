using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class playerSeo : MonoBehaviour
{
    // 1. Character Controller �� ĳ������ ��, �ൿ ����, �浹 ����
    // 2. Transfrom.Scale �� ī�޶��� ��ġ 
    public shaketest manager; // shaketest �Լ� 

    bool timer = false; // time ������ ���� �ְ� ����Ǵ� ���θ� �����ϴ� bool ��

    float scax; // ������ ����, �Ͼ�ų� ���� �� ũ�� ����
    float scay; // ������ ����, �Ͼ�ų� ���� �� ũ�� ����
    float scaz; // ������ ����, �Ͼ�ų� ���� �� ũ�� ����

    float time; // �ð� ����, ���߿� ���� �ְ� ���� ��
    int hp = 100; // ü��, �ʱⰪ�� 100���� ����, 0 ������ �������� ���� �ϵ��� ���� ���� 

    private bool isPause = true;
    public bool hitcheck = false; // Ÿ�� ����
    bool deadCheck = false; // �׾����� Ȯ���ؼ� �׾����� ����� �����ϵ��� �ϴ� ����
    public bool endCheck = false; // ���� �� �ִ� ����
    public bool crouchCan = true; // �ɴ� �� �����ϸ� true, �Ұ����ϸ� false. �⺻���� true
    public bool croushStatus = false; // �������� false, �ɾ������� true. �⺻ ���� false

    int itd = 0;

    public OVRScreenFade scrFade;

    CharacterController cont = null; // ĳ���� ��Ʈ�ѷ�, �̰ɷ� �÷��̾��� ���� �����Ϸ��� ��
    // ���� Character Controller�� radius�� height �� �����ϴ� ���� 2��


    public Camera cam;
    public Text myscr;

    void FStart()
    {
        myscr.text = "������ ���۵Ǿ����ϴ�.";
        StartCoroutine(Ye());
    }

    void Crouch()
    {
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) && croushStatus == false && crouchCan == true)
        {
            cont.height = 0.3f; // Character Controller ���� ���߱�
            cont.detectCollisions = false; // �ٸ� ��ü���̶� �浹���� �� ƨ��� ����
            this.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            // �� ��� ũ�⺸�� ���� å�� ������ �ɾƼ� ������ �� ����

            //head.center = new Vector3(0.0f, 0.25f, 0.0f);
            //head.radius = 0.25f;

            //Stone.transform.position = new Vector3(0.0f, 0.25f, 0.0f);

            croushStatus = true; // �ɾ��ִ� ����
        }
        else if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) && croushStatus == true && crouchCan == true)
        {
            cont.height = 2f; // Character Controller ���� Ű���
            cont.detectCollisions = false;
            this.transform.localScale = new Vector3(scax, scay, scaz);

            //head.center = new Vector3(0.0f, 0.7f, 0.0f);
            //head.radius = 0.5f;

            //Stone.transform.position = new Vector3(0.0f, 0.7f, 0.0f);

            croushStatus = false; // ���ִ� ����
        }
        if (OVRInput.GetDown(OVRInput.Button.Two) && deadCheck == true)
        {
            // ���� �� �����
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //SceneManager.LoadScene(0);

        }
    }

    void PDead() // HP ������ 0 ���Ϸ� �������� ������ �����ϴ� �Լ�
    {
        Debug.Log("YOU DIED!!!!!!!!!!!!!!");
        // �� �� ����

        StartCoroutine((Fade(Color.white, Color.black, 1f)));
        myscr.color = Color.red;
        myscr.text = "����ϼ̽��ϴ�!\n ����� �Ͻ÷��� B��ư�� ��������!";
        deadCheck = true;
        hitcheck = true;
        StartCoroutine(Hold());

    }

    public void PHit(int Damage)
    {
        scrFade.fadeColor = Color.red;
        scrFade.FadeIn();
        // ������ 0.3�ʵ��� ��ũ���� Red Color�� Fade�ǵ��� ����

        GetComponent<AudioSource>().Play(); // (hit) ���� ����


        hp -= Damage;
        if (hp <= 0)
        {
            PDead(); // ������ �Լ� ����
        }
        Debug.Log("YOU HIT!!!!");
        // �� ���� ������ ü�� ǥ��, ���� �ð� ȿ��


    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        hp = 100;
        hitcheck = false;
        deadCheck = false;
        endCheck = false;
        // ���� �ʱ�ȭ�ϰ� ���� (����۵� ������ �־� �ϱ� ����)

        cont = this.GetComponent<CharacterController>(); // Character Controller�� ������ �� �ְ� cont �������� �ʱ�ȭ

        scax = this.transform.localScale.x;
        scay = this.transform.localScale.y;
        scaz = this.transform.localScale.z; // ������ x,y,z ���� ������ ����

        FStart(); // �����ϸ� �ؽ�Ʈ ����ϴ� �� ����

    }

    // Update is called once per frame
    void Update()
    {
        Crouch();
        if (timer == true)
        {
            time -= Time.deltaTime; // �� �����Ӹ��� time ���� ���
            Debug.Log("time is " + time);
        }

        if (time < 0.0f) // time�� 0 ������ ��������
        {
            time = 0.0f; // �ϴ� time ������ 0 ���� �����
            timer = false; // timer �۵����� �ʵ��� ����
            manager.pointer = false; // shaketest���� ���� �߻� ���߱�
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
            if (i == 0) { myscr.text = "������ �� ������ �߻��Ұ̴ϴ�"; }
            else if (i == 1) { myscr.text = "������ �ùķ��̼�����,\n �� ���� ������Ģ�� ��Ű�� \n������ �� �ֽ��ϴ�"; }
            else if (i == 2) { myscr.text = "������ Ʈ���Ÿ� ���� �ɾƼ�\nå�� ������ ������ �� �ֽ��ϴ�."; }
            else if (i == 3) { myscr.text = "���ſ� ��ü���� ����\n�ʵ��� �����Ͻʽÿ�"; }
        }
        myscr.text = "";
        manager.sit1 = false; // ���� Event1 �� ���� �ɼ� �ֵ��� ��� ����
    }
    IEnumerator Fade(Color from, Color to, float tim)
    {
        float speed = 1 / tim;
        float percent = 0;

        // Debug.Log("���� ���� Speed is " + speed);
        while (percent < 1)
        {
            //Debug.Log("���� ���� ���� ��....." + percent);
            //percent += Time.deltaTime * speed;
            percent += Time.deltaTime;
            scrFade.fadeColor = Color.Lerp(from, to, percent);
            scrFade.FadeIn();
            //Debug.Log(scrFade.fadeColor);
            yield return null;
        }
        //scrFade.FadeOut();

        Debug.Log("���� End");
    }
}
