using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour {
    public GameObject WarnPrefab;
    public int Mapd; // MapSpwon d 카운트
    public float set;//스타트문의 인보크땜시 늦쳐진 값을 고치는 수
    public int C;//lap값 고정
    // Use this for initialization
    void Start () {
        Mapd = 0;
        /*if (!(Curser.i == 0 && Curser.j == 1))
        {
            this.gameObject.SetActive(false);//루카스가 아니라면 작동안함
        }
        if (Curser.i == 0 && Curser.j == 1)
        {
            CheckMap();
        }*/
        set = 1;
        Invoke("Ready", 1f);//

    }

    public void Ready()
    {
        if (Curser.i == 0 && Curser.j == 1)
        {
            CheckMap();
        }
    }

    IEnumerator SpwonWarn()//고쳐라
    {
        Mapd = 0;
        C = MapSpwon.lap;
        while (Mapd < C)
        {
            yield return new WaitForSeconds(1.8f-set);
            set = 0;
            Instantiate(WarnPrefab, new Vector2(7.25f, 1.43f), Quaternion.identity);
            Mapd++;
            //set = 0;
        }
            CheckMap();
        yield return null;
    }

    IEnumerator SpwonWarn2()
    {
        Mapd = 0;
        C = MapSpwon.lap;
        while (Mapd < C)
        {
            yield return new WaitForSeconds(1f-set);
            Instantiate(WarnPrefab, new Vector2(7.25f, -2f), Quaternion.identity);//작은돌
            set = 0;
            yield return new WaitForSeconds(1.7f);
            Instantiate(WarnPrefab, new Vector2(7.25f, -1), Quaternion.identity);//큰돌
            yield return new WaitForSeconds(0.3f);// 뺀만큼 채우기
            Mapd++;
        }
        CheckMap();
        yield return null;
    }

    IEnumerator SpwonWarn3()//이상하다 갈수록 느려짐
    {
        Mapd = 0;
        yield return new WaitForSeconds(1f-set);
        set = 0;
        C = MapSpwon.lap;
        while (Mapd < C)
        {
            yield return new WaitForSeconds(0.6f);
            Instantiate(WarnPrefab, new Vector2(4.25f, 3f), Quaternion.identity);//떨어지는 종유석
            yield return new WaitForSeconds(0.4f);// 뺀만큼 채우기
            Mapd++;
        }
        yield return new WaitForSeconds(1f);
        CheckMap();
        yield return null;
    }

    IEnumerator SpwonWarn4()
    {
        Mapd = 0;
        yield return new WaitForSeconds(1f - set);
        set = 0;
        C = MapSpwon.lap;
        while (Mapd < C)
        {
            yield return new WaitForSeconds(0.5f);
            Instantiate(WarnPrefab, new Vector2(7.25f, -3f), Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
            Instantiate(WarnPrefab, new Vector2(7.25f, 4f), Quaternion.identity);
            //yield return new WaitForSeconds(0f);// 뺀만큼 채우기
            Mapd++;
        }
        yield return new WaitForSeconds(2);
        CheckMap();
        yield return null;
    }

    IEnumerator SpwonWarn5()//set값을 없앰
    {
        Mapd = 0;
        set = 0;
        yield return new WaitForSeconds(1f - set);//1f - set
        //set = 0.8f;
        C = MapSpwon.lap;
        while (Mapd < C)
        {
            yield return new WaitForSeconds(0.6f);
            Instantiate(WarnPrefab, new Vector2(7.25f, 3f), Quaternion.identity);
            yield return new WaitForSeconds(0.4f);// 뺀만큼 채우기
            Mapd++;
        }
        yield return new WaitForSeconds(2);
        CheckMap();
        //set = 0;
        yield return null;
    }

    IEnumerator SpwonWarn6()//?
    {
        Mapd = 0;
        
        set = 0;
        C = MapSpwon.lap;
        while (Mapd < C)
        {
            Instantiate(WarnPrefab, new Vector2(7.25f, -2f), Quaternion.identity);//작은돌
            yield return new WaitForSeconds(1f-set);
            set = 0;
            Instantiate(WarnPrefab, new Vector2(7.25f, 3), Quaternion.identity);//큰돌
            yield return new WaitForSeconds(1f);
            Instantiate(WarnPrefab, new Vector2(7.25f, -2f), Quaternion.identity);//작은돌
            //yield return new WaitForSeconds(2f);//1+1
            yield return new WaitForSeconds(3f);
            Instantiate(WarnPrefab, new Vector2(7.25f, 3), Quaternion.identity);//큰돌
            //Instantiate(WarnPrefab, new Vector2(7.25f, -1f), Quaternion.identity);//작은돌
            yield return new WaitForSeconds(3f);// 뺀만큼 채우기 1+2
            Mapd++;
        }
        //yield return new WaitForSeconds(2);
        CheckMap();
        yield return null;
    }

    IEnumerator SpwonWarn7()
    {
        Mapd = 0;
       // C = MapSpwon.lap;
        yield return new WaitForSeconds(1f - set);
        set = 0;
        Instantiate(WarnPrefab, new Vector2(7.25f, -2.4f), Quaternion.identity);//작은돌
        yield return new WaitForSeconds(2f);
        Instantiate(WarnPrefab, new Vector2(7.25f, 0.5f), Quaternion.identity);//큰돌
        yield return new WaitForSeconds(2f);
        Instantiate(WarnPrefab, new Vector2(7.25f, 3), Quaternion.identity);//큰돌
        yield return new WaitForSeconds(2);
        Instantiate(WarnPrefab, new Vector2(7.25f, 1.43f), Quaternion.identity);
        CheckMap();
        yield return null;
    }

    IEnumerator SpwonWarn8()
    {
        Mapd = 0;
        C = MapSpwon.lap;
        while (Mapd < C)
        {
            yield return new WaitForSeconds(1f-set);
            set = 0;
            Instantiate(WarnPrefab, new Vector2(7.25f, -1f), Quaternion.identity);
            yield return new WaitForSeconds(1f);
            Instantiate(WarnPrefab, new Vector2(7.25f, -2.5f), Quaternion.identity);
            yield return new WaitForSeconds(1f);
            Instantiate(WarnPrefab, new Vector2(7.25f, -2.5f), Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
            Instantiate(WarnPrefab, new Vector2(7.25f, -2.5f), Quaternion.identity);
            Instantiate(WarnPrefab, new Vector2(7.25f, 4f), Quaternion.identity);
            yield return new WaitForSeconds(1.5f);
            //yield return new WaitForSeconds(0f);// 뺀만큼 채우기
            Mapd++;
        }
        CheckMap();
        yield return null;
    }

    IEnumerator SpwonWarn9()
    {
        Mapd = 0;
        yield return new WaitForSeconds(1f - set);
        set = 0;
        C = MapSpwon.lap;
        while (Mapd < C)
        {
            yield return new WaitForSeconds(3f);
            //yield return new WaitForSeconds(0f);// 뺀만큼 채우기
            Mapd++;
        }
        CheckMap();
        yield return null;
    }

    IEnumerator SpwonWarn10()
    {
        Mapd = 0;
        yield return new WaitForSeconds(1f - set);
        set = 0;
        yield return new WaitForSeconds(1f);
        Instantiate(WarnPrefab, new Vector2(7.25f, -2.5f), Quaternion.identity);
        yield return new WaitForSeconds(0.7f);
        Instantiate(WarnPrefab, new Vector2(7.25f, -1.5f), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Instantiate(WarnPrefab, new Vector2(7.25f, -2.5f), Quaternion.identity);
        yield return new WaitForSeconds(1.3f);
        Instantiate(WarnPrefab, new Vector2(7.25f, -2.5f), Quaternion.identity);
        Instantiate(WarnPrefab, new Vector2(7.25f, 3f), Quaternion.identity);
        C = MapSpwon.lap;
        while (Mapd < C)
        {
            yield return new WaitForSeconds(1f);
            Instantiate(WarnPrefab, new Vector2(7.25f, 2f), Quaternion.identity);
            Mapd++;
        }
        CheckMap();
        yield return null;
    }

    IEnumerator SpwonWarn11()//후반에 싱크가 조금 안맞지만 상관없겠지
    {
        Mapd = 0;
        yield return new WaitForSeconds(1f - set);
        set = 0;
        Instantiate(WarnPrefab, new Vector2(7.25f, -2.5f), Quaternion.identity);
        yield return new WaitForSeconds(1.3f);
        Instantiate(WarnPrefab, new Vector2(7.25f, 1.43f), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Instantiate(WarnPrefab, new Vector2(7.25f, 1.43f), Quaternion.identity);
        yield return new WaitForSeconds(1.6f);
        Instantiate(WarnPrefab, new Vector2(7.25f, -2.5f), Quaternion.identity);
        yield return new WaitForSeconds(2.1f);//+7 +4
        Instantiate(WarnPrefab, new Vector2(7.25f, -1.15f), Quaternion.identity);//큰돌
        yield return new WaitForSeconds(0.8f);
        Instantiate(WarnPrefab, new Vector2(7.25f, 1.43f), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Instantiate(WarnPrefab, new Vector2(7.25f, -1.15f), Quaternion.identity);//큰돌
        yield return new WaitForSeconds(1f);
        Instantiate(WarnPrefab, new Vector2(7.25f, 1.43f), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Instantiate(WarnPrefab, new Vector2(7.25f, -1.15f), Quaternion.identity);//큰돌
        yield return new WaitForSeconds(1f);
        Instantiate(WarnPrefab, new Vector2(7.25f, 1.43f), Quaternion.identity);
        yield return new WaitForSeconds(0.8f);//?
        Instantiate(WarnPrefab, new Vector2(7.25f, -1.15f), Quaternion.identity);//큰돌
        yield return new WaitForSeconds(1.4f);
        CheckMap();
        yield return null;
    }

    public void CheckMap()
    {
        switch (MapSpwon.mapno)
        {
            /*case 0:
                break;*/
            case 1:
                StartCoroutine(SpwonWarn());
                break;
            case 2:
                StartCoroutine(SpwonWarn2());
                break;
            case 3:
                StartCoroutine(SpwonWarn3());
                break;
            case 4:
                StartCoroutine(SpwonWarn4());
                break;
            case 5:
                StartCoroutine(SpwonWarn5());
                break;
            case 6:
                StartCoroutine(SpwonWarn6());
                break;
            case 7:
                StartCoroutine(SpwonWarn7());
                break;
            case 8:
                StartCoroutine(SpwonWarn8());
                break;
            case 9:
                StartCoroutine(SpwonWarn9());
                break;
            case 10:
                StartCoroutine(SpwonWarn10());
                break;
            case 11:
                StartCoroutine(SpwonWarn11());
                break;
        }
    }
}
