// ########################################################################################################################
// ########################################################################################################################
// This programme is used to disable tracking of the HTC Vive Pro Eye.
// The programme is developed by Yu Imaoka and Andri Flury at D-HEST. ETH Zurich.
// 18th of November 2019.
// Software information: SRanipal_SDK_1.1.0.1
// 
// DisableTracking:     Attached to main camera 
//
// ########################################################################################################################
// ########################################################################################################################



// ************************************************************************************************************************
// Call namespaces.
// ************************************************************************************************************************

using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine.Assertions;
using UnityEngine;
using System;
using System.IO;
using System.Data;
using System.Text;
using ViveSR.anipal.Eye;
using UnityEngine.XR;

public class DisableTracking : MonoBehaviour
{
    private GameObject cam;
    
    void Start()
    {
        TrackingOFF();
    }
    
    void Update()
    {
        
    }

    void TrackingOFF()
    {
        XRDevice.DisableAutoXRCameraTracking(GetComponent<Camera>(), true);   //Disable HMD tracking
        cam = GameObject.Find("Main Camera");                                 //Assigning the game object (Main Camera) to the script.
        Vector3 campositon = new Vector3(0, 41.9f, 0);                         //Define starting position of the camera.
        cam.transform.position = campositon;                                  //positions camera with camposition vector.
        cam.transform.rotation = new Quaternion(0, 0, 0, 0);                  //Define starting rotation of the camera.
    }
}
