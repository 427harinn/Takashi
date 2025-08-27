using UnityEngine;

public class GameManager_puzzle : MonoBehaviour
{
    public static GameManager_puzzle Instance { get; private set; }

    public MathPuzzleController CurrentPuzzle { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void SetActivePuzzle(MathPuzzleController puzzle)
    {
        CurrentPuzzle = puzzle;
    }
}
