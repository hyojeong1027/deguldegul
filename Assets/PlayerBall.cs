using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBall : MonoBehaviour
{
    public float jumpPower; //public���̸� �ʱ�ȭ ���� �����ʾƵ� �� (Ư�� ���ڰ�����) -> �׷� ��ũ��Ʈ �ۿ��� inspectorâ���� �ٲܼ����� �����Ӱ� 
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
        float h = Input.GetAxisRaw("Horizontal");   // input���� wasd �����ٲ����
        float v = Input.GetAxisRaw("Vertical");                                         // play���������� �� ��ȭ��ó������ �̰� �����ð��� �ٷ���Ű����� �ٽõ�������
        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);

    }


}
