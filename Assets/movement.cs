using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    //publics
    public Transform cameraTransform;
    
    //private
    private float _cubeSize;
    private float _movementSpeed = 25;
    private float _rotationSpeed = 1500;
    private float _zoomSpeed = 2000;
    private float _jumpPower = 1;

    // Start is called before the first frame update
    void Start()
    {
        _cubeSize = 3;
        _jumpPower = 5;
        _movementSpeed = 25;
        _rotationSpeed = 1500;
        _zoomSpeed = 2000;
        cameraTransform.LookAt(transform.position);
        transform.localScale = new Vector3(_cubeSize, _cubeSize, _cubeSize);
    }

    // Update is called once per frame
    void Update()
    {

        //movement
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * _movementSpeed);
        transform.Translate(Vector3.up * Input.GetAxis("Jump") * Time.deltaTime * _jumpPower);
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime * _movementSpeed);
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * _rotationSpeed);

        //cameraRotation
        cameraTransform.LookAt(transform.position);
        cameraTransform.Translate(0,0, Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * _zoomSpeed);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            cameraTransform.RotateAround(transform.position, Vector3.up, Input.GetAxis("Mouse X") *Time.deltaTime * _rotationSpeed);
            cameraTransform.RotateAround(transform.position, Vector3.left, Input.GetAxis("Mouse Y") * Time.deltaTime * _rotationSpeed);

        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            cameraTransform.localPosition = new Vector3(0, 3.21f, -6.31f);
        }

        //cameraTransform.RotateAround (transform.position, Vector3.up,Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeed);

        if (Input.GetKey(KeyCode.G))
        {
            getBigger();
        }
        if (Input.GetKey(KeyCode.B))
        {
            getSmaller();
        }

    }


    private void getBigger()
    {
        if (_cubeSize < 25)
        {
            _cubeSize += 0.5f * Time.deltaTime * 3;
            transform.localScale = new Vector3(_cubeSize, _cubeSize, _cubeSize);
            _zoomSpeed += 200 * Time.deltaTime * 3;
            _movementSpeed += 0.5f * Time.deltaTime * 3;
            _jumpPower += 0.2f * Time.deltaTime * 3;
        }
        else if (_cubeSize > 25)
        {
            _cubeSize = 25;
        }

    }

    private void getSmaller()
    {
        if (_cubeSize > 0.5)
        {
            _cubeSize -= 0.5f * Time.deltaTime * 3;
            transform.localScale = new Vector3(_cubeSize, _cubeSize, _cubeSize);
            _movementSpeed -= 0.5f * Time.deltaTime * 3;
            _zoomSpeed -= 200 * Time.deltaTime * 3;
            _jumpPower -= 0.2f * Time.deltaTime * 3;
        }
        else if (_cubeSize < 0.5)
        {
            _cubeSize = 0.5f;
            _movementSpeed = 0.5f;
        }

    }

}
