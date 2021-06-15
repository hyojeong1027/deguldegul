using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    public float startTime;
    public float minX, maxX;
    public float moveSpeed;
    private int sign = -1;

  // private void OnCollisionEnter(Collision collision)
  // {
  //     if(collision.transform.CompareTag("Player"))
  //     {
  //         collision.transform.SetParent(transform); 
  //     }
  // }
  // private void OnCollisionExit(Collision collision)
  // {
  //     if (collision.transform.CompareTag("Player"))
  //     {
  //         collision.transform.SetParent(null);
  //     }
  // }
    void Update()
    {
        if(Time.time >= startTime)
        {
            //이동 로직처리 
            transform.position += new Vector3(moveSpeed * Time.deltaTime*sign,0,0);
            if(transform.position.x <=minX || 
                transform.position.x >= maxX)
            {
                sign *= -1;
            }
        }
    }
}
