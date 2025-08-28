using UnityEngine;
using UnityEngine.UI;

public class MathPuzzleController : MonoBehaviour
{
    [Header("画像リスト（0〜9, +, -）")]
    public Sprite[] numberSprites; // 0〜9 の画像
    public Sprite plusSprite;
    public Sprite minusSprite;

    [Header("Image参照（プレハブ内）")]
    public Image leftImage;
    public Image rightImage;
    public Image middleImage;
    public Image answerImage;

    private int leftValue;
    private int rightValue;
    private int answerValue;
    private string operatorSymbol;

    public int CurrentAnswer => answerValue;


    private void Start()
    {
        // 自分をGameManagerに登録（最後に生成されたものが有効）
        GameManager_puzzle.Instance.SetActivePuzzle(this);
        GeneratePuzzle();
    }

    public void GeneratePuzzle()
    {
        GameManager_puzzle.Instance.nowNumber += 1; // nowNumberを1にリセット
        operatorSymbol = Random.value > 0.5f ? "+" : "-";

        if (operatorSymbol == "+")
        {
            leftValue = Random.Range(0, 10);
            rightValue = Random.Range(0, 10 - leftValue);
            answerValue = leftValue + rightValue;
        }
        else
        {
            leftValue = Random.Range(0, 10);
            rightValue = Random.Range(0, leftValue + 1);
            answerValue = leftValue - rightValue;
        }

        // 画像を反映
        leftImage.sprite = numberSprites[leftValue];
        rightImage.sprite = numberSprites[rightValue];
        middleImage.sprite = operatorSymbol == "+" ? plusSprite : minusSprite;
        answerImage.sprite = null;
    }

    public void ShowAnswerSprite()
    {
        if (answerValue >= 0 && answerValue < numberSprites.Length)
        {
            answerImage.sprite = numberSprites[answerValue];
        }
    }
}
