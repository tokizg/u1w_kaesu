using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class grabableObject : MonoBehaviour
{
    [SerializeField]
    bool isGrabbed = false;

    [SerializeField]
    playerCharactger grabber;

    Rigidbody c_rig;

    void KAESU_INTERACT(playerCharactger sender)
    {
        if (isGrabbed)
        {
            Released(sender);
        }
        else
        {
            Grabbed(sender);
        }
    }

    void KAESU_INTERACT(grabableObject sender)
    {
        // Do nothing
    }

    void Grabbed(playerCharactger sender)
    {
        sender.grab(this);
        grabber = sender;
        c_rig.useGravity = false;
        isGrabbed = true;
    }

    void Released(playerCharactger sender)
    {
        sender.release();
        grabber = null;
        c_rig.useGravity = true;
        c_rig.AddForce(transform.forward * 10, ForceMode.Impulse);
        isGrabbed = false;
    }

    void Start()
    {
        c_rig = GetComponent<Rigidbody>();
    }
}
