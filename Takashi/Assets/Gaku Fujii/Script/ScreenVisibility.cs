using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 画面上にオブジェクトが存在するかを判定
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

        //! コライダーの中心点をワールド座標からビューポート座標に変換
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(boxCollider.bounds.center);

        //! ビューポート座標が(0,0)から(1,1)の範囲内にあるかを判定
        bool onScreen = viewportPos.x >= 0 && viewportPos.x <= 1 &&
                        viewportPos.y >= 0 && viewportPos.y <= 1;

        return onScreen;
    }
}