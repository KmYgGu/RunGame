using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MacSpwon : MonoBehaviour {
    public GameObject MacPrefab;//프리펩 총알
    public GameObject Donaldsd;
    // Use this for initialization
	// Update is called once per frame
	void Start () {
        //BuitSpown();
        StartCoroutine(MackSpwon());
    }
    void BuitSpown()
    {
        if (Donald.Dona == 3)
        {
            Instantiate(MacPrefab, new Vector2((Donaldsd.transform.position.x) + 1, Donaldsd.transform.position.y), Quaternion.identity);
            //RetryChar.Shooting = false;
        }
    }
    IEnumerator MackSpwon()
    {
        if ((Donald.Magic == true) || (DonaldUno.UnoMagic == true))
        {
            //yield return new WaitForSeconds(0);
            Instantiate(MacPrefab, new Vector2((Donaldsd.transform.position.x) + 1, Donaldsd.transform.position.y), Quaternion.identity);
            Donald.Magic = false;
            DonaldUno.UnoMagic = false;
        }
        yield return new WaitForSeconds(0);
        StartCoroutine(MackSpwon());
    }

}
