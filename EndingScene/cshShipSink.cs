using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cshShipSink : MonoBehaviour
{
    public GameObject Ship;
    private float timeToFinish = 0f;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        shipSink(timeToFinish);
    }

    private float shipSink(float time)
    {
        Ship.transform.Translate(Vector3.down * Time.deltaTime);
        Ship.transform.Rotate(new Vector3(5f, 0, 0) * -Time.deltaTime, Space.World);

        timeToFinish += 1f;
        Debug.Log(timeToFinish);
        Debug.Log("배의 x회전율은 : "+ Ship.transform.rotation.x);
        //Debug.Log(Ship.transform.rotation.x);

        return timeToFinish;
    }
}
