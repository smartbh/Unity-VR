using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireControll : MonoBehaviour
{
    public GameObject[] Farray1;
    public GameObject[] Farray2;
    public GameObject[] Farray3;
    // ���� 1, 2, 3���� �ҵ�
    
    public void ignite(int num)
    {
        if (num == 1)
        {
            for (int i = 0; i < Farray2.Length; i++)
            {
                Farray2[i].gameObject.SetActive(true);
            }
        } // 2���� �����ϱ� ���� 2�� �ҵ� �� Ű��
        if (num == 2)
        {
            for (int i = 0; i < Farray3.Length; i++)
            {
                Farray3[i].gameObject.SetActive(true);
            }
            for (int i = 0; i < Farray1.Length; i++)
            {
                Farray1[i].gameObject.SetActive(true);
            }
        } // 3���� �����ϱ� ���� 3�� �ҵ� �� Ű��, 1�� �ҵ� �� ����
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i<Farray2.Length; i++)
        {
            Farray2[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < Farray3.Length; i++)
        {
            Farray3[i].gameObject.SetActive(false);
        }
        // �������ڸ��� 2,3���� �ҵ��� ���� �����ϱ�
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
