using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCam : MonoBehaviour
{
    [SerializeField] float sensX;
    [SerializeField] float sensY;

    [SerializeField] Transform orientation;

    float xRot;
    float yRot;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {
        Vector2 mouseVector = Mouse.current.delta.ReadValue();

        yRot += mouseVector.x * sensX;
        xRot -= mouseVector.y * sensY;
        xRot = Mathf.Clamp(xRot, -90, 90);

        transform.rotation = Quaternion.Euler(xRot, yRot, 0);
        orientation.rotation = Quaternion.Euler(0, yRot, 0);
    }
}
