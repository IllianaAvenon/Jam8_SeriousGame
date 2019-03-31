using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private Animator _animator;   
    private Camera _mainCamera;
    private Vector3 _cameraRight;
    private Vector3 _cameraForward;
    private static readonly int Walking = Animator.StringToHash("Walking");
    private static readonly int MoveSpeed = Animator.StringToHash("MoveSpeed");

    // Use this for initialization
    void Start()
    {
        _animator = GetComponent<Animator>();
        _mainCamera = Camera.main;

        if (_mainCamera != null)
        {
            var right = _mainCamera.transform.right;
            _cameraRight = right;
            _cameraForward = Vector3.Cross(right, Vector3.up);
        }
        else
        {
            Debug.LogError("Need a main camera!");
        }
        
        if (_animator == null)
        {
            Debug.LogError("Animator not found! Please attach an animator when using this script.", _animator);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        Vector2 direction = new Vector2(horizontal, vertical);
        
        Vector3 moveDirection = horizontal * _cameraRight + vertical * _cameraForward;
        
        transform.LookAt(transform.position + moveDirection);

        transform.position += transform.forward * direction.magnitude * 
                              Time.deltaTime * _animator.GetFloat(MoveSpeed) * 2;
        
        _animator.SetBool(Walking, direction.magnitude > 0.001f);
    }
}