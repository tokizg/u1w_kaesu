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
    float maxInterval = 12f;

    [SerializeField]
    float minInterval = 5f;

    void setIntervalRondomly()
    {
        interval = Random.Range(minInterval, maxInterval);
    }

    [SerializeField]
    float lastGeneratedTime = 0f;

    [SerializeField]
    GameObject[] items;

    GameObject randomItem
    {
        get { return items[Random.Range(0, items.Length)]; }
    }

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
            setIntervalRondomly();
        }
    }

    void generate()
    {
        GameObject generatance = Instantiate(randomItem, transform.position, Quaternion.identity);
        generatance.transform.position = generatePointObject.position;
        generatance.transform.rotation = generatePointObject.rotation;
        generatance.GetComponent<itemObject>().initialize(pipelineColor);
    }
}
