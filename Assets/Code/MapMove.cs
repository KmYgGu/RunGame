using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMove : MonoBehaviour {
    public static float speedselect = -1;
    public float mapspeed;
    private Transform Ground;
    Vector3 leftMove = new Vector3(-10, 0, 0);
    //Vector3 leftMove = new Vector3.left;
    // Use this for initialization
    void Start () {
        Ground = GetComponent<Transform>();
        mapspeed = -1;      
	}
	
	// Update is called once per frame
	void Update () {
        GroundMove();
        mapspeed = speedselect;
    }

    void GroundMove ()
    {
        float fMove = -(Time.deltaTime) * mapspeed;
        //float fMove = mapspeed;
        Ground.transform.Translate(leftMove * fMove);
    }
}
