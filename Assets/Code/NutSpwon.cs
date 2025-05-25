using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutSpwon : MonoBehaviour {
    public GameObject NutPrefab;//프리펩 땅
	// Use this for initialization
	void Start () {
        if (Curser.i == 1 && Curser.j == 3)//심영
        {
            NutPrefab.SetActive(true);
        }
        if (!(Curser.i == 1 && Curser.j == 3))//심영이 아닐경우
        {
            NutPrefab.SetActive(false);
        }
        StartCoroutine(NutGo());

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator NutGo()
    {
        yield return new WaitForSeconds(1.5f);
        Instantiate(NutPrefab, new Vector2(18.26f, Random.Range(-2, 5)), Quaternion.identity);
        StartCoroutine(NutGo());
    }
}
