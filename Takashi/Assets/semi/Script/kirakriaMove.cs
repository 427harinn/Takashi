using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kirakriaMove : MonoBehaviour
{
    [SerializeField] GameObject kirakira1;   // 結果表示用のテキスト
    [SerializeField] GameObject kirakira2;   // 結果表示用のテキスト
    Vector3 targetPsision1;
    Vector3 targetPsision2;

    bool is_move = false;

    public void SetMoveFlag(bool flag)
    {
        is_move = flag;
    }

    // Start is called before the first frame update
    void Start()
    {
        targetPsision1 = new Vector3(1.8f, 3.2f, 0.0f);
        targetPsision2 = new Vector3(-1.8f, 1.7f, 0.0f);

    }

    // Update is called once per frame
    void Update()
    {
        if(is_move)
        {
            kirakira1.transform.position = Vector3.MoveTowards(kirakira1.transform.position, targetPsision1, 0.5f);
            kirakira2.transform.position = Vector3.MoveTowards(kirakira2.transform.position, targetPsision2, 0.5f);
        }
       

    }
}
