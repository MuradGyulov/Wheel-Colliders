using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BMP_Controller : MonoBehaviour
{
    public WheelCollider Front_Wheel_Collider_1, Front_Wheel_Collider_2, Front_Wheel_Collider_3, Front_Wheel_Collider_4;
    public WheelCollider Rear_Wheel_Collider_1, Rear_Wheel_Collider_2, Rear_Wheel_Collider_3, Rear_Wheel_Collider_4;

    public Transform Front_Wheel_1, Front_Wheel_2, Front_Wheel_3, Front_Wheel_4;
    public Transform Rear_Wheel_1, Rear_Wheel_2, Rear_Wheel_3, Rear_Wheel_4;

    public float Ster_Angel;
    public float Max_SterAngle;

    public float Motor_Force;
    private float Motor_Break;
    public float Break;

    private float Vertical_Input;
    private float Horizontal_Input;

    public void Get_Input()
    {
        Motor_Break = Input.GetAxis("Jump");
        Vertical_Input = Input.GetAxis("Vertical");
        Horizontal_Input = Input.GetAxis("Horizontal");
    }

    private void Steer()
    {
        Ster_Angel = Max_SterAngle * Horizontal_Input;

        Front_Wheel_Collider_1.steerAngle = Ster_Angel;
        Front_Wheel_Collider_2.steerAngle = Ster_Angel;
        Front_Wheel_Collider_3.steerAngle = Ster_Angel;
        Front_Wheel_Collider_4.steerAngle = Ster_Angel;
    }

    private void Accelerate()
    {
        Front_Wheel_Collider_1.motorTorque = Motor_Force * Vertical_Input;
        Front_Wheel_Collider_2.motorTorque = Motor_Force * Vertical_Input;
        Front_Wheel_Collider_3.motorTorque = Motor_Force * Vertical_Input;
        Front_Wheel_Collider_4.motorTorque = Motor_Force * Vertical_Input;
        Rear_Wheel_Collider_1.motorTorque = Motor_Force * Vertical_Input;
        Rear_Wheel_Collider_2.motorTorque = Motor_Force * Vertical_Input;
        Rear_Wheel_Collider_3.motorTorque = Motor_Force * Vertical_Input;
        Rear_Wheel_Collider_4.motorTorque = Motor_Force * Vertical_Input;
    }

    private void Breake()
    {
        Front_Wheel_Collider_1.brakeTorque = Motor_Break * Break;
        Front_Wheel_Collider_2.brakeTorque = Motor_Break * Break;
        Front_Wheel_Collider_3.brakeTorque = Motor_Break * Break;
        Front_Wheel_Collider_4.brakeTorque = Motor_Break * Break;
        Rear_Wheel_Collider_1.brakeTorque = Motor_Break * Break;
        Rear_Wheel_Collider_2.brakeTorque = Motor_Break * Break;
        Rear_Wheel_Collider_3.brakeTorque = Motor_Break * Break;
        Rear_Wheel_Collider_4.brakeTorque = Motor_Break * Break;
    }

    private void Update_Wheels_Positions()
    {
        Update_Wheel_Position(Front_Wheel_Collider_1, Front_Wheel_1);
        Update_Wheel_Position(Front_Wheel_Collider_2, Front_Wheel_2);
        Update_Wheel_Position(Front_Wheel_Collider_3, Front_Wheel_3);
        Update_Wheel_Position(Front_Wheel_Collider_4, Front_Wheel_4);
        Update_Wheel_Position(Rear_Wheel_Collider_1, Rear_Wheel_1);
        Update_Wheel_Position(Rear_Wheel_Collider_2, Rear_Wheel_2);
        Update_Wheel_Position(Rear_Wheel_Collider_3, Rear_Wheel_3);
        Update_Wheel_Position(Rear_Wheel_Collider_4, Rear_Wheel_4);
    }

    private void Update_Wheel_Position(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = _transform.position;
        Quaternion _qua = transform.rotation;

        _collider.GetWorldPose(out _pos, out _qua);

      _transform.position = _pos;
      _transform.rotation = _qua;

    }

    private void FixedUpdate()
    {
        Get_Input();
        Breake();
        Steer();
        Accelerate();
        Update_Wheels_Positions();
    }
}
