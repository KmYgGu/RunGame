using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarnOut : MonoBehaviour {

	// Use this for initialization
	void Start () {
        /*if (!(Curser.i == 0 && Curser.j == 1))
            this.gameObject.SetActive(false);//루카스가 아니라면 작동안함*/
    }
	
	// Update is called once per frame
	void Update () {
        Invoke("Delete", 1f);//1초에 자동 삭제
    }
    public void Delete()
    {
        this.gameObject.SetActive(false);
    }
}
