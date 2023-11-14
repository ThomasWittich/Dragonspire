using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensitivity = 1;

    public float distance = 1;

    public GameObject trackedObject;

    private Vector3 offset;
    private Transform trackedTransform;

    void Start()
    {
        trackedTransform = trackedObject.transform;
        offset = trackedTransform.forward * -distance;

        MoveCamera();
    }
    void LateUpdate()
    {
        Vector3 axis = -transform.right*input_vertical() + transform.up*input_horizontal();
        float angle = axis.magnitude * Time.deltaTime * sensitivity * Mathf.Rad2Deg;

        offset = Quaternion.AngleAxis(angle, axis) * offset;

        MoveCamera();
    }

    private void MoveCamera() {
        transform.position = trackedTransform.position + CollideCamera();
        transform.LookAt(trackedTransform);
    }

    private Vector3 CollideCamera() {
        RaycastHit hitInfo;
        LayerMask layerMask = ~LayerMask.GetMask("Ignore Camera");

        bool hitSomething = Physics.Raycast(
            trackedTransform.position,
            offset.normalized,
            out hitInfo,
            offset.magnitude,
            layerMask.value,
            QueryTriggerInteraction.Ignore
        );

        if (hitSomething) {
            return hitInfo.distance * offset.normalized * 0.9f;
        } else {
            return offset;
        }
    }

    private float input_horizontal() {
        float mouse_X = Input.GetAxis("Mouse X");

        mouse_X *= Mathf.Abs(AngleToVertical(offset) / 90);

        return mouse_X;
    }

    private float input_vertical() {
        float mouse_Y = Input.GetAxis("Mouse Y");

        float atv = AngleToVertical(offset);

        if (Mathf.Abs(atv) < 5 && Mathf.Sign(mouse_Y) != Mathf.Sign(atv)){
            mouse_Y = 0;
        }

        return mouse_Y;
    }

    private float AngleToVertical(Vector3 v){
        float angle = Vector3.Angle(v, Vector3.up);

        if(angle <= 90){
            return angle;
        } else {
            return angle - 180;
        }
    }
}
