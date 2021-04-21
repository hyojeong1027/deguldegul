using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody rigid;
    public float jumpPower; 
    bool isJump;
    public int itemCount;
    AudioSource audio;
    public GameManagerLogic manager;

    void Awake()
    {
        isJump = false; 
        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJump)
        {
            isJump = true;
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);
    } 

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor") 
            isJump = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Item")
        {
            itemCount++;
            audio.Play();
            other.gameObject.SetActive(false);
            
        }
        else if(other.tag == "FinishPoint")
        {
            if(itemCount == manager.totalItemCount)
            {
                SceneManager.LoadScene("Stage_01");
            }
            else
            {
                SceneManager.LoadScene("Tutorial");
            }
        }
    }
}
