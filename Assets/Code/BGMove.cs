using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMove : MonoBehaviour {
    Vector3 leftMove = new Vector3(-10, 0, 0);
    //SpriteRenderer rend;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(leftMove * ((Time.deltaTime) *0.1f));
        if (transform.position.x < -20)
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}
