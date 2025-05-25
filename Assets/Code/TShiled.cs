using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TShiled : MonoBehaviour {
    SpriteRenderer Shlied;
	// Use this for initialization
	void Start () {
        Shlied = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(RetryChar.TShlied == true)
        {
            Shlied.enabled = true;
        }
        if (RetryChar.TShlied == false)
        {
            Shlied.enabled = false;
        }
    }
}
