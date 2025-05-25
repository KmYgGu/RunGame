using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collecter : MonoBehaviour {
    public AudioSource BGaudio;
    public AudioClip BGSound1;

    void Start()
    {
        BGaudio = gameObject.AddComponent<AudioSource>();
        BGaudio.clip = BGSound1;
        BGaudio.loop = true;
        BGaudio.Play();
    }

    void OnTriggerEnter2D(Collider2D target)//온트리커 체크해둬야 작동되요
    {
       if (target.tag == "Ground"||target.tag == "Wall"||target.tag == "Coin" || target.tag == "Deleteme" || target.tag == "HpUp")//태그가 해당되는 놈을
        {
            target.gameObject.SetActive(false);//제거
            //Destroy(target.gameObject); //비용이 더많이 든다해서 취소
        }
    }
}
