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

    public void btnShipDisaster() //선박사고
    {
        SceneManager.LoadScene("ShipDisasterScene");
        SceneManager.UnloadSceneAsync("MainMenu");
    }
    public void btnEarthQuake() //지진
    {
        SceneManager.LoadScene("Earthquake");
        SceneManager.UnloadSceneAsync("MainMenu");
    }
    public void btnPlaneFall() //항공사고
    {
        SceneManager.LoadScene("Airplane");
        SceneManager.UnloadSceneAsync("MainMenu");
    }
    public void btnFire() //화재
    {
        SceneManager.LoadScene("PreventFire");
        SceneManager.UnloadSceneAsync("MainMenu");
    }

    public void btnGameOut() //게임 종료
    {
        Application.Quit();
    }
}
