using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// クリックすることでアルファベットが1つずつ変わっていく
/// A→B→...→Y→Z→A→...
/// テキストの親オブジェクト（AlphabetBoxなど）にアタッチ
/// </summary>
public class AlphabetChanger : MonoBehaviour
{
    private char Alphabet;

    private void Start()
    {
        Alphabet = 'A';
        (transform.Find("Alphabet").gameObject).GetComponent<TextMeshProUGUI>().text = Alphabet.ToString();
        gameObject.GetComponent<Button>().onClick.AddListener(() => ShiftAlphabet());
    }

    public void ShiftAlphabet()
    {
        Alphabet++;
        if (Alphabet > 'Z')
            Alphabet = 'A';

        (transform.Find("Alphabet").gameObject).GetComponent<TextMeshProUGUI>().text = Alphabet.ToString();
    }
}
