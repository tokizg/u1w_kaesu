using UnityEngine;

public class timeObject : itemObject
{
    [SerializeField]
    float startTime = 0;

    [SerializeField]
    float processTime = 3;

    public override bool IsProcessed
    {
        get => startTime != 0f ? Time.time - startTime >= processTime : false;
    }

    public override void process()
    {
        startTime = Time.time;
        Invoke("changeMaterial", processTime);
    }
}
