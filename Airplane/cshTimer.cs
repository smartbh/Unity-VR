using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class cshTimer : MonoBehaviour
{

    public Text textbox;
    public float timestart;
    float startTime;
    TextMesh textMesh;


    public static float timer = 60;

    void Start()
    {
        textbox.text = timestart.ToString();
      //  startTime = Time.time;
      //  textMesh = this.gameObject.GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        int M = (int)(timestart / 60);
        //  float S = timestart % 60;
        int S = (int)(timestart % 60);
        //  Mathf.Round(timestart).ToString()
        timestart += Time.deltaTime;
        textbox.text = M + " : " + S;
        


        for (int i = 1; i < 20; i++)
        {
            /* if (S == i)
                 realEvent = i;*/

        }
       // float guiTime = timer - (Time.time - startTime);
      //  if (guiTime > 0)
     //   {
       //     int minutes = (int)(guiTime / 60);
       //     int seconds = (int)(guiTime % 60);
       //     int fraction = (int)((guiTime * 100) % 100);

           // textMesh.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, fraction);
        //}
    }

}
