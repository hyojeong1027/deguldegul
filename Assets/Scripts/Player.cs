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

        float translateMove = speed * Time.deltaTime;
        rigid.AddForce(new Vector3(h , 0, v), ForceMode.Impulse);
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
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            itemCount++;
            audio.Play();
            other.gameObject.SetActive(false);

        }
       

        else if (other.tag == "FinishPoint")
        {
            if (itemCount == manager.totalItemCount)
            {
                SceneManager.LoadScene(manager.stage + 1);
            }
            else
            {
                SceneManager.LoadScene(manager.stage);
            }
        }
        
    }

    void OnTriggerStay(Collider other) // ������ �浹�̾ƴ� ���Ƴ� �Ȱ��Ƴ� 
    {
        if(other.tag == "SuperJump")
        {
            rigid.AddForce(Vector3.up * 2, ForceMode.Impulse);
        }
    }
}


