using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInputs : MonoBehaviour
{
    public Transform camTilt;
    public float radius = 0; //used for applying Y-axis angles to the object
    public Transform cam;

    Vector2 input;
    // Update is called once per frame
    void Update()
    {
        radius += Input.GetAxis("Mouse X") * Time.deltaTime * 180; //180 degrees per second applied at full mouse movement
        camTilt.rotation = Quaternion.Euler(0, radius, 0); //euler angles in rotation form

        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        input = Vector2.ClampMagnitude(input, 1);

        //transform.position += new Vector3(input.x, 0, input.y) * Time.deltaTime * 5;

        Vector3 camForward = cam.forward;
        Vector3 camRight = cam.right;

        camForward.y = 0;
        camRight.y = 0;
        camForward = camForward.normalized; //determines direction of camera without vertical angles
        camRight = camRight.normalized;

        transform.position += (camForward * input.y + camRight * input.x) * Time.deltaTime * 5;
    }
}
