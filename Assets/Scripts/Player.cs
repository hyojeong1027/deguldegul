using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rigid;
    public float jumpPower; 
    bool isJump;
    public int itemCount;

    void Awake()
    {
        isJump = false; 
        rigid = GetComponent<Rigidbody>();
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
        if (collision.gameObject.name == "Plane") 
            isJump = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.name == "Item")
        {
            itemCount++;
            other.gameObject.SetActive(false);
        }
    }
}
