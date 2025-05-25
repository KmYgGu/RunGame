using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleControl : MonoBehaviour {
    //public GameObject Cus;
    public static bool control = false;
    // Use this for initialization

    public void ControlYes()//초음파 컨트롤러 선택
    {
        control = true;
        RetryChar.Eaten = false;
        SceneManager.LoadScene("CharSelect");
        Curser.i = 0;//커서값 초기화
        Curser.j = 0;
        //Cus = GameObject.Find("Curser_EX");
        //Cus.GetComponent<CurserUno>().enabled = true;
        //Cus.GetComponent<Curser>().enabled = false;
    }

    public void ControlNo()// 키보드로 조종하기
    {
        control = false;
        RetryChar.Eaten = false;
        SceneManager.LoadScene("CharSelect");
        Curser.i = 0;//커서값 초기화
        Curser.j = 0;
        //Cus = GameObject.Find("Curser_EX");
        //Cus.GetComponent<Curser>().enabled = true;
        //Cus.GetComponent<CurserUno>().enabled = false;

    }
    /*public void TitleGo()// 타이틀로 돌아가기
    {
        SceneManager.LoadScene("TitleScene");
        Score_Manager.score = 0;//점수 초기화
        MapMove.speedselect = -1f; //맵속도 초기화
        Curser.i = 0;//커서값 초기화
        Curser.j = 0;
    }*/
}
