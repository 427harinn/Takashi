using System.Collections;
using UnityEngine;

public class Buttonscroll : MonoBehaviour
{
    public GameObject objectToMove;        // 移動させたいオブジェクト
    public Vector3 moveAmount = new Vector3(0, 1.823f, 0); // 移動量
    public float moveDuration = 0.5f;      // 移動時間

    private Coroutine moveCoroutine;
    private Vector3 currentTargetPos;

    public void Move()
    {
        if (GameManager_puzzle.Instance.finishflag) return;

        if (objectToMove == null)
        {
            Debug.LogError("移動対象のオブジェクトが設定されていません。");
            return;
        }

        // 移動中なら即座に終了し、目的地にスナップさせる
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
            objectToMove.transform.position = currentTargetPos;
            Debug.Log($"移動中断して即座に移動完了: {currentTargetPos}");
        }

        // 新しい目的地を計算してコルーチン開始
        moveCoroutine = StartCoroutine(SmoothMove());
    }

    private IEnumerator SmoothMove()
    {
        Vector3 startPos = objectToMove.transform.position;
        currentTargetPos = startPos + moveAmount;

        float elapsed = 0f;

        while (elapsed < moveDuration)
        {
            float t = elapsed / moveDuration;
            objectToMove.transform.position = Vector3.Lerp(startPos, currentTargetPos, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        objectToMove.transform.position = currentTargetPos;
        Debug.Log($"オブジェクトをスライド移動しました: {currentTargetPos}");

        moveCoroutine = null;
    }
}
