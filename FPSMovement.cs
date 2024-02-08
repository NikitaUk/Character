using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMovement : MonoBehaviour
{
    public int _speed = 4;
    public float _gravity = -9.8f;
    private CharacterController _characterController;
    public bool _isMoving = true;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        if (_characterController == null)
            Debug.Log("CharacterController is NULL");
    }
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * _speed;
        float deltaZ = Input.GetAxis("Vertical") * _speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, _speed);
        movement.y = _gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        if (_isMoving)
        {
            _characterController.Move(movement);
        }
        else
        {
            _characterController.Move(Vector3.zero);
        }
    }
    public void MoveLocked()
    {
        _isMoving = !_isMoving;
    }
}
