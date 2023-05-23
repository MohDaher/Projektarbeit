using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{ 

    public Quaternion startQuaternion;
    public float lerpTime = 1;
    public bool rotate; 

    void Start()
    {
        startQuaternion = transform.rotation;
    }

    void Update()
    {
        if(rotate)
            transform.rotation = Quaternion.Lerp(transform.rotation, startQuaternion, Time.deltaTime * lerpTime);

    }
    public void snapRotation()
    {
        transform.rotation = startQuaternion;
    }
}
