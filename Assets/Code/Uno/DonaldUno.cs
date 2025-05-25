using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class DonaldUno : MonoBehaviour {

    //SerialPort sp = new SerialPort("COM5", 9600); //?부분을 지우고 쓰고있는 컴퓨터에 해당하는 COM숫자를 넣기
    SerialPort sp = CurserUno.sp;
    Rigidbody2D rigid2D;
    Animator animator;
    public AudioSource audio1;
    public AudioClip slideSound;
    public AudioSource audio2;
    public AudioClip JumpSound;
    public AudioSource audio3;
    public AudioClip JumpSound2;
    public AudioSource audio4;
    public AudioClip DonaMagic;
    public float jumpForce = 1;//public float jumpForce = 680.0f;//점프력
    public static int UnoDonaldjumpCount;//점프횟수 측정
    public bool isSlideSound;
    public static int UnoDona;
    int UnoDDDona;
    public int Check;//Dona체크
    public int Check2;//도날드 점프카운트 체크
    public static bool UnoMagic;

    void Start () {
        //sp.Open();//주석처리해야 할것 같다
        //sp.ReadTimeout = 1;//주석처리해야 할것 같다
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.audio1 = this.gameObject.AddComponent<AudioSource>();
        this.audio1.clip = this.slideSound;
        this.audio1.loop = false;
        this.audio2 = this.gameObject.AddComponent<AudioSource>();
        this.audio2.clip = this.JumpSound;
        this.audio2.loop = false;
        this.audio3 = this.gameObject.AddComponent<AudioSource>();
        this.audio3.clip = this.JumpSound2;
        this.audio3.loop = false;
        this.audio4 = this.gameObject.AddComponent<AudioSource>();
        this.audio4.clip = this.DonaMagic;
        this.audio4.loop = false;
        UnoDonaldjumpCount = 0;//점프횟수는 0
        RetryChar.isGround = true;//땅에 착지한게 참
        isSlideSound = false;
        UnoDona = 0;
        UnoDDDona = 0;
        StartCoroutine(Uno());
        UnoMagic = false;
    }
	
	/*void Update () {
        if (sp.IsOpen)
        {
            try
            {
                CharControl3(sp.ReadByte());
                print(sp.ReadByte());
            }
            catch (System.Exception)
            {

            }
        }

    }*/

    IEnumerator Uno()
    {
        if (sp.IsOpen)
        {
            try
            {
                CharControl3(sp.ReadByte());
                print(sp.ReadByte());
            }
            catch (System.Exception)
            {

            }
        }
        yield return new WaitForSeconds(0);
        StartCoroutine(Uno());
    }

    public void  CharControl3(int distance)
    {
        if (RetryChar.isGround == true)//땅에 착지한 경우
        {
            //StartCoroutine(Jump2());
            if (distance == 2 && UnoDonaldjumpCount == 0 && UnoDona == 0)//2번째 센서
            {
                rigid2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                UnoDonaldjumpCount++;
                this.animator.SetInteger("Dona", 1);
                this.audio2.Play();
                //yield return new WaitForSeconds(0.1f);
                UnoDDDona = 1;
                Invoke("DonaSet", 0.1f);
                this.animator.SetBool("2nd", true);
                Check = UnoDona;
                Check2 = UnoDonaldjumpCount;
                //StartCoroutine(Uno());
            }
            if (distance == 2 && UnoDonaldjumpCount == 0 && UnoDona == 1)//2번째 센서 1단
            {
                rigid2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                UnoDonaldjumpCount++;
                this.animator.SetInteger("Dona", 2);
                this.audio2.Play();
                //yield return new WaitForSeconds(0.1f);
                UnoDDDona = 2;
                Invoke("DonaSet", 0.1f);
                Check = UnoDona;
                Check2 = UnoDonaldjumpCount;
                //StartCoroutine(Uno());
            }
            if ((distance == 3) && UnoDonaldjumpCount == 1 && UnoDona == 1)//3번째 센서 2단
            {
                rigid2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                UnoDonaldjumpCount = 2;
                this.animator.SetInteger("Dona", 3);
                this.animator.SetBool("2nd", false);
                this.audio3.Play();
                UnoDona = 0;
                Check = UnoDona;
                Check2 = UnoDonaldjumpCount;
                //StartCoroutine(Uno());
            }
            if ((distance == 3) && UnoDonaldjumpCount == 1 && UnoDona == 2)//3번째 센서 2단
            {
                rigid2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                UnoDonaldjumpCount = 2;
                this.animator.SetInteger("Dona", 3);
                this.animator.SetBool("2nd", false);
                this.audio3.Play();
                UnoDona = 3;
                Check = UnoDona;
                Check2 = UnoDonaldjumpCount;
                //StartCoroutine(Uno());
            }
            if (UnoDonaldjumpCount == 2)//점프 횟수 : 2 즉 이단 점프 다했을때
            {
                RetryChar.isGround = false;//땅에 착지해야 하니까 거짓으로 변경
                Check2 = UnoDonaldjumpCount;
                //StartCoroutine(Uno());
            }
            if (distance == 1 && (UnoDonaldjumpCount == 0))//1번째 슬라이딩 센서
            {
                this.animator.ResetTrigger("Magic");
                this.animator.SetBool("isSiding", true);
                this.animator.SetBool("isRuning", false);
                //StartCoroutine(Uno());
                if (isSlideSound == false)
                {
                    this.audio1.Play();
                    isSlideSound = true;
                }
            }
            else
            {
                this.animator.SetBool("isSiding", false);
                this.animator.SetBool("isRuning", true);
                isSlideSound = false;
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)//고쳐라
    {
        if (collision.gameObject.tag == "Ground")
        {
            Check2 = UnoDonaldjumpCount;
            animator.SetInteger("Dona", 0);
            if (UnoDona == 2 || UnoDona == 3)
            {
                if (UnoDona == 3)
                {
                    this.audio4.Play();
                    UnoDona = 0;
                    this.animator.SetTrigger("Magic");
                    UnoMagic = true;
                }
                UnoDona = 0;
            }
        }
    }

    public void DonaSet()
    {
        UnoDona = UnoDDDona;
    }
}
