using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * ��ʏ�ɃI�u�W�F�N�g�����݂��邩�𔻒�
 */
public class ScreenVisibilityChecker : MonoBehaviour
{
    private BoxCollider2D boxCollider;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
    }

    public bool IsObjectOnScreen()
    {
        if (boxCollider == null) return false;

        //! �R���C�_�[�̒��S�_�����[���h���W����r���[�|�[�g���W�ɕϊ�
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(boxCollider.bounds.center);

        //! �r���[�|�[�g���W��(0,0)����(1,1)�͈͓̔��ɂ��邩�𔻒�
        bool onScreen = viewportPos.x >= 0 && viewportPos.x <= 1 &&
                        viewportPos.y >= 0 && viewportPos.y <= 1;

        return onScreen;
    }
}