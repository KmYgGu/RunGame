using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class RetryUno : MonoBehaviour {//아두이노용 컨트롤러 코드

    //SerialPort sp = new SerialPort("COM5", 9600); //?부분을 지우고 쓰고있는 컴퓨터에 해당하는 COM숫자를 넣기
    SerialPort sp = CurserUno.sp;
    public static int MonkeyJump;
    Rigidbody2D rigid2D;
    Animator animator;
    public AudioSource audio1;
    public AudioClip slideSound;
    public AudioSource audio2;
    public AudioClip JumpSound;
    public float jumpForce = 1;
    public static int jumpCount2;
    public bool isSlideSound;
    public static bool UnoSoliaHeal;

    void Start () {
        //sp.Open();//시리얼통신 오픈
        //sp.ReadTimeout = 1;//아두이노 관련
        MonkeyJump = 0;
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.audio1 = this.gameObject.AddComponent<AudioSource>();
        this.audio1.clip = this.slideSound;
        this.audio1.loop = false;
        this.audio2 = this.gameObject.AddComponent<AudioSource>();
        this.audio2.clip = this.JumpSound;
        this.audio2.loop = false;
        isSlideSound = false;
        jumpCount2 = 0;
        UnoSoliaHeal = false;
        if (Curser.i == 0 && Curser.j == 2) //캐릭터가 힙합보이일경우
            MapMove.speedselect = -1.25f;
    }
	
	void Update () {
		if(sp.IsOpen)
        {
            try
            {
                CharMove(sp.ReadByte());
                //print(sp.ReadByte());//한번 주석처리해볼까?
            }
            catch (System.Exception)
            {

            }
        }
	}

    void CharMove(int distance)
    {
        if (RetryChar.isGround)
        {
            /*this.animator.SetBool("isSiding", false);
            this.animator.SetBool("isRuning", true);
            isSlideSound = false;*/
            if (distance == 1 && (jumpCount2 == 0)) //첫번째 센서 : 슬라이딩
            {
                this.animator.SetBool("isSiding", true);
                this.animator.SetBool("isRuning", false);
                if (isSlideSound == false)
                {
                    this.audio1.Play();
                    isSlideSound = true;
                }
            }
            if (!(distance == 1))//슬라이딩 else
            {
                this.animator.SetBool("isSiding", false);
                this.animator.SetBool("isRuning", true);
                isSlideSound = false;
            }
            if ((distance == 2) && (MonkeyJump == 0 || MonkeyJump == 2)) //두번째 센서 : 점프
            {
                rigid2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                jumpCount2++;
                this.animator.SetBool("isRuning", true);
                this.audio2.Play();
                MonkeyJump = 1;
                if (jumpCount2 == 3)
                {
                    RetryChar.isGround = false;
                    Score_Manager.score += 50;
                    this.animator.SetBool("isJumping", true);
                }
            }
            if (distance == 3) //세번째 센서 : 2단점프
            {
                rigid2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                jumpCount2++;
                this.animator.SetBool("isRuning", true);
                this.audio2.Play();
                MonkeyJump = 2;
                if ((jumpCount2 == 2) && !(Curser.i == 0 && Curser.j == 3))
                {
                    RetryChar.isGround = false;
                    this.animator.SetBool("isJumping", true);
                    if (Curser.i == 0 && Curser.j == 5)//태양맨
                    {
                        UnoSoliaHeal = true;
                        //StartCoroutine(Solia());
                    }
                }
                if (jumpCount2 == 3)
                {
                    RetryChar.isGround = false;
                    Score_Manager.score += 10;
                    this.animator.SetBool("isJumping", true);
                }
            }
            /*if (!(distance == 3))//3번째 센서에서 벗어난 경우
            {
                UnoSoliaHeal = false;
            }*/
        }
    }

}
