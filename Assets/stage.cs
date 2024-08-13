using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage : deskObject
{
    public override void interact(playerCharactger character)
    {
        if (inventory.isEmpty())
        {
            //do nothing
        }
        else
        {
            var item = release();
            if (item.IsProcessed)
                character.grabItem(item);
            else
            {
                item.process();
                grab(item);
            }
        }
    }

    public override void interact(playerCharactger character, itemObject item)
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
}
