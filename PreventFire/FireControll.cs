using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireControll : MonoBehaviour
{
    public GameObject[] Farray1;
    public GameObject[] Farray2;
    public GameObject[] Farray3;
    // 각각 1, 2, 3층의 불들
    
    public void ignite(int num)
    {
        if (num == 1)
        {
            for (int i = 0; i < Farray2.Length; i++)
            {
                Farray2[i].gameObject.SetActive(true);
            }
        } // 2층에 도달하기 전에 2층 불들 다 키기
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
        } // 3층에 도달하기 전에 3층 불들 다 키고, 1층 불들 다 끄기
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
        // 시작하자마자 2,3층의 불들은 끄고 시작하기
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
