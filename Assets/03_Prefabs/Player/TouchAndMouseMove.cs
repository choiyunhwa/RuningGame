using UnityEngine;
using UnityEngine.InputSystem;

public class TouchAndMouseMove : MonoBehaviour
{
    public InputActionAsset inputActions;
    private InputAction pointerPositionAction;
    private Camera mainCamera;
    private float minX = -5f;
    private float maxX = 5f;

    private void Awake()
    {
        var playerControls = inputActions.FindActionMap("PlayerControls");
        pointerPositionAction = playerControls.FindAction("PointerPosition");
        mainCamera = Camera.main;
    }

    private void OnEnable()  //포인트 위치 입력 활성
    {
        if (pointerPositionAction != null)
        {
            pointerPositionAction.Enable();
        }
        else
        {
            Debug.LogError("PointerPosition action not found in PlayerControls ActionMap");
        }
    }

    private void OnDisable() //포인트 위치 입력비 활성
    {
        if (pointerPositionAction != null)
        {
            pointerPositionAction.Disable();
        }
    }

    void Update()
    {
        if (pointerPositionAction != null)
        {
            Vector2 pointerPosition = pointerPositionAction.ReadValue<Vector2>();

            Debug.Log($"Touch >> {pointerPosition}");
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(pointerPosition.x, pointerPosition.y, mainCamera.nearClipPlane));
            worldPosition.z = transform.position.z; // Z축 값을 0으로 고정하여 2D 평면 이동
            worldPosition.y = transform.position.y;
            // 이동 범위 제한
            worldPosition.x = Mathf.Clamp(worldPosition.x, minX, maxX);
            transform.position = worldPosition;

            Debug.Log($"WorldPos >> {worldPosition}");
        }
    }
}
