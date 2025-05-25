using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Donald : MonoBehaviour
{
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
    public static int DonaldjumpCount;//점프횟수 측정
    public bool isSlideSound;
    public static int Dona;
    public int Check;//Dona체크
    public int Check2;//도날드 점프카운트 체크
    public static bool Magic;

    // Use this for initialization
    void Start()
    {
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
        DonaldjumpCount = 0;//점프횟수는 0
        RetryChar.isGround = true;//땅에 착지한게 참
        isSlideSound = false;
        Dona = 0;
        StartCoroutine(CharControl2());
        Magic = false;
    }

    /*public void CharControl()
    {
        if (RetryChar.isGround)//땅에 착지한 경우
        {  
                Jump();
                if (DonaldjumpCount == 2)//점프 횟수 : 2 즉 이단 점프 다했을때
                {
                    RetryChar.isGround = false;//땅에 착지해야 하니까 거짓으로 변경
                    //this.animator.SetBool("isJumping", true);
                }
            if (Input.GetKey(KeyCode.X) && (DonaldjumpCount == 0))
            {
                this.animator.SetBool("isSiding", true);
                this.animator.SetBool("isRuning", false);
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

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Z)&&Dona==0 && limit == false )//1단
        {
            //Dona = 1;
            DDDona = 1;
            Invoke("DonaDelay", 0.3f);
            rigid2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            DonaldjumpCount++;
            this.animator.SetBool("isRuning", true);
            this.audio2.Play();
            Check = Dona;
            limit = true;
        }
        if (Input.GetKeyDown(KeyCode.Z) && Dona == 1 && limit == false)//1단
        {
            Dona = 2;
            //DDDona = 2;
            //Invoke("DonaDelay", 0.3f);
            rigid2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            DonaldjumpCount++;
            this.animator.SetBool("isRuning", true);
            this.audio2.Play();
            Check = Dona;
        }
        if (Input.GetKeyDown(KeyCode.Z) && DonaldjumpCount == 1 && Dona == 1)//2단
        {
            Dona = 0;
            //DDDona = 0;
            //Invoke("DonaDelay", 0.3f);
            rigid2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            DonaldjumpCount++;
            this.animator.SetBool("isRuning", true);
            this.audio3.Play();
            Check = Dona;
        }
        if (Input.GetKeyDown(KeyCode.Z) && DonaldjumpCount == 1 && Dona == 2)//2단
        {
            Dona = 3;
            //DDDona = 3;
            //Invoke("DonaDelay", 0.3f);
            rigid2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            DonaldjumpCount++;
            this.animator.SetBool("isRuning", true);
            this.audio3.Play();
            Check = Dona;
        }
    }*/

    IEnumerator CharControl2()
    {
        if (RetryChar.isGround == true)//땅에 착지한 경우
        {
            StartCoroutine(Jump2());
            if (DonaldjumpCount == 2)//점프 횟수 : 2 즉 이단 점프 다했을때
            {
                //this.animator.SetInteger("Dona", 0);
                RetryChar.isGround = false;//땅에 착지해야 하니까 거짓으로 변경
                Check2 = DonaldjumpCount;
            }
            if (Input.GetKey(KeyCode.X) && (DonaldjumpCount == 0))
            {
                this.animator.ResetTrigger("Magic");
                this.animator.SetBool("isSiding", true);
                this.animator.SetBool("isRuning", false);
                if (isSlideSound == false)
                {
                    this.audio1.Play();
                    isSlideSound = true;
                }
            }
            else
            {
                //this.animator.SetInteger("Dona", 0);
                this.animator.SetBool("isSiding", false);
                this.animator.SetBool("isRuning", true);
                isSlideSound = false;
            }
            //yield return new WaitForSeconds(0);
            //StartCoroutine(CharControl2());
        }
        yield return new WaitForSeconds(0);
        StartCoroutine(CharControl2());
    }

    IEnumerator Jump2()
    {
        if (Input.GetKeyDown(KeyCode.Z) && DonaldjumpCount == 0 && Dona == 0)//1단&& limit == false
        {
            rigid2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            DonaldjumpCount++;
            //this.animator.SetBool("isRuning", true);
            this.animator.SetInteger("Dona", 1);
            //this.animator.SetBool("2nd", true);
            this.audio2.Play();
            //limit = true;
            yield return new WaitForSeconds(0.1f);
            Dona = 1;
            this.animator.SetBool("2nd", true);
            Check = Dona;
            Check2 = DonaldjumpCount;
        }
        if (Input.GetKeyDown(KeyCode.Z) && DonaldjumpCount == 0 && Dona == 1)//1단&& limit == false
        {
            rigid2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            DonaldjumpCount++;
            //this.animator.SetBool("isRuning", true);
            this.animator.SetInteger("Dona", 2);
            this.audio2.Play();
            yield return new WaitForSeconds(0.1f);
            Dona = 2;
            Check = Dona;
            Check2 = DonaldjumpCount;
        }
        if (Input.GetKeyDown(KeyCode.Z) && DonaldjumpCount == 1 && Dona == 1)//2단
        {
            //RetryChar.isGround = false;
            rigid2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            DonaldjumpCount = 2;
            //this.animator.SetBool("isRuning", true);
            this.animator.SetInteger("Dona", 3);
            this.animator.SetBool("2nd", false);
            this.audio3.Play();
            //yield return new WaitForSeconds(0.1f);
            Dona = 0;
            Check = Dona;
            Check2 = DonaldjumpCount;
        }
        if (Input.GetKeyDown(KeyCode.Z) && DonaldjumpCount == 1 && Dona == 2)//2단
        {
            //RetryChar.isGround = false;
            rigid2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            DonaldjumpCount = 2;
            //this.animator.SetBool("isRuning", true);
            this.animator.SetInteger("Dona", 3);
            this.animator.SetBool("2nd", false);
            this.audio3.Play();
            //yield return new WaitForSeconds(0.1f);
            Dona = 3;
            Check = Dona;
            Check2 = DonaldjumpCount;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            this.animator.SetInteger("Dona", 0);
            if (Dona == 2|| Dona == 3)
            {
                if (Dona == 3)
                {
                    this.audio4.Play();
                    Dona = 0;
                    //this.animator.SetBool("Magic", true);
                    this.animator.SetTrigger("Magic");
                    Magic = true;
                }
                Dona = 0;
            }
            //this.animator.SetBool("Magic", false);
        }
    }
}
