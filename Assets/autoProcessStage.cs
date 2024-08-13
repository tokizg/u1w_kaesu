using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoProcessStage : deskObject
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
                grab(item);
        }
    }

    public override void interact(playerCharactger character, itemObject item)
    {
        if (inventory.isEmpty() && item as timeObject)
        {
            grab(item);
            item.process();
        }
        else
        {
            //do nothing
        }
    }
}
