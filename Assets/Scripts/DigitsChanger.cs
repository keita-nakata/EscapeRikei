using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// クリックすることで数字が1つずつ増えていく
/// 0→1→2→...→9→0→...
/// テキストの親オブジェクト（DigitsBoxなど）にアタッチ
/// </summary>
public class DigitsChanger : MonoBehaviour
{
    private int count;

    private void Start()
    {
        count = 1;
        (transform.Find("Digits").gameObject).GetComponent<TextMeshProUGUI>().text = count.ToString();
        gameObject.GetComponent<Button>().onClick.AddListener(() => IncrementNumber());
    }

    public void IncrementNumber()
    {
        count++;
        if (count > 9)
            count = 0;

        (transform.Find("Digits").gameObject).GetComponent<TextMeshProUGUI>().text = count.ToString();
    }
}
