using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSelect : MonoBehaviour
{

   // public GameObject Target0;
    public GameObject Target1; //= GameObject.Find("John");
    public GameObject Target2;
    public GameObject Target3;
    public GameObject Target4;
    public GameObject Target5;
    public GameObject Target6;
    public GameObject Target7;
    public GameObject Target8;
    public GameObject Target9;
    public GameObject Target10;
    public GameObject Target11;
    public GameObject Target12;
    int Randomchar;

    // Use this for initialization
    void Start () {
        //Target0.SetActive(false);
        Target1.SetActive(false);
        Target2.SetActive(false);
        Target3.SetActive(false);
        Target4.SetActive(false);
        Target5.SetActive(false);
        Target6.SetActive(false);
        Target7.SetActive(false);
        Target8.SetActive(false);
        Target9.SetActive(false);
        Target10.SetActive(false);
        Target11.SetActive(false);
        Target12.SetActive(false);
        if (TitleControl.control == true)//초음파 컨트롤러 선택
        {
            Target1.GetComponent<Retry>().enabled = false;
            Target2.GetComponent<Retry>().enabled = false;
            Target3.GetComponent<Retry>().enabled = false;
            Target4.GetComponent<Retry>().enabled = false;
            Target5.GetComponent<Retry>().enabled = false;
            Target6.GetComponent<Retry>().enabled = false;
            Target7.GetComponent<Retry>().enabled = false;
            Target8.GetComponent<Retry>().enabled = false;
            Target9.GetComponent<Donald>().enabled = false;
            Target10.GetComponent<Retry>().enabled = false;
            Target11.GetComponent<Retry>().enabled = false;
            Target12.GetComponent<LV>().enabled = false;
            Target1.GetComponent<RetryUno>().enabled = true;
            Target2.GetComponent<RetryUno>().enabled = true;
            Target3.GetComponent<RetryUno>().enabled = true;
            Target4.GetComponent<RetryUno>().enabled = true;
            Target5.GetComponent<RetryUno>().enabled = true;
            Target6.GetComponent<RetryUno>().enabled = true;
            Target7.GetComponent<RetryUno>().enabled = true;
            Target8.GetComponent<RetryUno>().enabled = true;
            Target9.GetComponent<DonaldUno>().enabled = true;
            Target10.GetComponent<RetryUno>().enabled = true;
            Target11.GetComponent<RetryUno>().enabled = true;
            Target12.GetComponent<LVUno>().enabled = true;
        }
        if (TitleControl.control == false)//키보드로 조종
        {
            Target1.GetComponent<RetryUno>().enabled = false;
            Target2.GetComponent<RetryUno>().enabled = false;
            Target3.GetComponent<RetryUno>().enabled = false;
            Target4.GetComponent<RetryUno>().enabled = false;
            Target5.GetComponent<RetryUno>().enabled = false;
            Target6.GetComponent<RetryUno>().enabled = false;
            Target7.GetComponent<RetryUno>().enabled = false;
            Target8.GetComponent<RetryUno>().enabled = false;
            Target9.GetComponent<DonaldUno>().enabled = false;
            Target10.GetComponent<RetryUno>().enabled = false;
            Target11.GetComponent<RetryUno>().enabled = false;
            Target12.GetComponent<LVUno>().enabled = false;
            Target1.GetComponent<Retry>().enabled = true;
            Target2.GetComponent<Retry>().enabled = true;
            Target3.GetComponent<Retry>().enabled = true;
            Target4.GetComponent<Retry>().enabled = true;
            Target5.GetComponent<Retry>().enabled = true;
            Target6.GetComponent<Retry>().enabled = true;
            Target7.GetComponent<Retry>().enabled = true;
            Target8.GetComponent<Retry>().enabled = true;
            Target9.GetComponent<Donald>().enabled = true;
            Target10.GetComponent<Retry>().enabled = true;
            Target11.GetComponent<Retry>().enabled = true;
            Target12.GetComponent<LV>().enabled = true;
        }
        Randomchar = Random.Range(1, 13);

    }
	
	// Update is called once per frame
	void Update () {
        if(Curser.i == 0 && Curser.j == 0)//존
        {
            Target1.SetActive(true);
            Target1.tag = "Player";
        }
        if (Curser.i == 0 && Curser.j == 1)//루카스
        {
            Target2.SetActive(true);
            Target2.tag = "Player";
        }
        if (Curser.i == 0 && Curser.j == 2)//힙합보이
        {
            Target3.SetActive(true);
            Target3.tag = "Player";
        }
        if (Curser.i == 0 && Curser.j == 3)//몽키
        {
            Target4.SetActive(true);
            Target4.tag = "Player";
        }
        if (Curser.i == 0 && Curser.j == 4)//험버트
        {
            Target5.SetActive(true);
            Target5.tag = "Player";
        }
        if (Curser.i == 0 && Curser.j == 5)//태양맨
        {
            Target6.SetActive(true);
            Target6.tag = "Player";
        }
        if (Curser.i == 1 && Curser.j == 0)//테일러
        {
            Target7.SetActive(true);
            Target7.tag = "Player";
        }
        if (Curser.i == 1 && Curser.j == 1)//어쌔신
        {
            Target8.SetActive(true);
            Target8.tag = "Player";
        }
        if (Curser.i == 1 && Curser.j == 2)//도날드
        {
            Target9.SetActive(true);
            Target9.tag = "Player";
        }
        if (Curser.i == 1 && Curser.j == 3)//심영
        {
            Target10.SetActive(true);
            Target10.tag = "Player";
        }
        if (Curser.i == 1 && Curser.j == 4)//cp
        {
            Target11.SetActive(true);
            Target11.tag = "Player";
        }
        if (Curser.i == 1 && Curser.j == 5)//LV
        {
            Target12.SetActive(true);
            Target12.tag = "Player";
            //Randomchar = Random.Range(1, 13);
            /*switch (Randomchar)
            {
                case 1:
                    Curser.i = 0;
                    Curser.j = 0;
                    //Target1.SetActive(true);
                    //Target1.tag = "Player";
                    break;
                case 2:
                    Curser.i = 0;
                    Curser.j = 1;
                    //Target2.SetActive(true);
                    //Target2.tag = "Player";
                    break;
                case 3:
                    Curser.i = 0;
                    Curser.j = 2;
                    //Target3.SetActive(true);
                    //Target3.tag = "Player";
                    break;
                case 4:
                    Curser.i = 0;
                    Curser.j = 3;
                    //Target4.SetActive(true);
                    //Target4.tag = "Player";
                    break;
                case 5:
                    Curser.i = 0;
                    Curser.j = 4;
                    //Target5.SetActive(true);
                    //Target5.tag = "Player";
                    break;
                case 6:
                    Curser.i = 0;
                    Curser.j = 5;
                    //Target6.SetActive(true);
                    //Target6.tag = "Player";
                    break;
                case 7:
                    Target7.SetActive(true);
                    Target7.tag = "Player";
                    break;
                case 8:
                    Target8.SetActive(true);
                    Target8.tag = "Player";
                    break;
                case 9:
                    Target9.SetActive(true);
                    Target9.tag = "Player";
                    break;
                case 10:
                    Target10.SetActive(true);
                    Target10.tag = "Player";
                    break;
                case 11:
                    Target11.SetActive(true);
                    Target11.tag = "Player";
                    break;
                case 12:
                    Target12.SetActive(true);
                    Target12.tag = "Player";
                    break;
            }*/
        }
    }
}
