using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Event4 : MonoBehaviour
{
    Rigidbody rb; // Rigidbody �� (������Ʈ�� �迭 ��)
    public GameObject door; // Rigidbody �� (���� ���� ���� Kinematic�� ������ ���� ��)
    private GameObject rootDoort;
    public shaketest manager; // �ٸ� shaketest ��ũ��Ʈ
    public flickering[] farray; // (Toilet ����) Light�� ��� �迭

    public GameObject[] array; // ���� ������Ʈ (DMG3 && Toilet_Object)�� ��� �迭
    public GameObject[] array2; // ���� ������Ʈ (DMG3 && Toilet_Object)�� ��� �迭
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

        for (int i = 0; i < farray.Length; i++) // �� �����̴°� �ߴ�
        {
            farray[i].stopped(); // �� �Һ��� ���� ����� ���
        }
        rootDoort = door.transform.parent.gameObject; //�ֻ��� �θ�
        rootDoort.gameObject.SetActive(false);//�θ� ���� ���� ���ӿ��� ������
    }


    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        array = GameObject.FindGameObjectsWithTag("DMG4");
        array2 = GameObject.FindGameObjectsWithTag("DMG4-1");
        Debug.Log("DMG4�� ������Ʈ ������ " + array.Length + "�̴�.");

        if (manager.sit4 == false) // ��Ȳ4�� �ѹ��� ���� �� �� ���¸� �Ʒ��� ��ũ��Ʈ �����
        {
            manager.sit4 = true; // ��Ȳ4�� �� �̻� ������� �ʵ��� true�� ��Ź�����
            manager.check3 = true;

            t.text = "�̰��� å���� �����ϴ�!\n������ ������ ���� ������ ���Ͻʽÿ�!";

            GetComponent<AudioSource>().Play(); // ���� ���� ����
            manager.limitTimer = 2.8f; // ������ ���� �ð��� 5�ʰ� �ǵ��� shaketest ���� limitTimer �� 5�ʷ� �����ϱ�
            manager.pointer = true; // ���� �����ϵ��� shaketest ���� pointer �� �ٲٱ�

            for (int i = 0; i < array.Length; i++) // ������ ������Ʈ�� (�迭) ���ٰ� Rigidbody �ֱ�
            {
                rb = array[i].AddComponent<Rigidbody>(); // �ϳ��ϳ��� Rigibody �ο�
                rb.mass = 5f; // ���� ���� 5�� ����
            }
            for (int i = 0; i < array2.Length; i++) // ������ ������Ʈ�� (�迭) ���ٰ� Rigidbody �ֱ�
            {
                rb = array2[i].AddComponent<Rigidbody>(); // �ϳ��ϳ��� Rigibody �ο�
                rb.mass = 100f; // ���� ���� 5�� ����
            }

            for (int i = 0; i < farray.Length; i++)
            {
                farray[i].flick = false;
            }
        }

    }
}
