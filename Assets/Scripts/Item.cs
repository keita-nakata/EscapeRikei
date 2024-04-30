using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item
{

    public enum Type
    {
        C_Panel,
        L_Panel,
        E_Panel,
        A_Panel,
        R_Panel,
        Omori,

    }

    public Type type; //種類
    public Sprite sprite; //slotに表示する画像

    public Item(Type type, Sprite sprite)
    {
        this.type = type;
        this.sprite = sprite;
    }
}
