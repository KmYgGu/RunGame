using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpown : MonoBehaviour {

    public GameObject BulletPrefab;//프리펩 총알
    public GameObject piter;
    // Update is called once per frame
    void Update () {
        BuitSpown();
    }

    void BuitSpown()
    {
        if(RetryChar.Shooting == true)
        {
            Instantiate(BulletPrefab, new Vector2((piter.transform.position.x)+1, piter.transform.position.y), Quaternion.identity);
            RetryChar.Shooting = false;
        }
    }
}
