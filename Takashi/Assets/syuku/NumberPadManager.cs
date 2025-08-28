using UnityEngine;
using UnityEngine.UI;

public class NumberPadManager : MonoBehaviour
{
    public GameObject correctEffect;   // 正解時に表示するエフェクトなど
    private string currentInput = "";

    [Header("正解/不正解のプレハブ")]
    [SerializeField] private GameObject correctPrefab; // 正解マークのPrefab
    [SerializeField] private GameObject wrongPrefab;   // バツマークのPrefab

    public void OnNumberButtonPressed(string number)
    {
        currentInput += number;

        // 押された数字を画像として Answer に表示
        if (int.TryParse(number, out int digit))
        {
            MathPuzzleController puzzle = GameManager_puzzle.Instance.CurrentPuzzle;
            if (puzzle != null && digit >= 0 && digit < puzzle.numberSprites.Length)
            {
                puzzle.answerImage.sprite = puzzle.numberSprites[digit];
            }
        }

        CheckAnswer();
    }

    private void CheckAnswer()
    {
        if (!int.TryParse(currentInput, out int parsedValue)) return;

        MathPuzzleController puzzle = GameManager_puzzle.Instance.CurrentPuzzle;

        if (puzzle == null)
        {
            Debug.LogError("現在有効なパズルが見つかりません！");
            return;
        }

        int correctAnswer = puzzle.CurrentAnswer;
        Debug.Log($"入力: {parsedValue}, 正解: {correctAnswer}");

        if (parsedValue == correctAnswer)
        {
            Debug.Log("正解！");

            // ✅ Baseオブジェクトの子として正解マークをInstantiate
            Instantiate(correctPrefab, puzzle.transform);

            puzzle.ShowAnswerSprite();

            if (correctEffect != null)
                correctEffect.SetActive(true);

            currentInput = "";
            GameManager_puzzle.Instance.correctAnswers += 1;
        }
        else if (currentInput.Length >= 1)
        {
            Debug.Log("不正解。リセット");

            // ✅ Baseオブジェクトの子としてバツマークをInstantiate
            Instantiate(wrongPrefab, puzzle.transform);

            currentInput = "";
        }
    }

    public void ClearInput()
    {
        currentInput = "";
    }
}
