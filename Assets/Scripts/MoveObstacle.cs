using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    public float startTime;
    public float minX, maxX;
    public float moveSpeed;
    private int sign = -1;
    void Update()
    {
        if(Time.time >= startTime)
        {
            //이동 로직처리 
           
            if(transform.position.x <=minX || transform.position.x >= maxX)
            {
                sign *= -1;
            }
            transform.position += new Vector3(moveSpeed * Time.deltaTime * sign, 0, 0);
        }
    }
}
