using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class TPS_Camera : MonoBehaviour
{
    [SerializeField] private Transform playerT;
    [SerializeField] private float turnSpeed;
    [SerializeField] private float aimDuration;
    [SerializeField] private Cinemachine.AxisState xAxis, yAxis;
    [SerializeField] private CinemachineVirtualCamera camTPS;
    [SerializeField] private Transform camLookAt;

    private Camera mainCam;
    
    
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        xAxis.Update(Time.fixedDeltaTime);
        yAxis.Update(Time.fixedDeltaTime);

        camLookAt.eulerAngles = new Vector3(yAxis.Value, xAxis.Value, 0);

        float yawCamera = mainCam.transform.rotation.eulerAngles.y;
        playerT.rotation = Quaternion.Slerp(playerT.rotation, Quaternion.Euler(0,yawCamera,0), turnSpeed * Time.fixedDeltaTime);
    }

    public void Aim(bool isAiming)
    {
        
    }
}
