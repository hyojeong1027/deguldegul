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
    public float speed = 1.0f;
    public float backSpeed;

   // Transform playerTransform;
   // Vector3 Offset;



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
    


  // void LateUpdate()
  // {
  //     transform.position = playerTransform.position + Offset;
  // }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        float translateMove = speed * Time.deltaTime;
        rigid.AddForce(new Vector3(h* translateMove, 0, v* translateMove), ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isJump = false;
        }
        else if (collision.gameObject.tag == "Obstacle")
        {
            rigid.AddForce((transform.position - collision.transform.position).normalized * backSpeed);
        }
        else if (collision.gameObject.tag == "MoveFloor")
        {
             // playerTransform = GameObject.FindGameObjectWithTag("MoveFloor").transform;
             // Offset = transform.position - playerTransform.position;
             isJump = false;
       
        }


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            itemCount++;
            audio.Play();
            other.gameObject.SetActive(false);
            manager.GetItem(itemCount);
        }
       

        else if (other.tag == "FinishPoint")
        {
            if (itemCount == manager.totalItemCount)
            {
                if (manager.stage == 1)
                    SceneManager.LoadScene("Stage2");
                else if (manager.stage == 2)
                    SceneManager.LoadScene("Stage3");
                else if (manager.stage == 3)
                {
                    SceneManager.LoadScene("MainMenu");
                }
                
            }
            else
            {
                if (manager.stage == 1)
                    SceneManager.LoadScene("Stage1");
                else if(manager.stage == 2)
                    SceneManager.LoadScene("Stage2");
                else if(manager.stage == 3)
                    SceneManager.LoadScene("Stage3");
            }
        }
        
    }

    void OnTriggerStay(Collider other) // ¹°¸®Àû Ãæµ¹ÀÌ¾Æ´Ñ °ãÃÆ³ª ¾È°ãÃÆ³ª 
    {
        if(other.tag == "SuperJump")
        {
            rigid.AddForce(Vector3.up * 2, ForceMode.Impulse);
        }
    }
}


