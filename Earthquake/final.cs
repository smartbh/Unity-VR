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
        // 이거 풀면 됨

     }
    void OnTriggerEnter(Collider other)
    {
        SEO.endCheck = true; // 메인 화면으로 나갈 수 있게 잠금 해제

        myscr.color = Color.white;
        myscr.text = "탈출하셨습니다!\n위급한 상황에도 침착하게 움직이면\n안전할 수 있습니다!";
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
