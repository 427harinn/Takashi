using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    

    //生成したいPrefabをInspectorから設定する変数
    public GameObject objectTospawn;
    //オブジェクトを生成する位置
    public Vector3 spawnPosition;

    public void spawnobject()
    {
        //objectTospawnが設定されているか確認
        if(objectTospawn != null) 
        {
            //指定した位置にオブジェクトを作成
            Instantiate(objectTospawn, transform);
        }
        else 
        {
            Debug.LogError("生成するオブジェクトが設定されていません！");
        }
    }
}
