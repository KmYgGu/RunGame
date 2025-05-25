using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV : MonoBehaviour {
    Rigidbody2D rigid2D;
    Animator animator;
    public AudioSource audio1;
    public AudioClip slideSound;
    public AudioSource audio2;
    public AudioClip JumpSound;
    public AudioSource audio3;
    public AudioClip AttackSound;
    public float jumpForce = 1;
    public static int LVjumpCount;
    public bool isSlideSound;
    public GameObject Attack;//스탠드 돌리는 오브젝트
    public GameObject Stand;//공격
    public bool Delay; //공격 딜레이

    // Use this for initialization
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
        LVjumpCount = 0;
    }
	
	// Update is called once per frame
	void Update () {
        CharControl2();
    }

    public void CharControl2()
    {
        if (Input.GetKey(KeyCode.X) && (!(LVjumpCount == 0)) && Delay == false)//(LVjumpCount >= 1)
        {
            Delay = true;
            this.animator.SetTrigger("Attack");
            Stand.gameObject.SetActive(true);
            //Stand.GetComponent<SpriteRenderer>().enabled = true;
            //Standani = 1;
            //GameObject.stand.animaton.SetBool("Go", true);
            //this.animator.ResetTrigger("Attack");
            Invoke("AttackSlow", 0.5f);
            this.audio3.Play();
            Invoke("AttackDelay", 1f);
        }

        if (RetryChar.isGround)
        {
            Jump2();
            if (LVjumpCount == 2)//점프 횟수 : 2 즉 이단 점프 다했을때
            {
                RetryChar.isGround = false;
                this.audio2.Play();
                //this.animator.SetTrigger("JumpTrigger");
                //this.animator.SetInteger("Jump", 1);
            }
        }
        if (Input.GetKey(KeyCode.X) && (LVjumpCount == 0))//땅에서 하는 슬라이딩
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
        else
        {
            Attack.gameObject.SetActive(false);
            this.animator.SetBool("isSiding", false);
            this.animator.SetBool("isRuning", true);
            isSlideSound = false;
        }
    }

    public void Jump2()
    {
        if (Input.GetKeyDown(KeyCode.Z))//점프 && (LVjumpCount == 0)
        {
            this.animator.ResetTrigger("Attack");
            rigid2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            LVjumpCount++;//점프횟수 추가
            //.animator.SetBool("isRuning", true);
            this.animator.SetInteger("Jump", 1);
            //this.audio2.Play();
        }
        /*if (Input.GetKeyDown(KeyCode.Z) && (LVjumpCount >= 1))//Z키를 눌렀을 때
        {
            rigid2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            LVjumpCount++;
            //this.animator.SetInteger("Jump", 1);
            //this.audio2.Play();
        }*/
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
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
        //this.audio3.Play();
        //Delay = false;
    }

    public void AttackDelay()
    {
        Delay = false;
    }

}
