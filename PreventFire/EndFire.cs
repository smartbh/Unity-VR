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
        GameObject rootObj = transform.root.gameObject; //�ֻ��� �θ�
        rootObj.gameObject.SetActive(false);//�θ� ���� ���� ���ӿ��� ������
        EventCanvas.GetComponent<Canvas>().gameObject.SetActive(false); //ĵ���� �ٽ� ����
        Time.timeScale = 1f;//resume
    }

    public void btnGameOver()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        SceneManager.UnloadSceneAsync("PreventFire");
    }
}
