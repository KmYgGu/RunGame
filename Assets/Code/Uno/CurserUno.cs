using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO.Ports;

public class CurserUno : Curser {
    public static SerialPort sp = new SerialPort("COM4", 9600); //문제가 생기면 RetryUno처럼 공유하기
    public bool Ok;

    void Start () {
        sp.Open();//시리얼통신 오픈
        //sp.ReadTimeout = 1;//아두이노 관련
        sp.ReadTimeout = 1;//1000에 1초
        audioA = this.gameObject.AddComponent<AudioSource>();
        audioA.clip = this.Choice;
        audioA.loop = false;
        Ok = true;//센서 받는 속도 제어
    }
	
	// Update is called once per frame
	void Update () {
        if (TitleControl.control == true)
        {
            UnoStart();
            //Spspeedset();
        }

    }

    void UnoStart()
    {
        if (sp.IsOpen)
        {
            try
            {
                ControlUno(sp.ReadByte());
                print(sp.ReadByte());
            }
            catch (System.Exception)
            {
                //sp.Close();
            }
        }
    }

    void ControlUno(int distance)
    {
        if (distance == 1) //첫번째 센서 커서 왼쪽으로 이동
        {
            if (j == 0 && i == 0)
            {
                i = 1;
                j = 5;
                transform.Translate(12.65f, -1.8f, 0);
                this.audioA.Play();
            }
            else if (j == 0 && i == 1)
            {
                i = 0;
                j = 5;
                transform.Translate(12.65f, 1.8f, 0);
                this.audioA.Play();
            }
            else
            {
                j--;
                transform.Translate(-2.53f, 0, 0);
                this.audioA.Play();
            }
        }
        if (distance == 2)//2번째 센서 커서 오른쪽으로 이동
        {
            if (j == 5 && i == 1)
            {
                i = 0;
                j = 0;
                transform.Translate(-12.65f, 1.8f, 0);
                this.audioA.Play();
            }
            else if (j == 5 && i == 0)
            {
                i = 1;
                j = 0;
                transform.Translate(-12.65f, -1.8f, 0);
                this.audioA.Play();
            }
            else
            {
                j++;
                transform.Translate(2.53f, 0, 0);
                this.audioA.Play();
            }

        }
        if ((distance == 3) && (!(Curser.i == 1 && Curser.j == 5)))//3번째 센서 커서 결정
        {
            //Ok = false;
            SceneManager.LoadScene("Play_Screen");
            //sp.Close();
        }
        if ((distance == 3) && (Curser.i == 1 && Curser.j == 5)) //무작위 캐릭터
        {
            //Ok = false;
            i = Random.Range(0, 2);
            j = Random.Range(0, 6);
            SceneManager.LoadScene("Play_Screen");
        }
    }

    void Spspeedset()
    {
        if (Ok == true)
        {
            //sp.Write("0");//느리게 가는 센서로 변경
            //sp.Write("A");//느리게 가는 센서로 변경
        }
    }
}
