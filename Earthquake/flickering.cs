using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flickering : MonoBehaviour
{
    public bool flick = true;
    public bool swit = true; // 깜빡이는거 제어 (한번 flickering 하면 더 이상 같은 짓을 못하도록 설정하는 bool 변수)

    public float delay = 0.5f;

    float star = 0.01f;
    float en = 0.2f;

    public void stopped()
    {
        // en = 10f;
        swit = false; // 이제 더 이상 flickering 하지 않음
    }

    // Update is called once per frame
    void Update()
    {
        if (flick == false && swit == true)
        {
            StartCoroutine(Flickering());
        }
    }

    IEnumerator Flickering()
    {
        flick = true;
        this.gameObject.GetComponent<Light>().enabled = false;
        delay = Random.Range(star, en);
        yield return new WaitForSeconds(delay);
        this.gameObject.GetComponent<Light>().enabled = true;
        delay = Random.Range(star, en);
        yield return new WaitForSeconds(delay);
        flick = false;
    }
}
