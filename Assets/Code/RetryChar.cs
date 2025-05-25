using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryChar : MonoBehaviour {
    SpriteRenderer SpRend;
    Animator animator;
    public GameObject Firebar;
    public static float Harmo;//총알을 쏘기위한 시간
    public static bool Shooting;
    public static bool isGround;//땅에 착지했는지 확인
    public static float life;
    public float test;
    public static bool Ouch;
    public static bool heal;
    public static bool Eaten;
    float Johnup;
    public AudioSource audio1;
    public AudioClip OuchSound;
    public AudioSource audio2;
    public AudioClip PiterGunSound;
    public static bool TShlied;
    public AudioSource audio3;
    public AudioClip PoPa;
    public static int Boom;
    public GameObject Pork8;//폭팔화면
    public int BoomCount; //붐카운트 측정

    void Start () {
        //transform.position = new Vector3(-3, this.gameObject.transform.position.y, 0);//위치초기화
        transform.position = new Vector3(-3, 0, 0);//위치초기화
        life = 3;
        Harmo = 100;
        Shooting = false;
        Ouch = false;
        heal = false;
        Eaten = false;
        Boom = 0;
        this.SpRend = GetComponent<SpriteRenderer>();
        this.animator = GetComponent<Animator>();
        JohnAbil();
        this.audio1 = this.gameObject.AddComponent<AudioSource>();
        this.audio1.clip = this.OuchSound;
        this.audio1.loop = false;
        this.audio2 = this.gameObject.AddComponent<AudioSource>();
        this.audio2.clip = this.PiterGunSound;
        this.audio2.loop = false;
        this.audio3 = this.gameObject.AddComponent<AudioSource>();
        this.audio3.clip = this.PoPa;
        this.audio3.loop = false;
        if (Curser.i == 0 && Curser.j == 5)//태양맨일 경우
        {
            Firebar.transform.localScale -= new Vector3(0.6f, 0, 0);//게이지바 엄청깎기
        }
        if (Curser.i == 1 && Curser.j == 0)//테일려일 경우
        {
            TShlied = true;
        }
        else if (!(Curser.i == 1 && Curser.j == 0))//테일러가 아닐경우
        {
            TShlied = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
        LifeRestore();
        Run();
        bugFix();//지형관통버그고치기
        SYBoom();
        if (Curser.i == 0 && Curser.j == 4)
        {
            Shoot();
        }
        if(Retry.SoliaHeal == true || RetryUno.UnoSoliaHeal == true)
        {
            Firebar.transform.localScale += new Vector3(0.07f, 0, 0);//초기값 0.14
        }
        BoomCount = Boom;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {//땅이라는 이름을 가진 물체과 부딪힐경우
            isGround = true;//땅에 착지한게 참이 되고
            Retry.jumpCount = 0;// 점프횟수는 초기화
            RetryUno.jumpCount2 = 0;
            RetryUno.MonkeyJump = 0;
            Donald.DonaldjumpCount = 0;
            DonaldUno.UnoDonaldjumpCount = 0;
            LV.LVjumpCount = 0;
            LVUno.UnoLVjumpCount = 0;
            this.animator.SetBool("isJumping", false);
            /*if(life == 3)
            {
                transform.position = new Vector3(-3, this.gameObject.transform.position.y, 0);//위치초기화
            }*/
        }
        if (collision.gameObject.tag == "DeadLine")//낙사
        {
            this.gameObject.SetActive(false);
            //Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }

    public void Run()//장애물에 의해 체력은 안깎이고 거리만 밀렸을 경우
    {
        if (isGround)
        {
            if (this.gameObject.transform.position.x < -3 && life == 3)
                transform.Translate(0.005f, 0, 0);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall" && Ouch == false && TShlied == false)//벽에 부딪혔을 때.테일러 쉴드가 없을때
        {
            life -= 1;
            this.audio1.Play();

            if (Firebar.transform.localScale.x <= 0.26)
            {
                //Firebar.transform.localScale += new Vector3(0.06f, 0, 0);
                Ouch = true;
                transform.Translate(-1, 1, 0);
                StartCoroutine("UnBeatTime2");
            }
            else if (Firebar.transform.localScale.x > 0.26)
            {
                Firebar.transform.localScale -= new Vector3(0.2f, 0, 0); //막대기 감소
                Ouch = true;
                transform.Translate(-1, 1, 0);
                StartCoroutine("UnBeatTime2");
                /*if (Curser.i == 0 && Curser.j == 5)//캐릭터가 태양맨일 경우           삭제
                {
                    Firebar.transform.localScale -= new Vector3(0.1f, 0, 0); //막대기 감소
                    Ouch = true;
                    transform.Translate(-1, 1, 0);
                    StartCoroutine("UnBeatTime2");
                }
                else//아닐경우
                {
                    Firebar.transform.localScale -= new Vector3(0.2f, 0, 0); //막대기 감소
                    Ouch = true;
                    transform.Translate(-1, 1, 0);
                    StartCoroutine("UnBeatTime2");
                }*/
            }
            if ((Curser.i == 1 && Curser.j == 1) && DarkTurn.test >=0.8f)//어쌔신
            {
                this.gameObject.SetActive(false);
                //Destroy(gameObject);
                SceneManager.LoadScene("GameOver");
            }
            if (Curser.i == 1 && Curser.j == 5)//LV
            {
                isGround = false;
                LV.LVjumpCount = -1;
                LVUno.UnoLVjumpCount = -1;
            }

        }
        if (collision.gameObject.tag == "Wall" && Ouch == false && TShlied == true)//테일러 쉴드가 있고 벽에 부딪힐 때
        {
            this.audio1.Play();
            StartCoroutine("UnBeatTime2");
            //transform.Translate(-1, 1, 0);
            TShlied = false;
            Ouch = true;

        }
        if (collision.gameObject.tag == "HpUp")
        {
            Firebar.transform.localScale += new Vector3(0.7f+ Johnup, 0, 0); //감소량의 3배 회복 0.6
            heal = true;
        }
        /*if (collision.gameObject.tag == "FootHole")
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
            //Invoke("Wait", 0.25f);
        }*/

    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FootHole")
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
            //Invoke("Wait", 0.25f);
        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FootHole")
        {
            GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }

    void Wait()
    {
        GetComponent<BoxCollider2D>().isTrigger = false;
    }

    IEnumerator UnBeatTime2()
    {
        int countTime = 0;//깜빡이는 횟수

        while (countTime < 8)
        {
            if (countTime % 2 == 0)
                SpRend.color = new Color32(255, 255, 255, 90);
            else
                SpRend.color = new Color32(255, 255, 255, 180);

            yield return new WaitForSeconds(0.2f);

            countTime++;
        }
        SpRend.color = new Color32(255, 255, 255, 255);
        yield return null;
    }

    public void LifeRestore()
    {
        if (life >= 3)
        {
            life = 3;
            test = life;
            //transform.position = new Vector3(-3, this.gameObject.transform.position.y, 0);//위치초기화
        }
        else if (life < 3)
        {
            float LifeSpeed = 0.1f * (Time.deltaTime);
            //life += 0.1f * Time.deltaTime;
            life += LifeSpeed;
            test = life;
            transform.Translate(LifeSpeed, 0, 0);
        }
    }

    public void Shoot()
    {
        //Shooting = false;
        //Harmo -= 1 * (Time.deltaTime);
        //Harmo = Mathf.Round(Harmo);반올림
        //Harmo = Mathf.Floor(Harmo);//내림
        //Harmo = Mathf.Floor(DarkTurn.Count)*10000;
        // Harmo = DarkTurn.test * 100;
        Harmo = Mathf.Floor(DarkTurn.test * 100);//100
        if (Harmo % 15 == 0 && Shooting == false)
            //this.audio2.Play();
            StartCoroutine(Shoot2());
            //Shooting = true;
    }

    IEnumerator Shoot2()
    {
        Shooting = true;
        this.audio2.Play();
        yield return new WaitForSeconds(0);//3
    }

    public void JohnAbil()
    {
        if (Curser.i == 0 && Curser.j == 0)//존
        {
            Johnup = 0.2f;
        }
        if (!(Curser.i == 0 && Curser.j == 0))//존이 아님
        {
            Johnup = 0;
        }

    }

    public void bugFix()
    {
        if(this.gameObject.GetComponent<BoxCollider2D>().isTrigger == true)
        {
            Invoke("Wait", 0.35f);
        }
    }
    public void SYBoom()
    {
        Pork8.SetActive(false);
        if (Boom == 7)
        {
            Pork8.SetActive(true);
            Boom = 0;
            this.audio3.Play();
            /*Firebar.transform.localScale += new Vector3(0.7f + Johnup, 0, 0); //회복효과
            heal = true;*/
            GameObject[] Wall2 = GameObject.FindGameObjectsWithTag("Wall");
            //Wall2[Wall2.Length].SetActive(false);
            /*while(Wall2.Length-c < -1)
            {
                Wall2[Wall2.Length-c].SetActive(false);
                c++;
            }
            c = 1;*/
            foreach (GameObject X in Wall2)
            {
                X.SetActive(false);
            }
        }
    }
}
