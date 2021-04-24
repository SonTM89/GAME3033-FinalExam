using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private float RotationPower = 0.15f;

    [SerializeField]
    private float HorizontalDampling = 20;

    [SerializeField]
    private GameObject FollowTarget;

    private Transform FollowTargetTransform;
    private Vector2 PreviousMouseData = Vector2.zero;

    private InputMaster GameInput;


    private void Awake()
    {
        GameInput = new InputMaster();

        FollowTargetTransform = FollowTarget.transform;
    }


    private void OnEnable()
    {
        GameInput.Enable();
        GameInput.Player.Look.performed += OnLook;
    }


    private void OnDisable()
    {
        GameInput.Disable();
        GameInput.Player.Look.performed -= OnLook;
    }


    public void OnLook(InputAction.CallbackContext delta)
    {
        if (PauseMenu.isPaused) return;

       // Debug.Log(delta.ReadValue<Vector2>());
        Vector2 aimValue = delta.ReadValue<Vector2>();

        Quaternion addedRoration = Quaternion.AngleAxis(Mathf.Lerp(PreviousMouseData.x, aimValue.x, 1f / HorizontalDampling) * RotationPower, transform.up);

        FollowTargetTransform.rotation *= addedRoration;

        PreviousMouseData = aimValue;

        transform.rotation = Quaternion.Euler(0, FollowTargetTransform.rotation.eulerAngles.y, 0);

        FollowTargetTransform.localEulerAngles = Vector3.zero;
    }
}
