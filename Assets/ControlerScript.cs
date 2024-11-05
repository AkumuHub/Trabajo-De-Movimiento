using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlerScript : MonoBehaviour
{

    //public attributes

    public Transform finalTransform;
    public Transform initialTransform;
    public float speed = 1;


    //private attributes
    private Vector3 _directionVector;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _directionVector = finalTransform.position - initialTransform.position;

        _directionVector.Normalize();

        Debug.DrawRay(initialTransform.position, _directionVector * speed);

        initialTransform.Translate(_directionVector * Time.deltaTime * speed);


    }
}
