using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{

    private GameObject trackedObject;
    private Vector3 trackedPos;
    private Material textureMaterial;

    // Start is called before the first frame update
    void Start()
    {
        if (trackedObject == null)
        {
            trackedPos = Vector3.zero;
        }
        else
        {
            trackedPos = trackedObject.transform.position;
        }
        textureMaterial = this.GetComponent<Text>().material;

        trackedObject = GameObject.FindGameObjectWithTag("EyeTracker");
    }

    public void SetTrackedObject(GameObject obj)
    {
        trackedObject = obj;
        trackedPos = trackedObject.transform.position;
    }

        // Update is called once per frame
        void Update()
    {
        if (trackedObject != null)
        {
            trackedPos = new Vector3(trackedObject.transform.position.x, trackedObject.transform.position.y);
            Debug.Log(trackedPos);
        }
        textureMaterial.SetVector("_ObjWorldPos", this.transform.position);
        textureMaterial.SetVector("_TrackedPos", this.trackedPos);

        Debug.Log(trackedPos);
    }
}
