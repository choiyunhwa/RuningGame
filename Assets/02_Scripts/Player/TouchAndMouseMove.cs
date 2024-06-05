using UnityEngine;
using UnityEngine.InputSystem;

public class TouchAndMouseMove : MonoBehaviour
{
    public PlayerController playerController;


    public HealthBar healthBar ;
    public InputActionAsset inputActions;
    private InputAction pointerPositionAction;
    private Camera mainCamera;
    private float minX = -1000f;
    private float maxX = 1000f;

    private void Awake()
    {
        var playerControls = inputActions.FindActionMap("PlayerControls");
        pointerPositionAction = playerControls.FindAction("PointerPosition");
        mainCamera = Camera.main;
    }

    private void OnEnable()  //����Ʈ ��ġ �Է� Ȱ��
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

    private void OnDisable() //����Ʈ ��ġ �Էº� Ȱ��
    {
        if (pointerPositionAction != null)
        {
            pointerPositionAction.Disable();
        }
    }
    //
    void Update()
    {
        if (pointerPositionAction != null)
        {

            Vector2 pointerPosition = pointerPositionAction.ReadValue<Vector2>();
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(pointerPosition.x, pointerPosition.y, mainCamera.nearClipPlane));
           // Debug.Log(worldPosition);
            worldPosition.z = transform.position.z; // Z�� ���� 0���� �����Ͽ� 2D ��� �̵�
            worldPosition.y = transform.position.y;
            // �̵� ���� ����

            worldPosition.x = Mathf.Clamp(worldPosition.x, minX, maxX);
            transform.position = worldPosition;
        }
    }
    //�÷��̾ ���� ����ġ��  �ǰ� 10 �����δ� 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            healthBar.TakeDamage(10);
        }
    }
}
