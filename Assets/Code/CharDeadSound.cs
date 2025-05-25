using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharDeadSound : MonoBehaviour {
    public AudioSource audioA;
    public AudioClip Dead1;
    public AudioSource audioB;
    public AudioClip Dead2;
    public AudioSource audioC;
    public AudioClip Dead3;
    public AudioSource audioD;
    public AudioClip Dead4;
    public AudioSource audioE;
    public AudioClip Dead5;
    public AudioSource audioF;
    public AudioClip Dead6;
    public AudioSource audioG;
    public AudioClip Dead7;
    public AudioSource audioH;
    public AudioClip Dead8;
    public AudioSource audioI;
    public AudioClip Dead9;
    public AudioSource audioJ;
    public AudioClip Dead10;
    public AudioSource audioK;
    public AudioClip Dead11;
    public AudioSource audioL;
    public AudioClip Dead12;

    // Use this for initialization
    void Start () {
        this.audioA = this.gameObject.AddComponent<AudioSource>();
        this.audioA.clip = this.Dead1;
        this.audioA.loop = false;
        this.audioB = this.gameObject.AddComponent<AudioSource>();
        this.audioB.clip = this.Dead2;
        this.audioB.loop = false;
        this.audioC = this.gameObject.AddComponent<AudioSource>();
        this.audioC.clip = this.Dead3;
        this.audioC.loop = false;
        this.audioD = this.gameObject.AddComponent<AudioSource>();
        this.audioD.clip = this.Dead4;
        this.audioD.loop = false;
        this.audioE = this.gameObject.AddComponent<AudioSource>();
        this.audioE.clip = this.Dead5;
        this.audioE.loop = false;
        this.audioF = this.gameObject.AddComponent<AudioSource>();
        this.audioF.clip = this.Dead6;
        this.audioF.loop = false;
        this.audioG = this.gameObject.AddComponent<AudioSource>();
        this.audioG.clip = this.Dead7;
        this.audioG.loop = false;
        this.audioH = this.gameObject.AddComponent<AudioSource>();
        this.audioH.clip = this.Dead8;
        this.audioH.loop = false;
        this.audioI = this.gameObject.AddComponent<AudioSource>();
        this.audioI.clip = this.Dead9;
        this.audioI.loop = false;
        this.audioJ = this.gameObject.AddComponent<AudioSource>();
        this.audioJ.clip = this.Dead10;
        this.audioJ.loop = false;
        this.audioK = this.gameObject.AddComponent<AudioSource>();
        this.audioK.clip = this.Dead11;
        this.audioK.loop = false;
        this.audioL = this.gameObject.AddComponent<AudioSource>();
        this.audioL.clip = this.Dead12;
        this.audioL.loop = false;
        Sound();
    }
	
	// Update is called once per frame
	void Update () {
        

    }

    public void Sound()
    {
        if (Curser.i == 0 && Curser.j == 0)//존
        {
            this.audioA.Play();
        }
        if (Curser.i == 0 && Curser.j == 1)//루카스
        {
            this.audioB.Play();
        }
        if (Curser.i == 0 && Curser.j == 2)//힙합보이
        {
            this.audioC.Play();
        }
        if (Curser.i == 0 && Curser.j == 3)//몽키
        {
            this.audioD.Play();
        }
        if (Curser.i == 0 && Curser.j == 4)//험버트
        {
            this.audioE.Play();
        }
        if (Curser.i == 0 && Curser.j == 5)//태양맨
        {
            this.audioF.Play();
        }
        if (Curser.i == 1 && Curser.j == 0)//테일러
        {
            this.audioG.Play();
        }
        if (Curser.i == 1 && Curser.j == 1)//어쌔신
        {
            this.audioH.Play();
        }
        if (Curser.i == 1 && Curser.j == 2)//도날드
        {
            this.audioI.Play();
        }
        if (Curser.i == 1 && Curser.j == 3)//심영
        {
            this.audioJ.Play();
        }
        if (Curser.i == 1 && Curser.j == 4)//보톰즈
        {
            this.audioK.Play();
        }
        if (Curser.i == 1 && Curser.j == 5)//심영
        {
            this.audioL.Play();
        }
    }
}
