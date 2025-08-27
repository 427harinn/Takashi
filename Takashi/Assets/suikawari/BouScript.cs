using UnityEngine;
using UnityEngine.UI;

public class BouScript : MonoBehaviour
{
    [Header("自動移動設定")]
    public float speed = 5f;             // 移動速度（大きいほど速く往復）
    public float moveRange = 3f;         // 中心からの左右移動距離（±）

    [Header("スコア判定")]
    public Transform targetCenter;       // 判定用（スイカ中心）
    public float perfectRange = 0.2f;
    public float goodRange = 0.5f;
    public Text scoreText;

    private int totalScore = 0;
    private float centerX;

    void Start()
    {
        // 初期位置を中心として記録
        centerX = transform.position.x;
    }

    void Update()
    {
        // 自動で高速往復（Sin波）
        float x = centerX + Mathf.Sin(Time.time * speed) * moveRange;
        transform.position = new Vector3(x, transform.position.y, transform.position.z);

    }

    public void Hit()
    {
        if (targetCenter == null)
        {
            Debug.LogWarning("ターゲット中心が設定されていません！");
            return;
        }

        float dx = Mathf.Abs(transform.position.x - targetCenter.position.x);
        string result;
        int score;

        if (dx <= perfectRange)
        {
            result = "PERFECT!";
            score = 100;
        }
        else if (dx <= goodRange)
        {
            result = "GOOD!";
            score = 60;
        }
        else
        {
            result = "MISS...";
            score = 0;
        }

        totalScore += score;

        Debug.Log($"判定: {result}（距離: {dx:F2}） スコア: {score} 合計: {totalScore}");

        if (scoreText != null)
        {
            scoreText.text = $"Score: {totalScore}\n{result}";
        }
    }
}
