using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutTouch : MonoBehaviour {
    public AudioSource audio1;
    public AudioClip Oh;
    // Use this for initialization
    void Start () {
        this.audio1 = this.gameObject.AddComponent<AudioSource>();
        this.audio1.clip = this.Oh;
        this.audio1.loop = false;

    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(10, 0, 0);
		
	}
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Player") && (Curser.i == 1 && Curser.j == 3))
        {
            RetryChar.Boom++;
            audio1.Play();
            //gameObject.SetActive(false);
            Destroy(gameObject, 0.8f);
            
        }
    }
}
