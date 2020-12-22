using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public Rigidbody2D frontWheel;
    public Rigidbody2D backWheel;
    public Rigidbody2D Car;
    public float carSpeed =50f;
    public float carTorque= -100f;
    float input;
    // Start is called before the first frame update
    void FixedUpdate()
    {
        frontWheel.AddTorque(input * carSpeed * Time.fixedDeltaTime);
        backWheel.AddTorque(input * carSpeed * Time.fixedDeltaTime);
        Car.AddTorque(input * carTorque * Time.fixedDeltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        input = -Input.GetAxis("Horizontal");
    }
}
