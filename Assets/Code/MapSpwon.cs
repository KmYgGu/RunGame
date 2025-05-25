using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpwon : MonoBehaviour {

    public GameObject GroundPrefab;//프리펩 땅
    public GameObject YGroundPrefab;//세로 땅
    public GameObject stalPrefab;//프리펩 종유석
    public GameObject sRockPrefab;//작은 바위
    public GameObject bRockPrefab;//큰 바위
    public GameObject FallstalPrefab;//떨어지는 종유석
    public GameObject FootPrefab;//발판
    public GameObject CTFootPrefab;//통과안되는발판
    public GameObject ZGroundPrefab;//대각선 땅
    public GameObject Z2GroundPrefab;//대각선 땅 수정판
    public GameObject Hpup;//횃불회복 아이템
    public GameObject CoinPrefab;//코인
    public GameObject StickPrefab;//테일러 마술봉

    float[] a = { 1.8f , 1f };//다른캐릭터들 맵스폰속도
    float[] b = { 1.35f , 0.75f };//힙합보이 맵스폰속도
    float c;
    public int d;//횟수
    public int e;//속도
    public static int lap;//반복 제한
    public static int mapno;//다른코드에게 알려주는 맵스폰번호
    public int map;
    float Sp5Y; // 패턴 5 Y축 줄이게 하는 변수

    // Use this for initialization
    void Start () {
        d = 0; // 반복횟수
        //e = 0; // 속도
        e = 1;
        lap = 0;
        mapno = 0;
        //StartCoroutine(Spwon2());
        //StartCoroutine(Spwon10());
        Randommap();
        CheckSpeed();
        if (Curser.i == 1 && Curser.j == 0)// 테일러일 경우
        {
            StickPrefab.SetActive(true);
        }
        if (!(Curser.i == 1 && Curser.j == 0))// 테일러가 아닐 경우
        {
            StickPrefab.SetActive(false);
        }
    }

    IEnumerator Spwon1()//절벽,종유석패턴 + 무작위 +코인  +마
    {
 
        d = 0;//횟수
        e = 0;//속도
        mapno = 1;
        lap = Random.Range(2, 4);
        while ( d < lap)//2~3 무작위
        {
            yield return new WaitForSeconds(c);
            Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);
            Instantiate(stalPrefab, new Vector2(18.26f, 1.52f), Quaternion.identity);
            //Instantiate(CoinPrefab, new Vector2(18.26f, -1.8f), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector2(21.26f, -1.8f), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector2(24.26f, -0.8f), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector2(27.26f, 0.8f), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector2(30.26f, 0.8f), Quaternion.identity);
            d++;
            //StartCoroutine(SpwonGrounds());
        }
        //e++;
        Instantiate(StickPrefab, new Vector2(24.26f, 0.8f), Quaternion.identity);
        //StartCoroutine(Spwon1());
        Randommap();
        CheckSpeed();
        yield return null;
    }

    IEnumerator Spwon2()//작은바위큰바위패턴 + 무작위 + 코인 +마
    {
 
        d = 0;//횟수
        e = 1;//속도
        mapno = 2;
        lap = Random.Range(1, 5);
        while (d < lap)//1~4무작위 + 코인
        {
            yield return new WaitForSeconds(c);
            Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);
            Instantiate(sRockPrefab, new Vector2(20.26f, -2.78f), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector2(16.26f, 0.8f), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector2(19.26f, 0.8f), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector2(22.26f, 0.8f), Quaternion.identity);
            yield return new WaitForSeconds(c);
            Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector2(18.26f, -0.2f), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector2(21.26f, 0.2f), Quaternion.identity);
            yield return new WaitForSeconds(c);
            Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);
            Instantiate(bRockPrefab, new Vector2(16.26f, -2.1f), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector2(12.26f, 1.8f), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector2(15.26f, 2.8f), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector2(18.26f, 2.8f), Quaternion.identity);
            d++;
        }
        Instantiate(StickPrefab, new Vector2(24.26f, 0.8f), Quaternion.identity);
        //StartCoroutine(Spwon2());
        Randommap();
        CheckSpeed();
        yield return null;
    }

    IEnumerator Spwon3()//떨어지는 종유석패턴 + 무작위 + 코인 + 회복
    {
        d = 0;//횟수
        e = 1;//속도
        mapno = 3;
        lap = Random.Range(5, 8); // 이 부분 때문에 루카스 오류 나는거 같은데.
        yield return new WaitForSeconds(c);
        Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);//20.26
        //lap = Random.Range(5, 8);
        while (d < lap)//4~7 무작위
        {
            yield return new WaitForSeconds(c);
            Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector2(15.26f, -1.8f), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector2(18.26f, -1.8f), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector2(21.26f, -1.8f), Quaternion.identity);
            //Instantiate(FallstalPrefab, new Vector2(18.26f, 1.52f), Quaternion.identity);
            Instantiate(FallstalPrefab, new Vector2(13.7f, 3.56f), Quaternion.identity);
            d++;
        }
        yield return new WaitForSeconds(c);
        //Instantiate(StickPrefab, new Vector2(24.26f, 0.8f), Quaternion.identity);
        Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);
        Instantiate(Hpup, new Vector2(21f, 1.36f), Quaternion.identity);
        //StartCoroutine(Spwon3());
        Randommap();
        CheckSpeed();
        yield return null;
    }

    IEnumerator Spwon4()//좋은 2층패턴   //무작위 + 코인 + 회복 +마
    {
        d = 0;//횟수
        e = 1;//속도
        mapno = 4;
        //Instantiate(GroundPrefab, new Vector2(18.26f, -2.23f), Quaternion.identity);
        lap = Random.Range(7, 11);
        yield return new WaitForSeconds(c);
        Instantiate(FootPrefab, new Vector2(16.26f, 0.5f), Quaternion.identity);
        Instantiate(GroundPrefab, new Vector2(18.26f, -5.45f), Quaternion.identity);
        //lap = Random.Range(7, 11);
        while (d < lap)//7에서 10까지 무작위 반복
        {
            yield return new WaitForSeconds(c);
            Instantiate(GroundPrefab, new Vector2(18.26f, -5.45f), Quaternion.identity);
            Instantiate(CTFootPrefab, new Vector2(26.26f, 1.55f), Quaternion.identity);//1.45
            Instantiate(sRockPrefab, new Vector2(28.26f, 2.68f), Quaternion.identity);//위층
            Instantiate(sRockPrefab, new Vector2(23.26f, -4f), Quaternion.identity);//16.26, 아래층
            Instantiate(CoinPrefab, new Vector2(18.26f, -1.8f), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector2(16.26f, 4.8f), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector2(20.26f, 4.8f), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector2(23.26f, 4.8f), Quaternion.identity);
            d++;
        }
        yield return new WaitForSeconds(c);
        Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);
        yield return new WaitForSeconds(c);
        Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);
        Instantiate(Hpup, new Vector2(13f, 3.9f), Quaternion.identity);
        Instantiate(StickPrefab, new Vector2(12.26f, -0.8f), Quaternion.identity);
        //StartCoroutine(Spwon4());
        Randommap();
        CheckSpeed();
        yield return null;
    }

    IEnumerator Spwon5()//미끄럼틀 패턴 + 코인 - 회복제거 +마
    {
        d = 0;//횟수
        e = 1;//속도
        mapno = 5;
        Sp5Y = 0;// Y축 줄이게하는 변수
        lap = 6;
        yield return new WaitForSeconds(c);
        Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);
        //Instantiate(Hpup, new Vector2(18f, 0f), Quaternion.identity);
        yield return new WaitForSeconds(c);
        Instantiate(YGroundPrefab, new Vector2(17.26f, -2.53f), Quaternion.identity);
        Instantiate(CoinPrefab, new Vector2(15.26f, -1.8f), Quaternion.identity);
        Instantiate(CoinPrefab, new Vector2(15.26f, -0.3f), Quaternion.identity);
        Instantiate(CoinPrefab, new Vector2(15.26f, 1.2f), Quaternion.identity);
        Instantiate(CoinPrefab, new Vector2(15.26f, 2.7f), Quaternion.identity);
        Instantiate(CoinPrefab, new Vector2(15.26f, 2.7f), Quaternion.identity);
        Instantiate(CoinPrefab, new Vector2(17.26f, 2.7f), Quaternion.identity);
        Instantiate(StickPrefab, new Vector2(15.26f, -2.8f), Quaternion.identity);
        //lap = 6;
        while (d < lap)
        {
            yield return new WaitForSeconds(c);
            Instantiate(FootPrefab, new Vector2(14f, 1f- Sp5Y), Quaternion.identity);
            Instantiate(stalPrefab, new Vector2(15.7f, 7f-Sp5Y), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector2(19.26f, 2.7f - Sp5Y), Quaternion.identity);
            Sp5Y += 1;
            d++;
        }
        //StartCoroutine(Spwon5());
        Randommap();
        CheckSpeed();
        yield return null;
    }

    IEnumerator Spwon6()//1층,2층 바위패턴 + 무작위 + 코인 -회복제거 + 마
    {
        d = 0;//횟수
        e = 1;//속도
        mapno = 6;
        lap = Random.Range(1, 3);
        while (d < lap)//1~2번중 무작위로 반복
        {
            yield return new WaitForSeconds(c);
            Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);
            Instantiate(FootPrefab, new Vector2(18.26f, 0.5f), Quaternion.identity);
            Instantiate(sRockPrefab, new Vector2(18.26f, -2.78f), Quaternion.identity);
            yield return new WaitForSeconds(c);
            Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector2(18.26f, 0.8f), Quaternion.identity);
            yield return new WaitForSeconds(c);
            Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);
            Instantiate(FootPrefab, new Vector2(18.26f, 0.5f), Quaternion.identity);
            Instantiate(bRockPrefab, new Vector2(18.26f, 2.38f), Quaternion.identity);//작은돌은 1.78f
            yield return new WaitForSeconds(c);
            Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);
            Instantiate(sRockPrefab, new Vector2(18.26f, -2.78f), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector2(18.26f, 0.8f), Quaternion.identity);
            yield return new WaitForSeconds(c);
            Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);
            Instantiate(StickPrefab, new Vector2(18.26f, 2.8f), Quaternion.identity);
            Instantiate(FootPrefab, new Vector2(18.26f, 0.5f), Quaternion.identity);
            yield return new WaitForSeconds(c);
            Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector2(18.26f, 0.8f), Quaternion.identity);
            yield return new WaitForSeconds(c);
            Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);
            Instantiate(FootPrefab, new Vector2(18.26f, 0.5f), Quaternion.identity);
            Instantiate(bRockPrefab, new Vector2(18.26f, 2.38f), Quaternion.identity);
            yield return new WaitForSeconds(c);
            Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);
            //Instantiate(Hpup, new Vector2(18.26f, 0.8f), Quaternion.identity);
            d++;
        }
        //StartCoroutine(Spwon6());
        Randommap();
        CheckSpeed();
        yield return null;
    }

    IEnumerator Spwon7()//함정패턴 + 무작위 + 코인 + 마
    {
        d = 0;//횟수
        e = 1;//속도
        mapno = 7;
        //while (d < Random.Range(1, 3))//1번으로 끝낼지 2번 반복할지 무작위
        yield return new WaitForSeconds(c);
            Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);
            Instantiate(FootPrefab, new Vector2(18.26f, 0.1f), Quaternion.identity);//0.5f
            Instantiate(sRockPrefab, new Vector2(18.26f, -2.78f), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector2(15.26f, 2f), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector2(18.26f, 2f), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector2(21.26f, 2f), Quaternion.identity);
            yield return new WaitForSeconds(c);
            Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);
            yield return new WaitForSeconds(c);
            Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);
            Instantiate(CTFootPrefab, new Vector2(18.26f, 2.5f), Quaternion.identity);
            Instantiate(CTFootPrefab, new Vector2(18.26f, -2.65f), Quaternion.identity);//1.45
            Instantiate(bRockPrefab, new Vector2(18.26f, -0.75f), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector2(18.26f, 4.8f), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector2(21.26f, 4.8f), Quaternion.identity);
            Instantiate(StickPrefab, new Vector2(22.26f, 0.3f), Quaternion.identity);
            yield return new WaitForSeconds(c);
            Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);
            yield return new WaitForSeconds(c);
            Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);
            Instantiate(FootPrefab, new Vector2(22.26f, 0.5f), Quaternion.identity);
            Instantiate(bRockPrefab, new Vector2(20.26f, 2.38f), Quaternion.identity);
            Instantiate(bRockPrefab, new Vector2(22.26f, 2.38f), Quaternion.identity);
            Instantiate(bRockPrefab, new Vector2(24.26f, 2.38f), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector2(21.26f, -1.8f), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector2(24.26f, -1.8f), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector2(27.26f, -1.8f), Quaternion.identity);
            yield return new WaitForSeconds(c);
            Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);
            yield return new WaitForSeconds(c);
            Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);
            Instantiate(stalPrefab, new Vector2(16.26f, 1.52f), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector2(13.26f, -2), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector2(16.26f, -2.5f), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector2(19.26f, -2), Quaternion.identity);

            d++;
        //StartCoroutine(Spwon7());
        Randommap();
        CheckSpeed();
        yield return null;
    }

    IEnumerator Spwon8()//1단점프 요구패턴 + 무작위 + 코인
    {
        d = 0;//횟수
        e = 1;//속도
        mapno = 8;
        lap = Random.Range(1, 3);
        while (d < lap)//1에서 2 무작위
        {
            yield return new WaitForSeconds(c);
            Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);
            Instantiate(sRockPrefab, new Vector2(20.26f, -2.78f), Quaternion.identity);
            Instantiate(bRockPrefab, new Vector2(21.26f, -2f), Quaternion.identity);
            Instantiate(sRockPrefab, new Vector2(22.26f, -2.78f), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector2(15.26f, -1.8f), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector2(18.26f, -0.3f), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector2(21.26f, 1.2f), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector2(24.26f, -0.3f), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector2(27.26f, -1.8f), Quaternion.identity);
            yield return new WaitForSeconds(c);
            Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);
            Instantiate(sRockPrefab, new Vector2(22.26f, -2.78f), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector2(22.26f, -0.3f), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector2(25.26f, -1.3f), Quaternion.identity);
            //Instantiate(sRockPrefab, new Vector2(25.26f, -2.78f), Quaternion.identity);
            yield return new WaitForSeconds(c);
            Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);
            Instantiate(sRockPrefab, new Vector2(22.26f, -2.78f), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector2(19.26f, -1.3f), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector2(22.26f, -0.3f), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector2(26.26f, -1f), Quaternion.identity);
            yield return new WaitForSeconds(c);
            Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);
            Instantiate(sRockPrefab, new Vector2(20.26f, -2.78f), Quaternion.identity);
            Instantiate(stalPrefab, new Vector2(20.26f, 5.52f), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector2(20.26f, -0.3f), Quaternion.identity);
            yield return new WaitForSeconds(c);
            Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);
            d++;
        }
        //StartCoroutine(Spwon8());
        Randommap();
        CheckSpeed();
        yield return null;
    }

    IEnumerator Spwon9()//등산맵 + 무작위 + 코인 + 회복 + 마
    {
        d = 0;//횟수
        e = 1;//속도
        mapno = 9;
        lap = Random.Range(1, 3);
        yield return new WaitForSeconds(c);
        Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);
        //lap = Random.Range(1, 3);
        while ( d < lap)//1에서 2무작위
        {
            yield return new WaitForSeconds(c);
            Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector2(13.26f, -1.8f), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector2(15.26f, -0.8f), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector2(17.26f, 0.8f), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector2(19.26f, 1.8f), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector2(21.26f, 2.8f), Quaternion.identity);
            //Instantiate(ZGroundPrefab, new Vector2(18.26f, -4.04f), Quaternion.identity);
            //Instantiate(ZGroundPrefab, new Vector2(25.78f, 0.28f), Quaternion.identity);
            Instantiate(Z2GroundPrefab, new Vector2(18.26f, -1.67f), Quaternion.identity);
            yield return new WaitForSeconds(c);
            Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector2(18.26f, 3.8f), Quaternion.identity);
            //Instantiate(Hpup, new Vector2(21f, 3.8f), Quaternion.identity);
            yield return new WaitForSeconds(c);
            Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);
            d++;
        }
        Instantiate(StickPrefab, new Vector2(11.26f, -2.8f), Quaternion.identity);
        Instantiate(Hpup, new Vector2(11f, 3.8f), Quaternion.identity);
        //StartCoroutine(Spwon9());
        Randommap();
        CheckSpeed();
        yield return null;

    }

    IEnumerator Spwon10()//종유석 입구 + 코인
    {
        d = 0;//횟수
        e = 1;//속도
        mapno = 10;
        lap = Random.Range(4, 7);
        yield return new WaitForSeconds(c);
        Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);
        Instantiate(CoinPrefab, new Vector2(15.26f, -1.8f), Quaternion.identity);
        Instantiate(CoinPrefab, new Vector2(18.26f, -1.8f), Quaternion.identity);
        Instantiate(CoinPrefab, new Vector2(21.26f, -1.8f), Quaternion.identity);
        Instantiate(CoinPrefab, new Vector2(24.26f, -0.3f), Quaternion.identity);
        yield return new WaitForSeconds(c);
        Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);
        Instantiate(sRockPrefab, new Vector2(17.26f, -2.78f), Quaternion.identity);
        Instantiate(CoinPrefab, new Vector2(17.26f, 1f), Quaternion.identity);
        Instantiate(CoinPrefab, new Vector2(20.26f, -1f), Quaternion.identity);
        yield return new WaitForSeconds(c);
        Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);
        Instantiate(bRockPrefab, new Vector2(16.26f, -2.1f), Quaternion.identity);
        Instantiate(bRockPrefab, new Vector2(18.26f, -2.1f), Quaternion.identity);
        Instantiate(CoinPrefab, new Vector2(15.26f, 2.5f), Quaternion.identity);
        Instantiate(CoinPrefab, new Vector2(17.26f, 2.5f), Quaternion.identity);
        Instantiate(CoinPrefab, new Vector2(19.26f, 2.5f), Quaternion.identity);
        yield return new WaitForSeconds(c);
        Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);
        Instantiate(sRockPrefab, new Vector2(20.26f, -2.78f), Quaternion.identity);
        Instantiate(CoinPrefab, new Vector2(17.26f, -1f), Quaternion.identity);
        Instantiate(CoinPrefab, new Vector2(20.26f, 0.5f), Quaternion.identity);
        Instantiate(CoinPrefab, new Vector2(23.26f, -1f), Quaternion.identity);
        yield return new WaitForSeconds(c);
        Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);
        Instantiate(sRockPrefab, new Vector2(20.26f, -2.78f), Quaternion.identity);
        Instantiate(stalPrefab, new Vector2(20.26f, 5.52f), Quaternion.identity);
        Instantiate(stalPrefab, new Vector2(23.26f, 5.52f), Quaternion.identity);
        Instantiate(CoinPrefab, new Vector2(17.26f, -1f), Quaternion.identity);
        Instantiate(CoinPrefab, new Vector2(20.26f, 0.5f), Quaternion.identity);
        //yield return new WaitForSeconds(c);
        //lap = Random.Range(4, 7);
        while (d < lap)//떨어지는 종유석
        {
            yield return new WaitForSeconds(c);
            Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);
            Instantiate(FallstalPrefab, new Vector2(7.7f, 6.56f), Quaternion.identity);
            Instantiate(FallstalPrefab, new Vector2(10.7f, 6.56f), Quaternion.identity);
            Instantiate(FallstalPrefab, new Vector2(13.7f, 6.56f), Quaternion.identity);
            Instantiate(stalPrefab, new Vector2(20.26f, 2.2f), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector2(14f, -0.5f), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector2(17f, -0.5f), Quaternion.identity);
            d++;
        }
        //StartCoroutine(Spwon10());
        Randommap();
        CheckSpeed();
        yield return null;

    }

    IEnumerator Spwon11()//점프조절맵 어려움 + 코인
    {
        d = 0;//횟수
        e = 1;//속도
        mapno = 11;
        yield return new WaitForSeconds(c);
        Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);
        Instantiate(sRockPrefab, new Vector2(17.26f, -2.78f), Quaternion.identity);
        Instantiate(sRockPrefab, new Vector2(23.26f, -2.78f), Quaternion.identity);
        Instantiate(CoinPrefab, new Vector2(19.26f, -1.8f), Quaternion.identity);
        Instantiate(CoinPrefab, new Vector2(22.26f, 0.2f), Quaternion.identity);
        yield return new WaitForSeconds(c);
        Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);
        Instantiate(CoinPrefab, new Vector2(19.26f, -1.8f), Quaternion.identity);
        yield return new WaitForSeconds(c);
        Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);
        Instantiate(stalPrefab, new Vector2(14.26f, 1.52f), Quaternion.identity);
        Instantiate(stalPrefab, new Vector2(18.26f, 1.52f), Quaternion.identity);
        Instantiate(stalPrefab, new Vector2(21.26f, 1.52f), Quaternion.identity);
        Instantiate(CoinPrefab, new Vector2(14.26f, -2.5f), Quaternion.identity);
        Instantiate(CoinPrefab, new Vector2(18.26f, -2.5f), Quaternion.identity);
        Instantiate(CoinPrefab, new Vector2(21.26f, -2.5f), Quaternion.identity);
        yield return new WaitForSeconds(c);
        Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);
        Instantiate(stalPrefab, new Vector2(14.26f, 1.52f), Quaternion.identity);
        Instantiate(stalPrefab, new Vector2(18.26f, 1.52f), Quaternion.identity);
        Instantiate(stalPrefab, new Vector2(21.26f, 1.52f), Quaternion.identity);
        Instantiate(CoinPrefab, new Vector2(14.26f, -2.5f), Quaternion.identity);
        Instantiate(CoinPrefab, new Vector2(18.26f, -2.5f), Quaternion.identity);
        Instantiate(CoinPrefab, new Vector2(21.26f, -2.5f), Quaternion.identity);
        yield return new WaitForSeconds(c);
        Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);//밑의 패턴과 세트
        Instantiate(CoinPrefab, new Vector2(16.26f, -1.8f), Quaternion.identity);
        yield return new WaitForSeconds(c);
        Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);
        Instantiate(sRockPrefab, new Vector2(10.26f, -2.78f), Quaternion.identity);
        Instantiate(Hpup, new Vector2(8f, 1.36f), Quaternion.identity);
        Instantiate(sRockPrefab, new Vector2(18.26f, -2.78f), Quaternion.identity);
        Instantiate(CoinPrefab, new Vector2(11.26f, 0.5f), Quaternion.identity);
        Instantiate(CoinPrefab, new Vector2(14.26f, 0.5f), Quaternion.identity);
        Instantiate(CoinPrefab, new Vector2(17.26f, 0.5f), Quaternion.identity);
        yield return new WaitForSeconds(c);
        Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);
        Instantiate(bRockPrefab, new Vector2(21.26f, -2.1f), Quaternion.identity);
        Instantiate(CoinPrefab, new Vector2(13.26f, -2.5f), Quaternion.identity);
        Instantiate(CoinPrefab, new Vector2(16.26f, -2.5f), Quaternion.identity);
        Instantiate(CoinPrefab, new Vector2(21.26f, 0.5f), Quaternion.identity);
        yield return new WaitForSeconds(c);
        Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);
        Instantiate(stalPrefab, new Vector2(20.26f, 1.52f), Quaternion.identity);
        Instantiate(CoinPrefab, new Vector2(18.26f, -2.5f), Quaternion.identity);
        Instantiate(CoinPrefab, new Vector2(21.26f, -2.5f), Quaternion.identity);
        Instantiate(CoinPrefab, new Vector2(25.26f, -0.5f), Quaternion.identity);
        Instantiate(StickPrefab, new Vector2(18.26f, 0.8f), Quaternion.identity);
        yield return new WaitForSeconds(c);
        Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);
        Instantiate(bRockPrefab, new Vector2(20.26f, -2.1f), Quaternion.identity);
        Instantiate(CoinPrefab, new Vector2(20.26f, 0.5f), Quaternion.identity);
        yield return new WaitForSeconds(c);
        Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);
        Instantiate(stalPrefab, new Vector2(19.26f, 1.52f), Quaternion.identity);
        Instantiate(CoinPrefab, new Vector2(17.26f, -2.5f), Quaternion.identity);
        Instantiate(CoinPrefab, new Vector2(20.26f, -2.5f), Quaternion.identity);
        Instantiate(CoinPrefab, new Vector2(24.26f, -0.5f), Quaternion.identity);
        yield return new WaitForSeconds(c);
        Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);
        Instantiate(bRockPrefab, new Vector2(19.26f, -2.1f), Quaternion.identity);
        Instantiate(CoinPrefab, new Vector2(19.26f, 0.5f), Quaternion.identity);
        yield return new WaitForSeconds(c);
        Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);
        Instantiate(stalPrefab, new Vector2(18.26f, 1.52f), Quaternion.identity);
        Instantiate(CoinPrefab, new Vector2(16.26f, -2.5f), Quaternion.identity);
        Instantiate(CoinPrefab, new Vector2(19.26f, -2.5f), Quaternion.identity);
        Instantiate(CoinPrefab, new Vector2(23.26f, -0.5f), Quaternion.identity);
        yield return new WaitForSeconds(c);
        Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);
        Instantiate(bRockPrefab, new Vector2(18.26f, -2.1f), Quaternion.identity);
        Instantiate(CoinPrefab, new Vector2(18.26f, 0.5f), Quaternion.identity);
        yield return new WaitForSeconds(c);
        Instantiate(GroundPrefab, new Vector2(18.26f, -4.36f), Quaternion.identity);
        Instantiate(CoinPrefab, new Vector2(14.26f, -2f), Quaternion.identity);
        Instantiate(CoinPrefab, new Vector2(16.26f, -2f), Quaternion.identity);
        Instantiate(CoinPrefab, new Vector2(18.26f, -2f), Quaternion.identity);
        //StartCoroutine(Spwon11());
        Randommap();
        CheckSpeed();
        yield return null;

    }

    void CheckSpeed()
    {
        if (Curser.i == 0 && Curser.j == 2)//캐릭터가 힙합보이라면
            c = b[e];
        else
            c = a[e];
    }

    void Randommap()
    {
        map = Random.Range(1, 12);
        switch (map)
        {
            case 1 :
                StartCoroutine(Spwon1());
                break;
            case 2:
                StartCoroutine(Spwon2());
                break;
            case 3:
                StartCoroutine(Spwon3());
                break;
            case 4:
                StartCoroutine(Spwon4());
                break;
            case 5:
                StartCoroutine(Spwon5());
                break;
            case 6:
                StartCoroutine(Spwon6());
                break;
            case 7:
                StartCoroutine(Spwon7());
                break;
            case 8:
                StartCoroutine(Spwon8());
                break;
            case 9:
                StartCoroutine(Spwon9());
                break;
            case 10:
                StartCoroutine(Spwon10());
                break;
            case 11:
                StartCoroutine(Spwon11());
                break;
        }
    }
}
