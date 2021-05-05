using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Rigidbody rigid;
    AudioSource audio;

    void Awake()
    {

        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audio.Play();
        }
        
    }
}
