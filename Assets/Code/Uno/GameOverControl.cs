using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO.Ports;

public class GameOverControl : MonoBehaviour {

    public void TitleGo()// 타이틀로 돌아가기
    {
        SceneManager.LoadScene("TitleScene");
        Score_Manager.score = 0;//점수 초기화
        MapMove.speedselect = -1f; //맵속도 초기화
        CurserUno.sp.Write("0");
        CurserUno.sp.Close();//커서우노 닫기
        //Curser.i = 0;//커서값 초기화
        //Curser.j = 0;
        //Invoke("CurserSet", 0.5f);
    }

    /*public void CurserSet()//타이틀로 되돌아갈 때 캐릭터 변경되는거 못느끼게 하기
    {
        Curser.i = 0;//커서값 초기화
        Curser.j = 0;
    }*/
}
