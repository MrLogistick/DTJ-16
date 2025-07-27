using UnityEngine;

public class MoveCam : MonoBehaviour
{
    [SerializeField] Transform cameraPos;

    void Update() {
        transform.position = cameraPos.position;
    }
}
