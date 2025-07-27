using UnityEngine;

public class FallingLogTrap : MonoBehaviour
{
    public bool isFalling = true;

    public void Still() {
        isFalling = false;
    }
}