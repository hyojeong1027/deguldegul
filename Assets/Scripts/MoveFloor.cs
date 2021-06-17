using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : MonoBehaviour
{
    public float startTime_F;
    public float minZ, maxZ;

    public float moveSpeed_F;
    private int sign_F = -1;
    void Update()
    {
        if (Time.time >= startTime_F)
        {
            transform.position += new Vector3(0, 0, moveSpeed_F * Time.deltaTime * sign_F);

            if (transform.position.z <= minZ || transform.position.z >= maxZ)
            {
                sign_F *= -1;
            }
           
        }
    }
}
