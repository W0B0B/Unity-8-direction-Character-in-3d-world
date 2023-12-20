using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;      
public class AimStateManager : MonoBehaviour
{
    public Cinemachine.AxisState XAxis,yAxis;
    [SerializeField] Transform camFollowPos;

    // Update is called once per frame
    void Update()
    {
        XAxis.Update(Time.deltaTime);
        yAxis.Update(Time.deltaTime);
    }
    void LateUpdate()
    {
        camFollowPos.localEulerAngles=new Vector3(yAxis.Value,camFollowPos.localEulerAngles.y,camFollowPos.localEulerAngles.z);
        //transform.eulerAngles= new Vector3(transform.eulerAngles.x,XAxis.Value,transform.eulerAngles.z);
        camFollowPos.localEulerAngles=new Vector3(camFollowPos.localEulerAngles.x,XAxis.Value,camFollowPos.localEulerAngles.z);
    }
}
