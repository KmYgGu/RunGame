using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiterGunAni : MonoBehaviour {
    Animator animator;

    void Start () {
        this.animator = GetComponent<Animator>();
    }
	
	void Update () {
        this.animator.SetFloat("Gun2", RetryChar.Harmo % 15);
        /*if (RetryChar.Shooting == true)
        {
            this.animator.SetBool("isShooting", true);
            this.animator.SetFloat("123456", RetryChar.Harmo % 15);
        }
        if (RetryChar.Shooting == false)
        {
            Invoke("Anistop", 3f);
            //this.animator.SetBool("isShooting", false);
        }*/
    }
    void Anistop()
    {
        this.animator.SetBool("isShooting", false);
    }

}
