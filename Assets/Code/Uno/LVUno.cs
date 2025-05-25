using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class LVUno : MonoBehaviour {

    SerialPort sp = CurserUno.sp;
    Rigidbody2D rigid2D;
    Animator animator;
    public AudioSource audio1;
    public AudioClip slideSound;
    public AudioSource audio2;
    public AudioClip JumpSound;
    public AudioSource audio3;
    public AudioClip AttackSound;
    public float jumpForce = 1;
    public static int UnoLVjumpCount;
    public bool isSlideSound;
    public GameObject Attack;//스탠드 돌리는 오브젝트
    public GameObject Stand;//공격
    public bool Delay; //공격 딜레이

    void Start () {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.audio1 = this.gameObject.AddComponent<AudioSource>();
        this.audio1.clip = this.slideSound;
        this.audio1.loop = false;
        this.audio2 = this.gameObject.AddComponent<AudioSource>();
        this.audio2.clip = this.JumpSound;
        this.audio2.loop = false;
        this.audio3 = this.gameObject.AddComponent<AudioSource>();
        this.audio3.clip = this.AttackSound;
        this.audio3.loop = false;
        RetryChar.isGround = false;//땅에 착지한게 참
        isSlideSound = false;
        Attack.gameObject.SetActive(false);
        Delay = false;
        UnoLVjumpCount = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (sp.IsOpen)
        {
            try
            {
                CharMove(sp.ReadByte());
                print(sp.ReadByte());//한번 주석처리해볼까?
            }
            catch (System.Exception)
            {

            }
        }
    }

    void CharMove(int distance)
    {
        if ((distance == 1) && (!(UnoLVjumpCount == 0)) && Delay == false)// 피격당해도 슬라이딩 안하고 공격하게 변경
        {
            Delay = true;
            this.animator.SetTrigger("Attack");
            Stand.gameObject.SetActive(true);
            Invoke("AttackSlow", 0.5f);
            this.audio3.Play();
            Invoke("AttackDelay", 1f);
        }

        if (RetryChar.isGround)
        {

            if (distance == 1 && (UnoLVjumpCount == 0)) //첫번째 센서 : 슬라이딩
            {
                this.animator.SetInteger("Jump", 0);
                this.animator.ResetTrigger("Attack");
                this.animator.SetBool("isSiding", true);
                this.animator.SetBool("isRuning", false);
                Attack.gameObject.SetActive(true);
                if (isSlideSound == false)
                {
                    this.audio1.Play();
                    isSlideSound = true;
                }
            }
            if (!(distance == 1))//슬라이딩 else
            {
                Attack.gameObject.SetActive(false);
                this.animator.SetBool("isSiding", false);
                this.animator.SetBool("isRuning", true);
                isSlideSound = false;
            }
            if ((distance == 2) && (UnoLVjumpCount == 0)) //두번째 센서 : 점프
            {
                this.animator.ResetTrigger("Attack");
                rigid2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                UnoLVjumpCount++;
                this.animator.SetInteger("Jump", 1);
                //this.animator.SetBool("isRuning", true);
                //this.audio2.Play();
            }
            if (distance == 3) //세번째 센서 : 2단점프
            {
                this.animator.ResetTrigger("Attack");
                rigid2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                UnoLVjumpCount++;
                this.animator.SetInteger("Jump", 1);
                //this.animator.SetBool("isRuning", true);
                //this.audio2.Play();
                if (UnoLVjumpCount == 2)
                {
                    RetryChar.isGround = false;
                    this.audio2.Play();

                }
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            this.animator.ResetTrigger("Attack");
            Stand.gameObject.SetActive(false);
            this.animator.SetInteger("Jump", 0);
            Delay = false;
        }
    }

    public void AttackSlow() //공격복구
    {
        this.animator.ResetTrigger("Attack");
        Stand.gameObject.SetActive(false);
        //Delay = false;
    }

    public void AttackDelay()
    {
        Delay = false;
    }
}
