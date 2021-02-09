using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{

    //キューブの移動速度
    private float speed = -12;
    //消滅位置
    private float deadLine = -10;

    public AudioSource audioSource;
    public AudioClip sound;
    private GameObject cube;


    // Start is called before the first frame update
    void Start()
    {
        this.cube = GameObject.Find("CubePrefab");
        audioSource = GetComponent<AudioSource>();

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
        if (other.gameObject.tag == "cube" || other.gameObject.tag == "ground")
        {
            //音を出す
            audioSource.PlayOneShot(sound);
        }
       
    }

}
