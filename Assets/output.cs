using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class output : deskObject
{
    [SerializeField]
    Color pipelineColor = Color.white;

    public override void interact(playerCharactger character)
    {
        //do nothing
    }

    public override void interact(playerCharactger character, itemObject item)
    {
        if (inventory.isEmpty())
        {
            if (item.IsProcessed && item.PipelineColor == pipelineColor)
            {
                Destroy(item.gameObject);
            }
            else
                character.grabItem(item);
        }
        else
        {
            //do nothing
        }
    }
}
