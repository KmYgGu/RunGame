using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MacMove : MonoBehaviour {
    Vector3 RightMove = new Vector3(10, 0, 0);
    public AudioSource audio1;
    public AudioClip MSound;
    // Use this for initialization
    void Start () {
        this.audio1 = this.gameObject.AddComponent<AudioSource>();
        this.audio1.clip = this.MSound;
        this.audio1.loop = false;
    }
	
	// Update is called once per frame
	void Update () {
        Gun();
    }

    void Gun()
    {
        float fMove = (Time.deltaTime) * 1;
        transform.Translate(RightMove * fMove);
        if (transform.position.x > 12)
            Destroy(gameObject);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            this.audio1.Play();
            Destroy(collision.gameObject);
        }
    }
}
