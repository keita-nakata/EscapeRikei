using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    Image ItemImage;
    Item item;
    private void Awake()
    {
        ItemImage = GetComponent<Image>();
    }

    public bool IsEmpty()
    {
        return item == null;
    }

    // アイテムを受け取ったらスロットに表示
    public void SetItem(Item item)
    {
        this.item = item;
        UpdateImage(item);
    }

    void UpdateImage(Item item)
    {
        ItemImage.sprite = item.sprite;
    }
}
