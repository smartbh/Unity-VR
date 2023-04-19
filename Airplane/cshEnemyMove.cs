using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cshEnemyMove : MonoBehaviour
{
    public float speed = 12f;//Player의 이동 속도
    public float moveableRange = 8f; // 이동 가능한 범위
    public float power = 200f; // waapon 발사하는 힘


    public GameObject cannonBall; //Player에서 발사할 weapon
    public Transform spawnPoint; //weapon 발사 지점



    void Update()
    {
        //Player 이동 (이동 범위를 movableRange로 제한)
        /*transform.Translate(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0, 0);*/
        transform.Translate(  Vector2.left * speed * Time.deltaTime);
        /* transform.position
         = new Vector2(Mathf.Clamp(transform.position.x, -moveableRange, moveableRange), transform.position.y);
        */



    }
    /*void Shoot()
    {
       
        GameObject newBullet = Instantiate(cannonBall, spawnPoint.position, Quaternion.identity) as GameObject;
       
        newBullet.GetComponent<Rigidbody2D>().AddForce(Vector2.right * power);
    }*/


}
