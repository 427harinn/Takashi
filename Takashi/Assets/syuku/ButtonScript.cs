using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    

    //����������Prefab��Inspector����ݒ肷��ϐ�
    public GameObject objectTospawn;
    //�I�u�W�F�N�g�𐶐�����ʒu
    public Vector3 spawnPosition;

    public void spawnobject()
    {
        //objectTospawn���ݒ肳��Ă��邩�m�F
        if(objectTospawn != null) 
        {
            //�w�肵���ʒu�ɃI�u�W�F�N�g���쐬
            Instantiate(objectTospawn, transform);
        }
        else 
        {
            Debug.LogError("��������I�u�W�F�N�g���ݒ肳��Ă��܂���I");
        }
    }
}
