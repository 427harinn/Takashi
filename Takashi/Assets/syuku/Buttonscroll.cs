using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttonscroll : MonoBehaviour
{
    public GameObject objectTomove;//移動させたいオブジェクト
    public Vector3 moveAmount;// ボタンを押すごとに移動する量

    public void Move()
    {
        if(objectTomove != null) 
        {
            //オブジェクトの座標を移動させる
            objectTomove.transform.position += moveAmount;
            Debug.Log($"オブジェクトが移動しました: {objectTomove.transform.position}");
        
        }
        else 
        {
            Debug.LogError("移動させるオブジェクトが指定されていません。");
        }
    }

}
