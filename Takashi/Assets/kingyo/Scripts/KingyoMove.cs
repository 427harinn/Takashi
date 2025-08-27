using UnityEngine;

public class KingyoMove : MonoBehaviour
{
    private Vector3 moveDirection;
    private float moveSpeed = 1.0f;

    private float minX = -4.0f;
    private float maxX = 4.0f;
    private float minY = -5.0f;
    private float maxY = 5.0f;

    bool isCaught = false;

    void Start()
    {
        // ランダムな角度で初期回転（0°が上向き）
        float angle = Random.Range(0f, 360f);
        transform.localRotation = Quaternion.Euler(0, 0, angle);

        // 回転に応じた移動方向を決定（transform.upを使用）
        moveDirection = transform.up;
    }

    void Update()
    {
        if (isCaught) return;
        // 進行方向へ移動（上方向ベース）
        transform.localPosition += moveDirection * moveSpeed * Time.deltaTime;

        Vector3 pos = transform.localPosition;
        bool bounced = false;

        // 範囲外で反転（左右 or 上下）
        if (pos.x < minX || pos.x > maxX)
        {
            moveDirection.x *= -1;
            bounced = true;
        }

        if (pos.y < minY || pos.y > maxY)
        {
            moveDirection.y *= -1;
            bounced = true;
        }

        // 跳ね返ったら向きを更新
        if (bounced)
        {
            float newAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            // transform.up = 0°が上なので +90°して調整（X軸を基準にしていたAtan2 → Y軸基準に変換）
            transform.localRotation = Quaternion.Euler(0, 0, newAngle - 90f);
        }
    }

    public void Caught()
    {
        this.gameObject.transform.parent.GetComponent<RandomKingyo>().CreateKingyo();
        this.transform.GetChild(0).GetComponent<Animator>().enabled = false;
        isCaught = true;
        // 捕まえた直後に大きくする
        StartCoroutine(CaughtEffect());
    }

    private System.Collections.IEnumerator CaughtEffect()
    {
        Vector3 originalScale = transform.localScale;
        transform.localScale = originalScale * 1.5f;

        // 数秒後に削除
        yield return new WaitForSeconds(1.0f);

        Destroy(gameObject);
    }
}
