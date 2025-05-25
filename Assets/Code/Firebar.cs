using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firebar : MonoBehaviour {
    Transform Fire;
	// Use this for initialization
	void Start () {
        this.Fire = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        //Fire.transform.localScale -= new Vector3(DarkTurn.Count, 0, 0) * Time.deltaTime;
        if(Fire.transform.localScale.x >= 0.04)
        Fire.transform.localScale -= new Vector3(0.05f, 0, 0) * Time.deltaTime;
    }
}
