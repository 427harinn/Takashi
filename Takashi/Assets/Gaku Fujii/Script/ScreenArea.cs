using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

/*
 * ��ʊO�ɏo���I�u�W�F�N�g������
 */
public class ScreenArea : MonoBehaviour
{
    private bool is_object_exist_;

    private void Start()
    {
        is_object_exist_ = false;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        is_object_exist_ = false;
        Destroy(collision.gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        is_object_exist_ = true;
    }

    public bool IsObjectExist()
    {
        return is_object_exist_;
    }
}
