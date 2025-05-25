using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkTurn : MonoBehaviour {
    SpriteRenderer Dark;
    public static float Count;
    public GameObject Light;
    public bool hit;
    public static float test;//다크의 알파값을 확인하는 용도 험버트
    float HJohnup;



    // Use this for initialization
    void Start () {
        this.Dark = GetComponent<SpriteRenderer>();
        hit = false;
        JohnAbil2();

        /*Color color = Dark.color; //컬러는 다크 컬러
        color.a = 0.3f; 
        Count = color.a;
        Dark.color = color;*/
        if (Curser.i == 0 && Curser.j == 5)//태양맨일 경우 어둡게 시작
        {
            Color color = Dark.color;
            color.a = 0.93f;
            Count = color.a;
            Dark.color = color;
            Light.transform.localScale -= new Vector3(DarkTurn.Count+1, DarkTurn.Count+1, 0);// * Time.deltaTime;
        }
        else
        {
            Color color = Dark.color; //컬러는 다크 컬러
            color.a = 0.3f; 
            Count = color.a;
            Dark.color = color;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if(RetryChar.heal == true)//회복
        {
            Color color = Dark.color;//맞나?
            color.a -= 0.35f+ HJohnup;//0.27
            Count = color.a * 0.5f;//1.5f
            Dark.color = color;
            Light.transform.localScale += new Vector3(DarkTurn.Count+0.5f+ HJohnup, DarkTurn.Count + 0.5f+HJohnup, 0);
            RetryChar.heal = false;
            test = color.a;
        }
        if(Retry.SoliaHeal == true || RetryUno.UnoSoliaHeal == true)//태양맨 능력
        {
            Retry.SoliaHeal = false;
            //RetryUno.UnoSoliaHeal = false;
            Invoke("SoliaStop", 0.025f);//0.05
            Color color = Dark.color;//맞나?
            color.a -= 0.035f;//0.07
            Count = color.a * 0.5f;//1.5f
            Dark.color = color;
            Light.transform.localScale += new Vector3(DarkTurn.Count-0.15f, DarkTurn.Count-0.15f, 0);//-0.1
            test = color.a;

        }
        if(Dark.color.a >= 0.93f && hit == false && !(Curser.i == 1 && Curser.j == 1))//어쌔신을 제외한 모든이
        {
            Color color = Dark.color;
            color.a = 0.93f;
            Count = color.a;
            Dark.color = color;
            hit = true;
            Invoke("OuchSet", 1f);//0.6초->1초
            test = color.a;
        }
        if (Dark.color.a >= 0.8f && hit == false && (Curser.i == 1 && Curser.j == 1))//어쌔신 능력
        {
            Color color = Dark.color;
            color.a = 0.8f;
            Count = color.a;
            Dark.color = color;
            hit = true;
            Invoke("OuchSet", 1f);//0.6초->1초
            test = color.a;
        }
        else if (Dark.color.a < 0.93f && hit == false)
        {
            Color color = Dark.color;//천천히 감소하는 코드
                                     //color.a += 0.01f * Time.deltaTime;
            color.a += 0.03f * Time.deltaTime;
            Count = color.a * 0.2f;
            Dark.color = color;
            Light.transform.localScale -= new Vector3(DarkTurn.Count, DarkTurn.Count, 0) * Time.deltaTime;
            test = color.a;
            if (RetryChar.Ouch == true && hit == false)//부딪혔을때
            {
                /*color.a += 0.09f;
                Count = color.a * 0.5f;//0.6
                Dark.color = color;
                hit = true;
                Invoke("OuchSet", 1f);
                test = color.a;
                Light.transform.localScale -= new Vector3(DarkTurn.Count, DarkTurn.Count, 0);*/
                if ((Curser.i == 1 && Curser.j == 0) && RetryChar.TShlied == true) //테일러이고 쉴드가 있을때
                {
                    /*color.a += 0.045f;
                    Count = color.a * 0.25f;//0.3f 2)0.35
                    Dark.color = color;*/
                    hit = true;
                    Invoke("OuchSet", 1f);
                    /*if (Light.transform.localScale.x > 0.6)
                        Light.transform.localScale -= new Vector3(DarkTurn.Count, DarkTurn.Count, 0);*/
                }
                else
                {
                    //Color color = Dark.color;
                    //color.a += 0.01f * Time.deltaTime;
                    color.a += 0.09f;
                    Count = color.a * 0.5f;//0.6
                    Dark.color = color;
                    hit = true;
                    Invoke("OuchSet", 1f);
                    test = color.a;
                    Light.transform.localScale -= new Vector3(DarkTurn.Count, DarkTurn.Count, 0);
                    /*if (Light.transform.localScale.x < 0.6)
                        Light.transform.localScale = new Vector3(0.6f, 0.6f, 0);*/
                }
            }
            if (Light.transform.localScale.x < 0.6)//크기가 너무 작을경우 복구
                Light.transform.localScale = new Vector3(0.6f, 0.6f, 0);
        }
	}

    public void OuchSet()
    {
        RetryChar.Ouch = false;
        hit = false;
    }

    public void JohnAbil2()
    {
        if (Curser.i == 0 && Curser.j == 0)//존
        {
            HJohnup = 0.15f;
        }
        if (!(Curser.i == 0 && Curser.j == 0))//존이 아님
        {
            HJohnup = 0;
        }

    }

    public void SoliaStop()
    {
        RetryUno.UnoSoliaHeal = false;
    }
}
