using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttonscroll : MonoBehaviour
{
    public GameObject objectTomove;//�ړ����������I�u�W�F�N�g
    public Vector3 moveAmount;// �{�^�����������ƂɈړ������

    public void Move()
    {
        if(objectTomove != null) 
        {
            //�I�u�W�F�N�g�̍��W���ړ�������
            objectTomove.transform.position += moveAmount;
            Debug.Log($"�I�u�W�F�N�g���ړ����܂���: {objectTomove.transform.position}");
        
        }
        else 
        {
            Debug.LogError("�ړ�������I�u�W�F�N�g���w�肳��Ă��܂���B");
        }
    }

}
