using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deskObject : MonoBehaviour
{
    [SerializeField]
    inventorySlot inventory = new inventorySlot();

    public void interact(playerCharactger character)
    {
        if (inventory.isEmpty())
        {
            //do nothing
        }
        else
        {
            var item = release();
            character.grabItem(item);
        }
    }

    public void interact(playerCharactger character, itemObject item)
    {
        if (inventory.isEmpty())
        {
            grab(item);
        }
        else
        {
            //do nothing
        }
    }

    public void grab(itemObject target)
    {
        inventory.setItem(target);
    }

    public itemObject release()
    {
        return inventory.releaseItem();
    }
}
