using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//씬변환(게임화면전환) 작업을 위해 추가

public class Retry : MonoBehaviour {
    Rigidbody2D rigid2D;//게임오브젝트(캐릭터)의 물리엔진을 가져오기 위해 유니티의 리드바디 선언
    Animator animator;// 캐릭터가 움직이는 걸 코드로 설정하기 위해 유니티의 애니메이터 선언
    public AudioSource audio1;//소리를 내기 위해 오디오소스 선언
    public AudioClip slideSound;//사운드 파일을 저장하기 위해 오디오클립 선언
    public AudioSource audio2;
    public AudioClip JumpSound;
    public float jumpForce = 1;//public float jumpForce = 680.0f;//점프력
    public static int jumpCount;//점프횟수 측정
    public static bool SoliaHeal;//태양맨 캐릭터의 능력을 구현하는 참,거짓 변수
    public bool isSlideSound;//슬라이딩 사운드가 반복되서 재생이 안되게 방지하는 변수

    // Use this for initialization
    void Start () {//게임을 시작하자마자 딱 한번 실행되는 함수
        this.rigid2D = GetComponent<Rigidbody2D>();
        //이코드를 넣은 게임오브젝트의 리드바디를 앞에서 선언한 리드바디 함수에다가 적용
        this.animator = GetComponent<Animator>();
        this.audio1 = this.gameObject.AddComponent<AudioSource>();
        this.audio1.clip = this.slideSound;
        this.audio1.loop = false;
        this.audio2 = this.gameObject.AddComponent<AudioSource>();
        this.audio2.clip = this.JumpSound;
        this.audio2.loop = false;
        jumpCount = 0;//점프횟수는 0
        SoliaHeal = false;
        RetryChar.isGround = true;//땅에 착지한게 참
        isSlideSound = false;
        if (Curser.i == 0 && Curser.j == 2) //캐릭터가 힙합보이일경우
            MapMove.speedselect = -1.25f;//맵의 속도를 빠르게 하기
    }
	
	protected void Update () {//게임을 시작하자마자 계속 반복되는 함수
        CharControl();//계속 '캐릭터조종'이란 함수를 반복한다
    }
    /*public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Ground") {//땅이라는 이름을 가진 물체과 부딪힐경우
            isGround = true;//땅에 착지한게 참이 되고
            jumpCount = 0;// 점프횟수는 초기화
            this.animator.SetBool("isJumping", false);
        }
        if (collision.gameObject.tag == "DeadLine")
        {
            //this.gameObject.SetActive(false);
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }

    }*/

    /*public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Wall" && Ouch == false)//벽에 부딪혔을 때
        {
            life -= 1;
            
            if (Firebar.transform.localScale.x <= 0.26)
            {
                //Firebar.transform.localScale += new Vector3(0.06f, 0, 0);
                Ouch = true;
                transform.Translate(-1, 1, 0);
                StartCoroutine("UnBeatTime");
            }
            else if (Firebar.transform.localScale.x > 0.26)
            {
                if (Curser.i == 0 && Curser.j == 5)//캐릭터가 태양맨일 경우
                {
                    Firebar.transform.localScale -= new Vector3(0.1f, 0, 0); //막대기 감소
                    Ouch = true;
                    transform.Translate(-1, 1, 0);
                    StartCoroutine("UnBeatTime");
                }
                else//아닐경우
                {
                    Firebar.transform.localScale -= new Vector3(0.2f, 0, 0); //막대기 감소
                    Ouch = true;
                    transform.Translate(-1, 1, 0);
                    StartCoroutine("UnBeatTime");
                }
            }
            
        }
    }*/

    public void CharControl()//Update 함수에 의해 계속 반복되는 함수
    {
        if (RetryChar.isGround)//캐릭터가 땅에 착지한 경우
        {
            if(Curser.i == 0 && Curser.j == 3) //캐릭터가 몽키일 경우
            {
                Jump();//점프 함수를 실행할 수도 있다
                if (jumpCount == 3)//점프 횟수 : 3 즉 삼단 점프 다했을때
                {
                    RetryChar.isGround = false;//땅에 착지해야 하니까 거짓으로 변경
                    Score_Manager.score += 50;//몽키만의 점프점수 획득
                    this.animator.SetBool("isJumping", true);
                    //캐릭터가 3단점프 모습으로 바뀌어 지게 유니티의 애니메이터 지정
                }
            }
            else//몽키가 아닌 모든 캐릭터
            {
                Jump();
                if (jumpCount == 2)//점프 횟수 : 2 즉 이단 점프 다했을때
                {
                    RetryChar.isGround = false;//땅에 착지해야 하니까 거짓으로 변경
                                     //this.animator.SetTrigger("JumpTrigger");
                    this.animator.SetBool("isJumping", true);
                    if (Curser.i == 0 && Curser.j == 5)//태양맨
                    {
                        SoliaHeal = true;//태양맨 능력발동
                    }
                }
            }
            if (Input.GetKey(KeyCode.X) && (jumpCount == 0))//캐릭터가 땅에 착지한 상태에서 슬라이딩 키를 누르면
            {
                this.animator.SetBool("isSiding", true);//슬라이딩 자세로 변환
                this.animator.SetBool("isRuning", false);
                //this.audio1.Play();
                if (isSlideSound == false)//슬라이딩소리가 계속 나오지 않게 방지
                {
                    this.audio1.Play();//슬라이딩 소리재생
                    isSlideSound = true;
                }
            }
            else//슬라이딩 키를 누르지 않았더라면
            {
                this.animator.SetBool("isSiding", false);//뛰는 자세로 변환
                this.animator.SetBool("isRuning", true);
                isSlideSound = false;//슬라이딩 소리가 계속나오게하는 방지 해제
            }
            /*if (Input.GetKey(KeyCode.C))
                Score_Manager.score += 100;*/
        }
    }

    public void Jump()//점프 함수
    {
        if (Input.GetKeyDown(KeyCode.Z))//점프 키를 눌렀을 때
        {
            rigid2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            //캐릭터안에 저장된 Y축 물리엔진값을 점프력만큼 갑자기 증가 
            //transform.Translate(0, 2, 0);
            jumpCount++;//점프횟수 추가
            this.animator.SetBool("isRuning", true);//일단 점프를 해도 뛰는 모습은 변함없음
            this.audio2.Play();//점프소리 재생
        }
    }

    /*IEnumerator UnBeatTime()
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
    }*/

    /*public void LifeRestore()
    {
        if (life >= 3)
        {
            life = 3;
            //transform.position = new Vector3 (0, 0, 0);//해당위치로 이동
            //transform.position = CharVector;
        }
        else if (life < 3)
        {
            float LifeSpeed = 0.1f * (Time.deltaTime);
            //life += 0.1f * Time.deltaTime;
            life += LifeSpeed;
            transform.Translate(LifeSpeed, 0, 0);
        }
    }*/

    /*public void Shoot()
    {
        Harmo -= 1  * (Time.deltaTime);
        //Harmo = Mathf.Round(Harmo);반올림
        Harmo = Mathf.Floor(Harmo);//내림
        if (Harmo % 10 == 0)
            Shooting = true;
    }*/
}
