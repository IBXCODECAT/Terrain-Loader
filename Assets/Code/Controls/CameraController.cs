using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PlayerInput;
using UnityEditor;

namespace Controls
{
    public class CameraController : MonoBehaviour
    {
        [Header("Camera Information")]
        [SerializeField] private Camera camera;
        [SerializeField] private CinemachineVirtualCamera virtualCamera;
        [SerializeField] private Transform FOLLOW_TARGET;
        [SerializeField] private Transform LOOK_TARGET;
        [SerializeField] private Transform DOLLY_SYSTEM;

        [SerializeField] private float minYOffset = 7;
        [SerializeField] private float maxYOffset = 75;

        [SerializeField] private float dollySpeedMultiplier = 5;


        private ActionMap.BuildModeActions inputActions;

        private float offsetY = 0f;

        private void Awake()
        {
            inputActions = InputMapManager.GetBuildModeActions();
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            UpdateCameraDollyMove();
            UpdateCameraZoom();
        }

        private void UpdateCameraDollyMove()
        {
            //Rotate dolly system to match the roation of the main camera w/o lineier interpolation of VCAM
            DOLLY_SYSTEM.eulerAngles = new Vector3(0f, camera.transform.eulerAngles.y, 0f);

            //Grab the dolly input from the player and parse it into a world space Vector, apply deltatime & scaling here
            Vector2 dollyInput = inputActions.CameraDollyMovement.ReadValue<Vector2>();
            Vector3 dollyMovement = new Vector3(dollyInput.x, 0f, dollyInput.y) * Time.deltaTime * dollySpeedMultiplier;

            //Moves the entire dolly system "forward" relative to the current y-axis rotation
            DOLLY_SYSTEM.Translate(dollyMovement);

            //Once the dolly system has moved, move the Cinemachine targets along the X and Z axis.
            //NOTE: The actual camera movement is handled by Cinemachine every frame in the Cinemachine code assembly
            LOOK_TARGET.position = new Vector3(DOLLY_SYSTEM.position.x, LOOK_TARGET.position.y, DOLLY_SYSTEM.position.z);
            FOLLOW_TARGET.position = new Vector3(DOLLY_SYSTEM.position.x, FOLLOW_TARGET.position.y, DOLLY_SYSTEM.position.z);
        }

        private void UpdateCameraZoom()
        {

            float scrollInput = inputActions.LookVerticalOffset.ReadValue<Vector2>().y + inputActions.Look.ReadValue<Vector2>().y;

            scrollInput *= Time.deltaTime;

            offsetY = Mathf.Clamp(FOLLOW_TARGET.position.y + scrollInput, minYOffset, maxYOffset);
            FOLLOW_TARGET.position = new Vector3(FOLLOW_TARGET.position.x, offsetY, FOLLOW_TARGET.position.z);
        }
    }
}
