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
        [SerializeField] private new Camera camera;
        [SerializeField] private CinemachineVirtualCamera virtualCamera;
        [SerializeField] private Transform FOLLOW_TARGET;
        [SerializeField] private Transform LOOK_TARGET;
        [SerializeField] private Transform DOLLY_SYSTEM;

        [Header("Control Information")]
        [SerializeField] private LayerMask cameraOffsetFromLayers;
        [Range(3f, 15f)]
        [SerializeField] private float minTerrainYOffset;
        [Range(75f, 275f)]
        [SerializeField] private float maxTerrainYOffset;
        [Range(0f, 3f)]
        [SerializeField] private float lookTargetTerrainClearance;
        [Range(1, 200)]
        [SerializeField] private int dollySpeedMultiplier;


        private ActionMap.BuildModeActions inputActions;

        private float terrainOffsetY = 0f;

        private RaycastHit vcamRayHit;

        private void Awake()
        {
            inputActions = InputMapManager.GetBuildModeActions();
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            Physics.Raycast(virtualCamera.transform.position + (transform.up * 200), -Vector3.up, out vcamRayHit, Mathf.Infinity, cameraOffsetFromLayers.value);

            UpdateCameraDollyMove();
            UpdateCameraZoom();

            Debug.DrawLine(virtualCamera.transform.position, LOOK_TARGET.position, Color.cyan);
            Debug.DrawLine(virtualCamera.transform.position, FOLLOW_TARGET.position, Color.blue);

            Debug.DrawLine(transform.position, LOOK_TARGET.position, Color.cyan);
            Debug.DrawLine(transform.position, FOLLOW_TARGET.position, Color.blue);
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(virtualCamera.transform.position, virtualCamera.GetCinemachineComponent<CinemachineOrbitalTransposer>().m_FollowOffset.z);
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

            //Once the dolly system has moved, move the Cinemachine targets along the X and Z axis & snap to Y raycast.
            //NOTE: The actual camera movement is handled by Cinemachine every frame in the Cinemachine code assembly
            FOLLOW_TARGET.position = new Vector3(DOLLY_SYSTEM.position.x, FOLLOW_TARGET.position.y, DOLLY_SYSTEM.position.z);
            LOOK_TARGET.position = new Vector3(DOLLY_SYSTEM.position.x, vcamRayHit.point.y + lookTargetTerrainClearance, DOLLY_SYSTEM.position.z);

        }

        private void UpdateCameraZoom()
        {

            float scrollInput = inputActions.LookVerticalOffset.ReadValue<Vector2>().y + inputActions.Look.ReadValue<Vector2>().y;

            scrollInput *= Time.deltaTime;

            float calculatedMinOffsetY = vcamRayHit.point.y + minTerrainYOffset;

            terrainOffsetY = Mathf.Clamp(FOLLOW_TARGET.position.y + scrollInput, calculatedMinOffsetY, maxTerrainYOffset);
            FOLLOW_TARGET.position = new Vector3(FOLLOW_TARGET.position.x, terrainOffsetY, FOLLOW_TARGET.position.z);
        }
    }
}
