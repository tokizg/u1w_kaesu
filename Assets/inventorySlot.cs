using UnityEngine;

[System.Serializable]
public class inventorySlot
{
    [SerializeField]
    itemObject item;

    public itemObject Item
    {
        get { return item; }
    }

    public bool isEmpty()
    {
        return item == null;
    }

    public void setItem(itemObject obj)
    {
        item = obj;
        item.intoSlot();
    }

    public itemObject releaseItem()
    {
        item.release();
        var temp = item;
        item = null;
        return temp;
    }
}
