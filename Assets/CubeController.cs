using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{

    //キューブの移動速度
    private float speed = -12;
    //消滅位置
    private float deadLine = -10;

    public AudioClip sound;
    //地面の位置
    private float groundLevel = -3.0f;
    private GameObject cube;



    // Start is called before the first frame update
    void Start()
    {
        this.cube = GameObject.Find("CubePrefab");

        //着地しているか調べる
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
       
    }

    // Update is called once per frame
    void Update()
    {
        //キューブを移動させる
        transform.Translate(this.speed * Time.deltaTime, 0, 0);
        //画面外に出たら破棄する
        if(transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        AudioSource.PlayClipAtPoint(sound, transform.position);
    }

}
