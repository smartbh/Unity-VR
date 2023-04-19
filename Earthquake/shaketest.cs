using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class shaketest : MonoBehaviour
{
    public Event1 ev1; // Event1 ��ũ��Ʈ�� ������ ������, ���⿡�� text�� �����϶�� ����� �������̱� ����
    public Event2 ev2; // Event1 ��ũ��Ʈ�� ������ ������, ���⿡�� text�� �����϶�� ����� �������̱� ����
    public Event3 ev3; // Event1 ��ũ��Ʈ�� ������ ������, ���⿡�� text�� �����϶�� ����� �������̱� ����
    public Event4 ev4; // Event1 ��ũ��Ʈ�� ������ ������, ���⿡�� text�� �����϶�� ����� �������̱� ����
    public Event5 ev5; // Event1 ��ũ��Ʈ�� ������ ������, ���⿡�� text�� �����϶�� ����� �������̱� ����

    float sin = 0.1f; // �¿��
    float csin = 0.3f; // ���Ʒ���
    float zsin = 0.1f; // ���Ϸ�

    // float xsin = 0.05f; // ���� ����

    float rnd1; // sin
    float rnd2; // csin
    float rnd3; // zsin
    //float rnd4; // xsin

    float freq = 15;

    Vector3 fro; // from, ���⼭���� ����
    Vector3 to; // to, ���⸦ �� ��������

    float fromx;
    float fromy;
    float fromz; // x,y,z ��ǥ���� �ʱ� ��ġ ����

    public bool pointer = true; // ���� ���� ����, �⺻ ���� false�� �ؾ� ��!, true�� �ٲٸ� ������ �����
    public bool sit1 = true; // �̰͸� �� ó���� true�� �� ���� �� ó�� 20�� save�� ����!
    public bool sit2 = false;
    public bool sit3 = false;
    public bool sit4 = false;
    public bool sit5 = false;
    // �� �̺�Ʈ ���� ������

    public bool check1 = false;
    public bool check2 = false;
    public bool check3 = false;
    public bool check4 = false;
    public bool check5 = false;

    public float limitTimer = 0.0f;

    private IEnumerator coroutine;

    public void PlaySound()
    {
        GetComponent<AudioSource>().Play(); // (quake) ���� ����, �ܺ� (player ��ũ��Ʈ)���� ������
    }

    // Start is called before the first frame update
    void Start()
    {
        fro = this.transform.position; // �ʱ� ��ġ���� ����
        fromx = fro.x;
        fromy = fro.y;
        fromz = fro.z;
    }

    // Update is called once per frame
    void Update()
    {
        //time += Time.deltaTime;
        if (pointer == true) // pointer�� true �϶��� ������
        {
            Debug.Log("shaketest ����");
            coroutine = Shaking(limitTimer);
            StartCoroutine(coroutine);
            pointer = false;



        }
    }

    // �ڷ�ƾ���� 10�ʵ��� 0.003�� �������� �����ϵ��� ������ ��.
    IEnumerator Shaking(float maxtime)
    {
        float time = 0f;

        while (time < maxtime)
        {
            rnd1 = Random.Range(fromx - sin, fromx + sin); // �¿� ��鸲 ���� 
            rnd2 = Random.Range(fromy - csin, fromy + csin); // ���Ʒ� ��鸲 ����
            rnd3 = Random.Range(fromz - zsin, fromz + zsin); // ���� ��鸲 ����

            to = new Vector3(rnd1, rnd2, rnd3); // target�� ���� ������ (��鸱 ��Ҹ� ����)

            this.transform.position = Vector3.Lerp(this.transform.position, to, 0.002f); // ��ġ ������ �ش� ��ҷ� �̵�

            yield return new WaitForSeconds(0.002f);

            time += 0.002f;

            if (time < maxtime / 1.33)
            {
                if (sin < 4.0f) { sin += 0.01f; }
                if (csin < 2.5f) { csin += 0.01f; }
                if (zsin < 3.0f) { zsin += 0.01f; }
                // ���������� ���̱�
            }


            if (time >= maxtime / 1.33)
            {
                if (sin > 0.1f) { sin -= 0.01f; }
                if (csin > 0.3f) { csin -= 0.01f; }
                if (zsin > 0.1f) { zsin -= 0.01f; }
                // ���������� ������
            }



        }
        Debug.Log("shaketest ����");

        to = new Vector3(fromx, fromy, fromz);
        this.transform.position = Vector3.Lerp(this.transform.position, to, 1);

        sin = 0.1f;
        csin = 0.3f;
        zsin = 0.1f;
        yield return new WaitForSeconds(2);
        if (sit1 == true && check1 == false) { ev1.chnC(); } // Event1 ��ũ��Ʈ�� ���� text ���ֶ�� �ϱ�, ����ִ� �� ����
        if (sit2 == true && check2 == false) { ev2.chnC(); }
        if (sit3 == true && check3 == false) { ev3.chnC(); }
        if (sit4 == true && check4 == false) { ev4.chnC(); }
        if (sit5 == true) { ev5.chnC(); }

    }
}
