using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    [SerializeField] Item.Type itemType;
    Item item;

    private void Start()
    {
        item = ItemGenerator.instance.Spawn(itemType);
    }
    public void OnClickObject()
    {
        ItemBox.instance.SetItem(item);
        gameObject.SetActive(false);
    }
}
