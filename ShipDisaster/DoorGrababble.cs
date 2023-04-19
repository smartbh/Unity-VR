using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorGrababble : OVRGrabbable
{
    public Transform Handler;

    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(Vector3.zero, Vector3.zero);

        transform.position = Handler.transform.position;
        transform.rotation = Handler.transform.rotation;

        Rigidbody rigidbodyHandler = Handler.GetComponent<Rigidbody>();
        rigidbodyHandler.velocity = Vector3.zero;
        rigidbodyHandler.angularVelocity = Vector3.zero;
    }

    private void Update()
    {
        if(Vector3.Distance(Handler.position, transform.position) > 0.4f)
        {
            grabbedBy.ForceRelease(this);   
        }
    }
}
