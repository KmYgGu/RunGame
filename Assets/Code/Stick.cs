using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour {
    public AudioSource audio1;
    public AudioClip StickSound;
    // Use this for initialization
    void Start () {
        this.audio1 = this.gameObject.AddComponent<AudioSource>();
        this.audio1.clip = this.StickSound;
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < -30)
            Destroy(gameObject);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            RetryChar.TShlied = true;
            this.audio1.Play();
            Destroy(gameObject, 0.5f);
        }
    }
}
