using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    //������Ʈ�� �����ϴ� ���͹�
    public float deleteTime = 2.0f;

    void Start()
    {
        //������Ʈ�� ������ �� deleteTime ��ŭ �ð��� ����ϸ� ����
        Destroy(gameObject, deleteTime);
    }

}
