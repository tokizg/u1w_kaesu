using UnityEngine;

public class playerCharactger : MonoBehaviour
{
    [SerializeField]
    grabableObject grabingObject;

    [SerializeField]
    GameObject colliderTarget;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            interact();
        }

        if (grabingObject != null)
        {
            grabingObject.transform.position = transform.position + transform.up;
            grabingObject.transform.rotation = transform.rotation;
        }
    }

    void interact()
    {
        if (grabingObject != null && colliderTarget == null)
        {
            grabingObject.SendMessage(
                "KAESU_INTERACT",
                this,
                SendMessageOptions.DontRequireReceiver
            );
        }
        else if (grabingObject == null && colliderTarget != null)
        {
            colliderTarget.SendMessage(
                "KAESU_INTERACT",
                this,
                SendMessageOptions.DontRequireReceiver
            );
        }
        else if (grabingObject != null && colliderTarget != null)
        {
            colliderTarget.SendMessage(
                "KAESU_INTERACT",
                grabingObject,
                SendMessageOptions.DontRequireReceiver
            );
        }
    }

    public void grab(grabableObject target)
    {
        grabingObject = target;
    }

    public void release()
    {
        if (grabingObject != null)
        {
            grabingObject = null;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        colliderTarget = other.gameObject;
    }

    void OnTriggerExit(Collider other)
    {
        colliderTarget = null;
    }
}
