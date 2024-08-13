using UnityEngine;

public class playerCharactger : MonoBehaviour
{
    [SerializeField]
    inventorySlot inventory = new inventorySlot();

    [SerializeField]
    GameObject colliderTarget;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            interact();
        }

        if (!inventory.isEmpty())
        {
            inventory.Item.transform.position = transform.position + transform.up;
            inventory.Item.transform.forward = transform.forward;
        }
    }

    void interact()
    {
        var item = colliderTarget != null ? colliderTarget.GetComponent<itemObject>() : null;
        var desk = colliderTarget != null ? colliderTarget.GetComponent<deskObject>() : null;

        bool isItem = item != null;
        bool isDesk = desk != null;
        bool HasItem = !inventory.isEmpty();

        if (isItem && isDesk && HasItem)
        {
            // impossible pattern
        }
        else if (isItem && isDesk && !HasItem)
        {
            // impossible pattern
        }
        else if (isItem && !isDesk && HasItem)
        {
            // do nothing
        }
        else if (isItem && !isDesk && !HasItem)
        {
            grabItem(item);
            colliderTarget = null;
        }
        else if (!isItem && isDesk && HasItem)
        {
            desk.interact(this, releaseItem());
        }
        else if (!isItem && isDesk && !HasItem)
        {
            desk.interact(this);
        }
        else if (!isItem && !isDesk && HasItem)
        {
            releaseItem();
        }
        else if (!isItem && !isDesk && !HasItem)
        {
            // do nothing
        }
    }

    public void grabItem(itemObject target)
    {
        inventory.setItem(target);
    }

    public itemObject releaseItem()
    {
        return inventory.releaseItem();
    }

    void OnTriggerEnter(Collider other)
    {
        colliderTarget = other.gameObject;
    }

    void OnTriggerExit()
    {
        colliderTarget = null;
    }
}
