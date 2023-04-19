using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicsButton : MonoBehaviour
{
    public UnityEvent onPressed, onReleased;
    [SerializeField] private float threshold = 0.1f;
    [SerializeField] private float deadzone = 0.025f;

    private bool isPressed;
    private Vector3 startPos;
    private ConfigurableJoint joint;

    private AudioSource FireAlarmBox;
    public AudioClip FireAlarm;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.localPosition;
        joint = GetComponent<ConfigurableJoint>();
        FireAlarmBox = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPressed && GetValue() + threshold >= 1)
            Pressed();
        if (!isPressed && GetValue() - threshold <= 0)
            Released();
    }

    private float GetValue()
    {
        var value = Vector3.Distance(startPos, transform.localPosition) / joint.linearLimit.limit;

        if (Mathf.Abs(value) < deadzone)
        {
            value = 0;
        }

        return Mathf.Clamp(value, -1f, 1f); 
    }

    private void playSound(AudioClip clip, AudioSource source)
    {
        source.Stop();
        source.clip = clip;
        source.loop = true;
        source.time = 0;
        source.Play();
    }

    private void Pressed() //눌렸을때
    {
        isPressed = true;
        onPressed.Invoke();
        playSound(FireAlarm, FireAlarmBox);
        //Debug.Log("버튼이 눌렸습니다.");
    }

    private void Released()
    {
        isPressed = false;
        onReleased.Invoke();
       // Debug.Log("버튼이 눌리지 않았습니다.");
    }
}
