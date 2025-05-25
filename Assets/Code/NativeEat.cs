using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NativeEat : MonoBehaviour {
    public float Follow;
    public GameObject target;
    //private Transform tr;
    void Start () {
        //this.gameObject.SetActive(false);
        transform.Translate(-1, 0, 0);
        Follow = -1;
    }
	
	// Update is called once per frame
	void Update () {
        if(RetryChar.life <= 1.5)
        {
            transform.Translate(0.05f * Time.deltaTime, 0, 0);
            Follow += 0.05f * Time.deltaTime;
        }
        if(Follow >= -1)
        {
            if (RetryChar.life > 1.5)
            {
                transform.Translate(-(0.05f * Time.deltaTime), 0, 0);
                Follow -= 0.05f * Time.deltaTime;
            }
        }
        target = GameObject.FindGameObjectWithTag("Player");
        if (gameObject.transform.position.y < target.transform.position.y)
        {
            transform.Translate(0, 0.1f, 0);
        }
        if (gameObject.transform.position.y > target.transform.position.y)
        {
            transform.Translate(0, -0.1f, 0);
        }
        //tr.position = target.transform.position;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")//원주민에게 닿을 경우
        {
            collision.gameObject.SetActive(false);
            RetryChar.Eaten = true;
            //Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }
}
