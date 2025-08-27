using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class semiButtonScript : MonoBehaviour
{
    public bool pushButton = false; // �{�^���������ꂽ���ǂ���

    // �{�^���������ꂽ�ꍇ�A����Ăяo�����֐�
    public void OnClick()
    {
        Debug.Log("つかまえた!");  // ���O���o��
        pushButton = true;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
