using System.Collections;
using UnityEngine;

public class Buttonscroll : MonoBehaviour
{
    public GameObject objectToMove;        // 移動させたいオブジェクト
    public Vector3 moveAmount = new Vector3(0, 1.823f, 0); // 移動量（例：Y方向に+100）
    public float moveDuration = 0.5f;      // 移動時間（秒）

    private bool isMoving = false;

    public void Move()
    {
        if (objectToMove != null && !isMoving)
        {
            StartCoroutine(SmoothMove());
        }
        else if (objectToMove == null)
        {
            Debug.LogError("移動対象のオブジェクトが設定されていません。");
        }
    }

    private IEnumerator SmoothMove()
    {
        isMoving = true;

        Vector3 startPos = objectToMove.transform.position;
        Vector3 endPos = startPos + moveAmount;

        float elapsed = 0f;

        while (elapsed < moveDuration)
        {
            float t = elapsed / moveDuration;
            objectToMove.transform.position = Vector3.Lerp(startPos, endPos, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        objectToMove.transform.position = endPos;
        Debug.Log($"オブジェクトをスライド移動しました: {endPos}");

        isMoving = false;
    }
}
