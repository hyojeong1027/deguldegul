using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperJump : MonoBehaviour
{
    
    Rigidbody rigid;
    AudioSource audio;

    void Awake()
    {

        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            audio.Play();
        }

    }

}
