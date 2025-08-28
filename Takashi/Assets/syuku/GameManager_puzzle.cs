using UnityEngine;

public class GameManager_puzzle : MonoBehaviour
{
    public static GameManager_puzzle Instance { get; private set; }

    public MathPuzzleController CurrentPuzzle { get; private set; }
    [SerializeField] public GameObject finishUI;

    [Header("Progress")]
    public int correctAnswers = 0;       // 正解数
    public int nowNumber = 0;            // 回答済み数
    public int totalQuestions = 10;      // 全問題数（終了判定に使用）
    public bool finishflag = false;

    [Header("Timer")]
    [Tooltip("ゲーム開始からの経過秒。Updateで自動更新（読み取り用）")]
    public float elapsedTime = 0f;
    private float gameStartTime = 0f;
    private bool timerRunning = false;

    [Header("Time Bonus Thresholds (sec)")]
    public float bonus10_sec = 15f;      // これ以下なら +10
    public float bonus5_sec = 25f;      // これ以下なら +5（15より遅く25以内）

    [Header("Scoring Policy")]
    [Tooltip("全問不正解時の基礎点。0にすれば時間ボーナスも掛からない設計になる")]
    public int baseScoreWhenAllWrong = 0; // ←旧:70 を 0 に
    [Tooltip("段階基礎スコア（例: >=7, >=3, >=1 の境界）。必要に応じて調整")]
    public int scoreIfAllCorrect = 100;
    public int scoreIf7Plus = 90;
    public int scoreIf3Plus = 80;
    public int scoreIf1Plus = 70;

    private void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
        StartTimer();
    }

    private void Update()
    {
        if (timerRunning) elapsedTime = Time.time - gameStartTime;
        if (!finishflag) TryFinalizeScore();
    }

    public void SetActivePuzzle(MathPuzzleController puzzle) => CurrentPuzzle = puzzle;

    // ===== Timer =====
    public void StartTimer()
    {
        gameStartTime = Time.time;
        elapsedTime = 0f;
        timerRunning = true;
    }

    public void StopTimer()
    {
        if (!timerRunning) return;
        timerRunning = false;
        elapsedTime = Time.time - gameStartTime;
    }

    // ===== Finalize =====
    private void TryFinalizeScore()
    {
        if (nowNumber < totalQuestions) return;   // まだ終わってない

        // 終了処理
        StopTimer();

        // --- 基礎スコア（正解数のみで決定）---
        int baseScore;
        if (correctAnswers >= totalQuestions)
            baseScore = scoreIfAllCorrect;             // 100
        else if (correctAnswers >= 7)
            baseScore = scoreIf7Plus;                  // 90
        else if (correctAnswers >= 3)
            baseScore = scoreIf3Plus;                  // 80
        else if (correctAnswers >= 1)
            baseScore = scoreIf1Plus;                  // 70
        else
            baseScore = baseScoreWhenAllWrong;         // 0（←全問ミスの救済カット）

        // --- 時間ボーナス（正解率でスケーリング）---
        // 全問不正解なら倍率が0になり、ボーナスは一切付かない
        float accuracy = totalQuestions > 0 ? (float)correctAnswers / (totalQuestions - 2) : 0f;

        int rawTimeBonus = 0;
        if (elapsedTime <= bonus10_sec) rawTimeBonus = 10;
        else if (elapsedTime <= bonus5_sec) rawTimeBonus = 5;

        int timeBonus = Mathf.RoundToInt(rawTimeBonus * accuracy); // ★ここが肝

        int finalScore = Mathf.Clamp(baseScore + timeBonus, 0, 100);

        // 保存
        if (GManager.instance != null && GManager.instance.score != null)
        {
            int idx = Mathf.Clamp(GManager.instance.scenenumber - 1, 0, GManager.instance.score.Length - 1);
            GManager.instance.score[idx] = finalScore;
        }

        Debug.Log(
            $"[PUZZLE FINISH] correct={correctAnswers}/{totalQuestions}, " +
            $"elapsed={elapsedTime:F2}s, base={baseScore}, rawBonus={rawTimeBonus}, " +
            $"accuracy={accuracy:F2}, appliedBonus={timeBonus}, final={finalScore}"
        );

        finishflag = true;
        finishUI.SetActive(true);
        if (GManager.instance.scoreattack)
        {
            Invoke("sceneload2", 2f);
        }
        else
        {
            Invoke("loadscene", 2f);
        }
    }

    public void loadscene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("nikki_syuku");
    }

    public void sceneload2()
    {
        GManager.instance.scenenumber = 6;
        UnityEngine.SceneManagement.SceneManager.LoadScene("resultScene");
    }
}
