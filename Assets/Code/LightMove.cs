using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMove : MonoBehaviour {//사용안함

    //public Transform target;
    public GameObject target;

    private Transform tr;

    // Use this for initialization
    void Start () {
        tr = GetComponent<Transform>();
        //target = GameObject.FindGameObjectWithTag("Player");

    }
	
	// Update is called once per frame
	void Update () {
        target = GameObject.FindGameObjectWithTag("Player");
        tr.position = target.transform.position;
        //transform.localScale -= new Vector3(DarkTurn.Count, DarkTurn.Count, 0) * Time.deltaTime;

    }
}
