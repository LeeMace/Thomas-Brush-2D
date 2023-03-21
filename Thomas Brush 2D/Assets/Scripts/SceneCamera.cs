using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCamera : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;
    
    void Start()
    {
        //get the camera to follow the player in the new level
        cinemachineVirtualCamera.Follow = NewPlayer.Instance.transform;
    }
}
