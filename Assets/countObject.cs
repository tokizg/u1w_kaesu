using UnityEngine;

public class countObject : itemObject
{
    [SerializeField]
    int count = 0;

    [SerializeField]
    int maxCount = 3;

    public override bool IsProcessed
    {
        get => count >= maxCount;
    }

    public override void process()
    {
        count++;
        if (IsProcessed)
        {
            changeMaterial();
        }
    }
}
