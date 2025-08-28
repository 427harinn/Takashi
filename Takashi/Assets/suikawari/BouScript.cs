using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BouScript : MonoBehaviour
{
    [Header("自動移動設定")]
    public float initialSpeed = 18f;        // 最初は速く
    public float minSpeed = 3f;             // 最低速度（これ以下にはならない）
    public float slowdownDuration = 20f;    // 何秒かけて遅くなるか
    public float moveRange = 3f;

    [Header("スコア判定")]
    public Transform targetCenter;
    public float perfectRange = 0.2f;
    public Text scoreText;

    [SerializeField] private GameObject[] hitobj;
    private AudioSource audioSource;
    public AudioSource bgm;

    private float centerX;
    private float gameStartTime;
    private bool isMoving = true;
    private float currentSpeed;

    void Start()
    {
        centerX = transform.position.x;
        audioSource = GetComponent<AudioSource>();
        gameStartTime = Time.time;
        currentSpeed = initialSpeed;
    }

    void Update()
    {
        if (!isMoving) return;

        // 時間経過に応じて速度を減衰させる
        float elapsed = Time.time - gameStartTime;
        float t = Mathf.Clamp01(elapsed / slowdownDuration);
        currentSpeed = Mathf.Lerp(initialSpeed, minSpeed, t);

        float x = centerX + Mathf.Sin(Time.time * currentSpeed) * moveRange;
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }

    public void Hit()
    {
        if (targetCenter == null)
        {
            Debug.LogWarning("ターゲット中心が設定されていません！");
            return;
        }

        isMoving = false;

        // 共通処理
        float elapsedTime = Time.time - gameStartTime;
        float dx = Mathf.Abs(transform.position.x - targetCenter.position.x);

        // 時間のスコア補正係数（例：5秒以内で100%、10秒で50%、20秒以上は20%）
        float timeMultiplier = Mathf.Clamp01(1f - (elapsedTime / 20f));
        float timeScoreRate = Mathf.Lerp(0.2f, 1f, timeMultiplier); // 0.2〜1.0の補正

        int baseScore;
        string result;

        // 中心との距離でスコア決定
        if (dx <= perfectRange)
        {
            baseScore = 100;
            result = "じゃーん";
            hitobj[2].SetActive(true);
        }
        else if (dx <= perfectRange + 0.1f)
        {
            baseScore = 90;
            result = "じゃーん";
            hitobj[2].SetActive(true);
        }
        else if (dx <= perfectRange + 0.2f)
        {
            baseScore = 80;
            result = "ぱかっ";
            hitobj[1].SetActive(true);
        }
        else
        {
            baseScore = 70;
            result = "ぱかっ";
            hitobj[1].SetActive(true);
        }

        int finalScore = Mathf.RoundToInt(baseScore * timeScoreRate);
        GManager.instance.score[GManager.instance.scenenumber - 1] = finalScore;

        Debug.Log($"[結果] {result} | 距離: {dx:F2} | 時間: {elapsedTime:F2}s | 補正率: {timeScoreRate:F2} | 最終スコア: {finalScore}");

        // UIや演出
        hitobj[0].SetActive(false);
        bgm.enabled = false;
        audioSource.Play();

        if (scoreText != null)
        {
            scoreText.text = result;
        }

        if (GManager.instance.scoreattack)
            Invoke("loadscene2", 2.0f);
        else
            Invoke("loadscene", 1.0f);
    }

    void loadscene()
    {
        SceneManager.LoadScene("nikki_suika");
    }

    void loadscene2()
    {
        GManager.instance.scenenumber = 2;
        SceneManager.LoadScene("semiScene");
    }
}
