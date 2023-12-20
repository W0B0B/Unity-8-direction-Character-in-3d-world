using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateManeger : MonoBehaviour
{
    [SerializeField] private Camera _Cam;
    public Vector3 dir;
    [SerializeField] float groundYOffset,roationSpeed=10;
    [SerializeField] LayerMask GroundMask;
    [SerializeField] float gravity=-9.81f,JumpSpeed=20f;
    public float JumpCount=1;
    private Vector3 _DirY;
    Vector3 SpherePos;
    Vector3 velocity;
    public float MoveSpeed= 10;
    CharacterController _Controller;
    [SerializeField] float Hinput,Vinput;
    void Awake()
    {
        _Controller= GetComponent<CharacterController>();
    }

    void Update()
    {
        GetDirection();
        Gravity();
        jump();
        
    }
     void GetDirection()
    {   
        Hinput=Input.GetAxis("Horizontal");
        Vinput=Input.GetAxis("Vertical");
        dir=Quaternion.Euler(0,_Cam.transform.eulerAngles.y, 0) * new Vector3 (Hinput,0,Vinput);    
        if (dir != Vector3.zero)
        {
            Quaternion DesiredRotation=Quaternion.LookRotation(dir,Vector3.up);
            transform.rotation=Quaternion.Slerp(transform.rotation,DesiredRotation,roationSpeed*Time.deltaTime);
        }
        _Controller.Move(dir*MoveSpeed*Time.deltaTime);

    }
    void jump(){
        if (Input.GetKeyDown(KeyCode.Space)&&JumpCount>0)
        {
            JumpCount--;
            Debug.Log("Zıpladı");
            _DirY.y=JumpSpeed;  
            
        }
        if (IsGrounded())
        {
            JumpCount=1;
        }
    }
    bool IsGrounded(){
        SpherePos=new Vector3(transform.position.x,transform.position.y-groundYOffset,transform.position.z);
        if(Physics.CheckSphere(SpherePos,_Controller.radius-0.05f,GroundMask)){
            return true;
        }
        return false;
    }
    void Gravity()
    {
        if (!IsGrounded())
        {
            _DirY.y+=gravity*Time.deltaTime;       
        }
        else if(_DirY.y<0)
        {
            _DirY.y=-2;
        }
        _Controller.Move(_DirY*Time.deltaTime);
        
    }
    
    
}
