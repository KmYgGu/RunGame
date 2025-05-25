using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingWall : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        transform.Translate(0, -(1f * Time.deltaTime), 0);
	}
}
