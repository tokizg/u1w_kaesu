using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public abstract class itemObject : MonoBehaviour
{
    [SerializeField]
    Material processedMaterial;

    [SerializeField]
    Rigidbody rb;

    [SerializeField]
    Collider col;

    [SerializeField]
    Color pipelineColor;

    public Color PipelineColor
    {
        get => pipelineColor;
    }

    public void initialize(Color color)
    {
        pipelineColor = color;
    }

    public abstract bool IsProcessed { get; }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
    }

    public abstract void process();

    protected void changeMaterial()
    {
        GetComponent<Renderer>().material = processedMaterial;
    }

    public bool intoSlot()
    {
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
        col.enabled = false;
        return true;
    }

    public void release()
    {
        rb.useGravity = true;
        col.enabled = true;
        //rb.AddForce(transform.forward * 3, ForceMode.Impulse);
    }
}
