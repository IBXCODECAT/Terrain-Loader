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
        [SerializeField] private Transform FOLLOW_TARGET;

        [SerializeField] private float minYOffset;
        [SerializeField] private float maxYOffset;


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
            CameraZoom();
        }

        private void CameraMove()
        {

        }

        private void CameraZoom()
        {

            float scrollInput = inputActions.LookVerticalOffset.ReadValue<Vector2>().y + inputActions.Look.ReadValue<Vector2>().y;

            scrollInput *= Time.deltaTime;

            Debug.Log(scrollInput);

            offsetY = Mathf.Clamp(FOLLOW_TARGET.position.y + scrollInput, minYOffset, maxYOffset);
            FOLLOW_TARGET.position = new Vector3(FOLLOW_TARGET.position.x, offsetY, FOLLOW_TARGET.position.z);
        }


    }
}
