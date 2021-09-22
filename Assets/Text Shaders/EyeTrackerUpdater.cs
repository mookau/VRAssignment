using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeTrackerUpdater : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        this.transform.position = new Vector3(worldPosition.x, worldPosition.y, this.transform.position.z);

    }
}
