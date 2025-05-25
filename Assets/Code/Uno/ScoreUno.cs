using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class ScoreUno : MonoBehaviour {
    //SerialPort sp = new SerialPort("COM5", 9600); //?부분을 지우고 쓰고있는 컴퓨터에 해당하는 COM숫자를 넣기
    SerialPort sp = CurserUno.sp;
    void Start () {
        //sp.Open();
        //sp.ReadTimeout = 1;
    }

	void Update () {
        sp.Write("9");
        if (sp.IsOpen)
        {
            if(Score_Manager.score >= 500) //점수가 500점 이상, 1000점 미만
            {
                sp.Write("1");
                //print(1);
            }
            if (Score_Manager.score >= 1000) //점수가 1000점 이상이지만... 반응이 느려서 -400시킴
            {
                sp.Write("2");
                //print(2);
            }
            if (Score_Manager.score >= 3000) //점수가 3000점 이상
            {
                sp.Write("3");
                //print(3);
            }
            if (Score_Manager.score >= 5000) //점수가 5000점 이상
            {
                sp.Write("4");
                //print(3);
            }
            if (Score_Manager.score >= 10000) //점수가 10000점 이상
            {
                sp.Write("5");
            }
            if (Score_Manager.score >= 15000) //점수가 15000점 이상
            {
                sp.Write("6");
            }
            if (Score_Manager.score >= 30000) //점수가 30000점 이상
            {
                sp.Write("7");
            }
            if (Score_Manager.score >= 50000) //점수가 50000점 이상
            {
                sp.Write("8");
            }
        }
        //sp.Write("9");//빨리 가는 센서로 변경
        //sp.Write("B");//빨리 가는 센서로 변경
    }
}
