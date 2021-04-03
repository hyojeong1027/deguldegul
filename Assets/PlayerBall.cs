using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBall : MonoBehaviour
{
    public float jumpPower; //public붙이면 초기화 굳이 하지않아도 됨 (특히 숫자같은것) -> 그럼 스크립트 밖에서 inspector창에서 바꿀수있음 자유롭게 
    Rigidbody rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();

    }

    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");   // input가서 wasd →←↑↓바꿔야함
        float v = Input.GetAxisRaw("Vertical");                                         // play눌ㄹ렀을때 좀 저화질처럼보임 이거 수업시간에 다뤘던거같은데 다시돌려보기
        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);

    }


}
