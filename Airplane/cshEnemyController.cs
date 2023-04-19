using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshEnemyController : MonoBehaviour
{
    private int hp = 3;

    public void Damage()
    {
        hp--;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public int GetHP()
    {
        return hp;
    }

}
