using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fruit : MonoBehaviour
{
    public GameObject fruitSlicedPrefab;
    public GameObject splashPrefab;
    GameObject game;

    public float startForce = 15f;
    Rigidbody2D rb;

    void Start(){
        game = GameObject.Find("Game");
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D col){

        if(col.tag == "Blade"){

            /*分数处理*/
            if(CompareTag("wrong"))
            {
                game.GetComponent<Points>().ChangePoints(1);
            }else if (CompareTag("correct"))
            {
                game.GetComponent<Points>().ChangePoints(-1);
            }

            Vector3 direction = (col.transform.position - transform.position).normalized;

            Quaternion rotation = Quaternion.LookRotation(direction);

            GameObject slicedFruit = Instantiate(fruitSlicedPrefab, transform.position, rotation);
            GameObject splashWord = Instantiate(splashPrefab, transform.position, rotation);
            //Debug.Log(fruitSlicedPrefab.transform);
            //Debug.Log("WE HIT THE WATERMELON!");

            //游戏对象被销毁了还能执行？？
            Destroy(slicedFruit, 3f);
            Destroy(splashWord, 4f);
            Destroy(gameObject);
        }
    }

}
