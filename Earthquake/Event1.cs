using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Event1 : MonoBehaviour
{
    Rigidbody rb; // Rigidbody �� (������Ʈ�� �迭 ��)
    public GameObject door; // Rigidbody �� (���� ���� ���� Kinematic�� ������ ���� ��)
    private GameObject rootDoort;


    public shaketest manager; // �ٸ� shaketest ��ũ��Ʈ
    public flickering[] farray; // (Toilet ����) Light�� ��� �迭

    public GameObject[] array; // ���� ������Ʈ (DMG1 && Toilet_Object)�� ��� �迭
    //public GameObject door; // ���� ���� ���� Kinematic�� ������ ����

    public Text t; // Text �� ��������

    public bool check = false; // false�� �ؽ�Ʈ �� �����, true�� ���� ��


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void chnC() // ���� �� ������ �Լ�
    {
        Debug.Log("chnC ����");
        t.text = ""; // �ؽ�Ʈ ����
        //Destroy(t);
        for (int i = 0; i < farray.Length; i++)
        {
            farray[i].stopped(); // �� �Һ��� ���� ����� ���
        }
        // door = GetComponent<Rigidbody>(); // �ϴ� rigidbody ���� �ޱ� (unity���� ���� ���� / �� �־��ֱ� ���� ����!)
        // door.isKinematic = false; // kinematic �����ؼ� ���� �� �ֵ���!

        rootDoort = door.transform.parent.gameObject; //�ֻ��� �θ�
        rootDoort.gameObject.SetActive(false);//�θ� ���� ���� ���ӿ��� ������

        //Destroy(door);
    }


    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        array = GameObject.FindGameObjectsWithTag("DMG1");
        Debug.Log("DMG1�� ������Ʈ ������ " + array.Length + "�̴�.");

        if (manager.sit1 == false) // ��Ȳ1�� �ѹ��� ���� �� �� ���¸� �Ʒ��� ��ũ��Ʈ �����
        {
            manager.sit1 = true; // ��Ȳ1�� �� �̻� ������� �ʵ��� true�� ��Ź�����

            t.text = "������ �߻��߽��ϴ�!\n���� ���̳�, �������� ������ �ִ� ������ ���� ���ʽÿ�!";

            GetComponent<AudioSource>().Play(); // ���� ���� ����
            manager.PlaySound();

            manager.limitTimer = 2.8f; // ������ ���� �ð��� n�ʰ� �ǵ��� shaketest ���� limitTimer �� n�ʷ� �����ϱ�
            manager.pointer = true; // ���� �����ϵ��� shaketest ���� pointer �� �ٲٱ�

            for (int i = 0; i < array.Length; i++) // ������ ������Ʈ�� (�迭) ���ٰ� Rigidbody �ֱ�
            {
                rb = array[i].AddComponent<Rigidbody>(); // �ϳ��ϳ��� Rigibody �ο�
                rb.mass = 5f; // ���� ���� 5�� ����               
            }
            for (int i = 0; i < farray.Length; i++)
            {
                farray[i].flick = false;
            }
        }
        
    }

}
