using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class final : MonoBehaviour
{
    public playerSeo SEO;
    public OVRScreenFade scrFade;
    public Text myscr;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // �̰� Ǯ�� ��

     }
    void OnTriggerEnter(Collider other)
    {
        SEO.endCheck = true; // ���� ȭ������ ���� �� �ְ� ��� ����

        myscr.color = Color.white;
        myscr.text = "Ż���ϼ̽��ϴ�!\n������ ��Ȳ���� ħ���ϰ� �����̸�\n������ �� �ֽ��ϴ�!";
        //myscr.gameObject.SetActive(false);
        // scrFade.FadeOut();
   
        //StartCoroutine(End2());

    }
    IEnumerator End2()
    {
        SceneManager.LoadScene("MainMenu");
        yield return new WaitForSeconds(5);
        
    }
}
