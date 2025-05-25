using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour {
    Vector3 RightMove = new Vector3(10, 0, 0);
    // Use this for initialization

	// Update is called once per frame
	void Update () {
        Gun();
	}
    void Gun()
    {
        float fMove = (Time.deltaTime) * 1;
        transform.Translate(RightMove * fMove);
        if (transform.position.x > 14)
            Destroy(gameObject);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
    /*void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }*/
}
