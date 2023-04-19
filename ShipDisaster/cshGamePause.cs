using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshGamePause : MonoBehaviour
{
    public Canvas EventCanvas;

    // Start is called before the first frame update
    private void Start()
    {
        EventCanvas.GetComponent<Canvas>().gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            EventCanvas.GetComponent<Canvas>().gameObject.SetActive(true);
            Time.timeScale = 0f; //Pause
        }
    }
}
