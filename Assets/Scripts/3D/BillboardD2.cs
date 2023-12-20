using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardD2 : MonoBehaviour
{
    public MovementStateManeger MSM;
    private float _CamYdir;
    private Camera _cam;
    private Animator _Animator;
    Vector2 animatorDir=new Vector2(0f,-1);
    void Awake()
    {
        _cam=Camera.main;
        _Animator=GetComponent<Animator>();
    }
    void Update()
    {
        _CamYdir=Mathf.Abs(_cam.transform.eulerAngles.y);
         transform.rotation= Quaternion.Euler(0,_cam.transform.rotation.eulerAngles.y,0);
        Animation(_CamYdir);
        _Animator.SetFloat("MoveX",animatorDir.x);
        _Animator.SetFloat("MoveY",animatorDir.y);
        Debug.Log(animatorDir);
    }
    Vector2 Animation(float CamR)
    {
        if (MSM.dir !=Vector3.zero )
        {
            animatorDir=new Vector2(Input.GetAxis("Horizontal"),-Input.GetAxis("Vertical"));
        }
        else
        {
            if(0<CamR&&CamR<45f)
        {
            //Up
            animatorDir=new Vector2(0,-1);
        }
        if (45<CamR&&CamR<90)
        {
            //UpLeft
            animatorDir=new Vector2(-1,-1);
        }
        if (90<CamR&&CamR<135)
        {
            //Left
            animatorDir=new Vector2(-1,0);
        }
        if (135<CamR&&CamR<180)
        {
            //DownLeft
            animatorDir=new Vector2(-1,1);
        }
        if (180<CamR&&CamR<225)
        {   
            //Down
            animatorDir=new Vector2(0,1);
        }
        if (225<CamR&&CamR<270)
        {   
            //DownRight
            animatorDir=new Vector2(1,1);
        }
        if (270<CamR&&CamR<315)
        {
            //Right
            animatorDir=new Vector2(1,0);
        }
        if (315<CamR&&CamR<360)
        {
            //UpRight
            animatorDir=new Vector2(1,-1);
        }    
        }
        
        return animatorDir;
    }

        
    
}
