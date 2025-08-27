using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomKingyo : MonoBehaviour
{
    [SerializeField] GameObject kingyo;
    [SerializeField] Sprite[] kingyoSprites;

    private List<Vector3> kingyoPositions = new List<Vector3>(); // 生成位置の記録用

    private GameObject newkingyo;
    Vector3 pos;

    void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            CreateKingyo();
        }
    }

    void Update()
    {

    }

    public void CreateKingyo()
    {
        Vector3 randomPos = new Vector3(Random.Range(-3.0f, 3.0f), Random.Range(-5f, 5f), 0);
        newkingyo = Instantiate(kingyo, randomPos, Quaternion.identity);
        newkingyo.transform.SetParent(this.gameObject.transform, false);

        newkingyo.transform.GetChild(0).GetComponent<Image>().sprite = kingyoSprites[Random.Range(0, kingyoSprites.Length)];

        kingyoPositions.Add(randomPos); // 生成位置を記録
    }
}
