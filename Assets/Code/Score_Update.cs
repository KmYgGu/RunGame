using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Update : MonoBehaviour {

    Text scoreLabel;

	// Use this for initialization
	void Start () {
        scoreLabel = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        scoreLabel.text =  Score_Manager.score.ToString();//"아이좋아" + 추가하면 문자열 출력가능
    }
}
