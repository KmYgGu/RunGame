using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandAttack : MonoBehaviour {
    public AudioSource audio1;
    public AudioClip AttackSound;
    // Use this for initialization
    void Start () {
        this.audio1 = this.gameObject.AddComponent<AudioSource>();
        this.audio1.clip = this.AttackSound;
        this.audio1.loop = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            this.audio1.Play();
            collision.gameObject.SetActive(false);
            //Invoke("MusicStop", 0.7f);
        }
        if (!(collision.tag == "Wall"))
        {
            this.audio1.Stop();
        }
    }
    public void MusicStop()
    {
        this.audio1.Stop();
    }
}
