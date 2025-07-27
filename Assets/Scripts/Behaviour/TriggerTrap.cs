using UnityEngine;

public class TriggerTrap : MonoBehaviour
{
    [SerializeField] GameObject trap;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            print("TAG!");
            trap.SetActive(true);
            Destroy(gameObject);
        }
    }
}