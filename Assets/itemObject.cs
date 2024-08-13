using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class itemObject : MonoBehaviour
{
    [SerializeField]
    bool inSlot = false;

    [SerializeField]
    Rigidbody rb;

    [SerializeField]
    Collider col;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
    }

    public bool intoSlot()
    {
        inSlot = true;
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
        col.enabled = false;
        return true;
    }

    public void release()
    {
        inSlot = false;
        rb.useGravity = true;
        col.enabled = true;
        //rb.AddForce(transform.forward * 3, ForceMode.Impulse);
    }
}
