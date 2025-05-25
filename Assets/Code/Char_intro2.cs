using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Char_intro2 : MonoBehaviour {

    public int charnumber = 0;
    public SpriteRenderer Charno;
    public Sprite[] sprites = new Sprite[12];

	// Use this for initialization
	void Start () {
        Charno = GetComponent<SpriteRenderer>();
        Charno.sprite = sprites[0];
	}
	
	// Update is called once per frame
	void Update () {
        if (Curser.i == 0 && Curser.j == 0)//존&& (RetryChar.Eaten == false)
        {
            charnumber = 0;
            gameObject.GetComponent<Image>();
            Charno.sprite = sprites[charnumber];
        }
        if (Curser.i == 0 && Curser.j == 1)//루카스
        {
            charnumber = 1;
            gameObject.GetComponent<Image>();
            Charno.sprite = sprites[charnumber];
        }
        if (Curser.i == 0 && Curser.j == 2)//힙합보이
        {
            charnumber = 2;
            //gameObject.GetComponent<Image>().sprite = sprites[charnumber];
            gameObject.GetComponent<Image>();
            Charno.sprite = sprites[charnumber];
        }
        if (Curser.i == 0 && Curser.j == 3)//몽키
        {
            charnumber = 3;
            gameObject.GetComponent<Image>();
            Charno.sprite = sprites[charnumber];
        }
        if (Curser.i == 0 && Curser.j == 4)//험버트
        {
            charnumber = 4;
            gameObject.GetComponent<Image>();
            Charno.sprite = sprites[charnumber];
        }
        if (Curser.i == 0 && Curser.j == 5)//태양맨
        {
            charnumber = 5;
            gameObject.GetComponent<Image>();
            Charno.sprite = sprites[charnumber];
        }
        if (Curser.i == 1 && Curser.j == 0)//테일러
        {
            charnumber = 6;
            gameObject.GetComponent<Image>();
            Charno.sprite = sprites[charnumber];
        }
        if (Curser.i == 1 && Curser.j == 1)//어쌔신
        {
            charnumber = 7;
            gameObject.GetComponent<Image>();
            Charno.sprite = sprites[charnumber];
        }
        if (Curser.i == 1 && Curser.j == 2)//도날드
        {
            charnumber = 8;
            gameObject.GetComponent<Image>();
            Charno.sprite = sprites[charnumber];
        }
        if (Curser.i == 1 && Curser.j == 3)//심영
        {
            charnumber = 9;
            gameObject.GetComponent<Image>();
            Charno.sprite = sprites[charnumber];
        }
        if (Curser.i == 1 && Curser.j == 4)//보톰즈
        {
            charnumber = 10;
            gameObject.GetComponent<Image>();
            Charno.sprite = sprites[charnumber];
        }
        if (Curser.i == 1 && Curser.j == 5)
        {
            charnumber = 11;
            gameObject.GetComponent<Image>();
            Charno.sprite = sprites[charnumber];
        }
        if (Curser.i == 0 && Curser.j == 0 && (RetryChar.Eaten == true))//존
        {
            charnumber = 12;
            gameObject.GetComponent<Image>();
            Charno.sprite = sprites[charnumber];
        }
        if (Curser.i == 0 && Curser.j == 1 && (RetryChar.Eaten == true))//루카스
        {
            charnumber = 13;
            gameObject.GetComponent<Image>();
            Charno.sprite = sprites[charnumber];
        }
        if (Curser.i == 0 && Curser.j == 2 && (RetryChar.Eaten == true))//힙합보이
        {
            charnumber = 14;
            gameObject.GetComponent<Image>();
            Charno.sprite = sprites[charnumber];
        }
        if (Curser.i == 0 && Curser.j == 3 && (RetryChar.Eaten == true))//몽키
        {
            charnumber = 15;
            gameObject.GetComponent<Image>();
            Charno.sprite = sprites[charnumber];
        }
        if (Curser.i == 0 && Curser.j == 4 && (RetryChar.Eaten == true))//험버트
        {
            charnumber = 16;
            gameObject.GetComponent<Image>();
            Charno.sprite = sprites[charnumber];
        }
        if (Curser.i == 0 && Curser.j == 5 && (RetryChar.Eaten == true))//태양맨
        {
            charnumber = 17;
            gameObject.GetComponent<Image>();
            Charno.sprite = sprites[charnumber];
        }
        if (Curser.i == 1 && Curser.j == 0 && (RetryChar.Eaten == true))//테일러
        {
            charnumber = 18;
            gameObject.GetComponent<Image>();
            Charno.sprite = sprites[charnumber];
        }
        if (Curser.i == 1 && Curser.j == 1 && (RetryChar.Eaten == true))//어쌔신
        {
            charnumber = 19;
            gameObject.GetComponent<Image>();
            Charno.sprite = sprites[charnumber];
        }
        if (Curser.i == 1 && Curser.j == 2 && (RetryChar.Eaten == true))//도날드
        {
            charnumber = 20;
            gameObject.GetComponent<Image>();
            Charno.sprite = sprites[charnumber];
        }
        if (Curser.i == 1 && Curser.j == 3 && (RetryChar.Eaten == true))//심영
        {
            charnumber = 21;
            gameObject.GetComponent<Image>();
            Charno.sprite = sprites[charnumber];
        }
        if (Curser.i == 1 && Curser.j == 4 && (RetryChar.Eaten == true))//보톰즈
        {
            charnumber = 22;
            gameObject.GetComponent<Image>();
            Charno.sprite = sprites[charnumber];
        }
    }
}
