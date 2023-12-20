using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2DContoller : MonoBehaviour
{
    [SerializeField] protected Transform _target;
   void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(_target.position.x,_target.position.y,-10f);
    }
}
