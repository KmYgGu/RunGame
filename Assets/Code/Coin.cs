using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
    public AudioSource audio1;
    public AudioClip CoinSound;
    Animator animator;
    // Use this for initialization
    void Start () {
        this.audio1 = this.gameObject.AddComponent<AudioSource>();
        this.audio1.clip = this.CoinSound;
        this.animator = GetComponent<Animator>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Score_Manager.score += 100;
            this.audio1.Play();
            this.animator.SetBool("isEat", true);
            Destroy(gameObject, 0.5f);
        }
    }
}
