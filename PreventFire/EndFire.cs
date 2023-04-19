using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndFire : MonoBehaviour
{
    private Canvas EventCanvas;

    private void Start()
    {
        EventCanvas = GetComponent<Canvas>();
    }
    public void btnEnd()
    {
        GameObject rootObj = transform.root.gameObject; //최상위 부모
        rootObj.gameObject.SetActive(false);//부모 포함 전부 게임에서 없애줌
        EventCanvas.GetComponent<Canvas>().gameObject.SetActive(false); //캔버스 다시 가림
        Time.timeScale = 1f;//resume
    }

    public void btnGameOver()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        SceneManager.UnloadSceneAsync("PreventFire");
    }
}
