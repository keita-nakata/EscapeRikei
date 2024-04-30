using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    [SerializeField] ItemDataBase itemDataBase;

    public static ItemGenerator instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public Item Spawn(Item.Type type)
    {
        // itemListの中からtypeと一致するitemを生成して渡す
        foreach(Item item in itemDataBase.itemList)
        {
            if(item.type == type)
            {
                return new Item(item.type, item.sprite);
            }
        }
        return null;
    }
}
