using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cshMainMenuCanvas : MonoBehaviour
{
    private Canvas EventCanvas;

    // Start is called before the first frame update
    void Start()
    {
        EventCanvas = GetComponent<Canvas>();
    }

    public void btnShipDisaster() //���ڻ��
    {
        SceneManager.LoadScene("ShipDisasterScene");
        SceneManager.UnloadSceneAsync("MainMenu");
    }
    public void btnEarthQuake() //����
    {
        SceneManager.LoadScene("Earthquake");
        SceneManager.UnloadSceneAsync("MainMenu");
    }
    public void btnPlaneFall() //�װ����
    {
        SceneManager.LoadScene("Airplane");
        SceneManager.UnloadSceneAsync("MainMenu");
    }
    public void btnFire() //ȭ��
    {
        SceneManager.LoadScene("PreventFire");
        SceneManager.UnloadSceneAsync("MainMenu");
    }

    public void btnGameOut() //���� ����
    {
        Application.Quit();
    }
}
