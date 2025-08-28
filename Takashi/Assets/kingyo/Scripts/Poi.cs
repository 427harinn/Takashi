using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

[RequireComponent(typeof(CircleCollider2D))]
public class Poi : MonoBehaviour
{
    Vector3 mousePos, pos;
    bool isClicked = false;

    [SerializeField] AudioSource poiSE;
    public AudioClip pichan;
    public AudioClip biri;

    public Transform center; // 中心オブジェクト（Inspectorで指定）

    private float durability = 1.5f;

    public Sprite biriImage;

    bool isBiri = false;

    int hitCount = 0;
    public Text hitCountText;

    [SerializeField] private GameObject finishUI;

    void Update()
    {
        if (!isClicked) return;
        if (isBiri) return;

        mousePos = Input.mousePosition;
        pos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x - 30, mousePos.y + 190, 10f));
        transform.position = pos;
    }

    public void PointerDown()
    {
        isClicked = true;
    }

    public void PointerUp()
    {
        if (isBiri) return;
        isClicked = false;

        float radius = 1.0f;
        Vector2 centerPos = center.position;

        Collider2D[] overlaps = Physics2D.OverlapCircleAll(centerPos, radius);
        List<float> hitDamages = new List<float>();

        foreach (Collider2D col in overlaps)
        {
            if (col.CompareTag("fish"))
            {
                float dist = Vector2.Distance(centerPos, col.transform.position);
                float normalizedDist = Mathf.Clamp01(dist / radius);
                float damage = Mathf.Lerp(1.0f, 0.2f, normalizedDist); // 中心で1、縁で0.2

                hitDamages.Add(damage);
                hitCount++;
                hitCountText.text = hitCount.ToString() + "ひき";

                col.GetComponent<BoxCollider2D>().enabled = false;
                // 金魚に Caught() を呼ぶ
                var fish = col.GetComponent<KingyoMove>();
                if (fish != null)
                {
                    fish.Caught();
                }

                Debug.Log($"中心との距離={dist:F2}, 正規化={normalizedDist:F2}, ダメージ={damage:F2}, 現耐久={durability:F2}");
            }
        }

        if (hitDamages.Count > 0)
        {
            float finalDamage = hitDamages.Max(); // 中心に一番近い（最も破れやすい）金魚を使用
            durability -= finalDamage;
            Debug.Log($"今回の最大ダメージ={finalDamage:F2}、残り耐久={durability:F2}");
            if (durability <= 0)
            {
                if (hitCount >= 25)
                {
                    GManager.instance.score[GManager.instance.scenenumber - 1] = 100;
                }
                else if (hitCount >= 20)
                {
                    GManager.instance.score[GManager.instance.scenenumber - 1] = 90;
                }
                else if (hitCount >= 15)
                {
                    GManager.instance.score[GManager.instance.scenenumber - 1] = 80;
                }
                else if (hitCount >= 10)
                {
                    GManager.instance.score[GManager.instance.scenenumber - 1] = 70;
                }
                else if (hitCount >= 5)
                {
                    GManager.instance.score[GManager.instance.scenenumber - 1] = 50;
                }
                else
                {
                    GManager.instance.score[GManager.instance.scenenumber - 1] = 20;
                }
                poiSE.PlayOneShot(biri);
                this.GetComponent<Image>().sprite = biriImage;
                finishUI.SetActive(true);
                isBiri = true;
                if (GManager.instance.scoreattack)
                {
                    Invoke("loadscene2", 2f);
                }
                else
                {
                    Invoke("loadscene", 2f);
                }

                return;
            }
        }

        poiSE.PlayOneShot(pichan);
    }

    public void loadscene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("nikki_kingyo");
    }

    public void loadscene2()
    {
        GManager.instance.scenenumber = 5;
        UnityEngine.SceneManagement.SceneManager.LoadScene("syuku");
    }

}
