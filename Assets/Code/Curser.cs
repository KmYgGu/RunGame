using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using System.IO.Ports;

public class Curser : MonoBehaviour {

    //SerialPort sp = new SerialPort("COM?", 9600); //?부분을 지우고 쓰고있는 컴퓨터에 해당하는 COM숫자를 넣기
    public static int i = 0;
    public static int j = 0;
    public AudioSource audioA;
    public AudioClip Choice;
    public int test;

    void Start () {
        test = 100;
        //sp.Open();//시리얼통신 오픈
        //sp.ReadTimeout = 1;//아두이노 관련
        this.audioA = this.gameObject.AddComponent<AudioSource>();
        this.audioA.clip = this.Choice;
        this.audioA.loop = false;

    }
	
	void Update () {
        if(TitleControl.control == false)
        {
            ControlKey();
        }
    }

    void ControlKey()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (i == 1)
            {
                i = 0;
                //this.gameObject.transform.position = new Vector3(0, -2.35f, 0);
                transform.Translate(0, 1.8f, 0);
                this.audioA.Play();
            }
            else
            {
                //i = CharArray.Length;
                i++;
                transform.Translate(0, -1.8f, 0);
                this.audioA.Play();
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (i == 0)
            {
                i = 1;
                //this.gameObject.transform.position = new Vector3(-6.62f, -4.35f, 0);
                transform.Translate(0, -1.8f, 0);
                this.audioA.Play();
            }
            else
            {
                i--;
                transform.Translate(0, 1.8f, 0);
                this.audioA.Play();
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (j == 5)
            {
                j = 0;
                //this.gameObject.transform.position = new Vector3(-6.62f, -2.35f, 0);
                transform.Translate(-12.65f, 0, 0);
                this.audioA.Play();
            }
            else
            {
                j++;
                transform.Translate(2.53f, 0, 0);//3
                this.audioA.Play();
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (j == 0)
            {
                j = 5;
                //this.gameObject.transform.position = new Vector3(8.38f, -2.35f, 0);
                transform.Translate(12.65f, 0, 0);
                this.audioA.Play();
            }
            else
            {
                j--;
                transform.Translate(-2.53f, 0, 0);
                this.audioA.Play();
            }
        }
        if (Input.GetKeyDown(KeyCode.Z)&&(!(Curser.i == 1 && Curser.j == 5)))
        {
            //System.GC.Collect(); //가비지 컬럭터 발동
            SceneManager.LoadScene("Play_Screen");
        }
        if (Input.GetKeyDown(KeyCode.Z) && (Curser.i == 1 && Curser.j == 5))
        {
            i = Random.Range(0, 2);
            j = Random.Range(0, 6);
            SceneManager.LoadScene("Play_Screen");
        }
    }

    /*void UnoStart()
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

            }
        }
    }*/

    /*void ControlUno(int distance)
    {
        if(distance == 1) //첫번째 센서 커서 왼쪽으로 이동
        {
            if (j == 0 && i == 0)
            {
                i = 1;
                j = 5;
                transform.Translate(15, -2, 0);
                this.audioA.Play();
            }
            else if (j == 0 && i == 1)
            {
                i = 0;
                j = 5;
                transform.Translate(15, 2, 0);
                this.audioA.Play();
            }
            else
            {
                j--;
                transform.Translate(-3, 0, 0);
                this.audioA.Play();
            }
        }
        if(distance == 2)//2번째 센서 커서 오른쪽으로 이동
        {
            if (j == 5 && i == 1)
            {
                i = 0;
                j = 0;
                transform.Translate(-15, 2, 0);
                this.audioA.Play();
            }
            else if (j == 5 && i == 0)
            {
                i = 1;
                j = 0;
                transform.Translate(-15, -2, 0);
                this.audioA.Play();
            }
            else
            {
                j++;
                transform.Translate(3, 0, 0);
                this.audioA.Play();
            }

        }
        if(distance == 3)//3번째 센서 커서 결정
        {
            SceneManager.LoadScene("Play_Screen");
        }
    }*/
}
