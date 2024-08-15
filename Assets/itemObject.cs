using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField]
    Transform canvas;

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
        canvas.transform.parent = null;
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

    void Update()
    {
        if (canvas != null)
        {
            canvas.transform.position = transform.position + new Vector3(0, 1, 1);
        }
    }
}
