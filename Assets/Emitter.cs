using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour
{
    [SerializeField]
    bool isEnabled = false;

    [SerializeField]
    float interval = 3f;

    [SerializeField]
    float lastGeneratedTime = 0f;

    [SerializeField]
    GameObject item;

    [SerializeField]
    Transform generatePointObject;

    [SerializeField]
    Color pipelineColor = Color.white;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        if (isEnabled && Time.time - lastGeneratedTime > interval)
        {
            lastGeneratedTime = Time.time;
            generate();
        }
    }

    void generate()
    {
        GameObject generatance = Instantiate(item, transform.position, Quaternion.identity);
        generatance.transform.position = generatePointObject.position;
        generatance.transform.rotation = generatePointObject.rotation;
        generatance.GetComponent<itemObject>().initialize(pipelineColor);
    }
}
