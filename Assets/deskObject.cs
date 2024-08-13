using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class deskObject : MonoBehaviour
{
    [SerializeField]
    protected inventorySlot inventory = new inventorySlot();

    void Update() { }

    public abstract void interact(playerCharactger character);

    public abstract void interact(playerCharactger character, itemObject item);

    protected void grab(itemObject target)
    {
        inventory.setItem(target);
        inventory.Item.transform.position = transform.position + transform.up;
    }

    protected itemObject release()
    {
        return inventory.releaseItem();
    }
}
