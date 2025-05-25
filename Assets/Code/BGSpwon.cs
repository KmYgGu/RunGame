using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSpwon : MonoBehaviour {

    public GameObject BGPrefab;//프리펩 배경
    public SpriteRenderer rend;
    public int countTime;

    void Start () {
        rend = BGPrefab.gameObject.GetComponent<SpriteRenderer>();
        countTime = 3;
        StartCoroutine(BGspwon());
    }
	
	// Update is called once per frame
	/*void Update () {
		
	}*/

    IEnumerator BGspwon()
    {
        /*if (countTime % 2 == 0)//짝수
        {
            Instantiate(BGPrefab, new Vector2(19.28f, 0.03f), Quaternion.identity);
            //transfrom.localScale = new Vector3(-1, 1, 1);
            rend.flipX = true;

        }
        else //if (countTime % 2 > 0)//홀수
        {
            Instantiate(BGPrefab, new Vector2(19.28f, 0.03f), Quaternion.identity);
            rend.flipX = false;
        }*/
        if (countTime % 2 == 0)//짝수
        {
            Instantiate(BGPrefab, new Vector2(19.28f, 0.03f), Quaternion.identity);
            //transfrom.localScale = new Vector3(-1, 1, 1);
            rend.flipX = false;

        }
        else //if (countTime % 2 > 0)//홀수
        {
            Instantiate(BGPrefab, new Vector2(19.28f, 0.03f), Quaternion.identity);
            rend.flipX = true;
        }

        yield return new WaitForSeconds(19.18f);
        countTime++;
        StartCoroutine(BGspwon());
    }
}
