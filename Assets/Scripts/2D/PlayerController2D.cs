using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{  

    [SerializeField] private float MoveSpeed=10,groundYOffset=0.6f,SphereRadius=0.05f;
    private float JumpCount=2,JumpSpeed=7,gravity=-9.81f;
    [SerializeField] private LayerMask Groundmask;
    private Vector3 _DirY,_SpherePos;
    private CharacterController _Controller;
    void Awake()
    {
        _Controller=GetComponent<CharacterController>();
    }
    void Update()
    {
        Movement();
        jump();    
        Gravity();
    }
    #region Gravity 
    void Gravity()
    {
        if (!isGround())
        {
            _DirY.y+=gravity*Time.deltaTime;       
        }
        else if(_DirY.y<0)
        {
            _DirY.y=gravity;
        }
        _Controller.Move(_DirY*Time.deltaTime);
    }
    #endregion
    #region isGround
    bool isGround(){
        _SpherePos=new Vector3(transform.position.x,transform.position.y-groundYOffset,transform.position.z);
        if(Physics.CheckSphere(_SpherePos,_Controller.radius-SphereRadius,Groundmask))
        {
            return true;
        } 
        return false;
    }
    #endregion
    
    #region Movement
    void Movement(){
        float hInput=Input.GetAxis("Horizontal");
        Vector3 movementInput=new Vector3(hInput,0,0);
        Vector3 MoveDir=movementInput.normalized;

        _Controller.Move(movementInput*Time.deltaTime*MoveSpeed);
    }
    #endregion
    #region jump
     void jump(){
        if (Input.GetKeyDown(KeyCode.Space)&&JumpCount>0)
        {
            JumpCount--;
            Debug.Log("Zıpladı");
            _DirY.y=JumpSpeed;  
            _Controller.Move(_DirY*Time.deltaTime);
        }
        if (isGround())
        {
            JumpCount=2;
        }
    #endregion       

}
void OnDrawGizmos()
{
        Gizmos.DrawWireSphere(_SpherePos,_Controller.radius-SphereRadius);
}
}