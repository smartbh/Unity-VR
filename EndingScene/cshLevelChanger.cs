using UnityEngine;
using UnityEngine.SceneManagement;

public class cshLevelChanger : MonoBehaviour
{
    public Animator animator;
    private string levelToLoad;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            FadeToLevel("MainMenu");
        }
        if(OVRInput.Get(OVRInput.Button.One))
        {
            FadeToLevel("MainMenu");
        }

    }

    public void FadeToLevel(string sceneName)
    {
        levelToLoad = sceneName;
        animator.SetTrigger("FadeOut"); 
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
        SceneManager.UnloadSceneAsync("EndingCutScene");
    }
}
