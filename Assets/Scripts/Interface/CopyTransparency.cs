using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CopyTransparency : MonoBehaviour
{
    [SerializeField] Image target;
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI textMeshPro;

    Color colour;
    float timer = 0f;
    float duration = 1f;

    void Update() {
        if (image != null && textMeshPro != null) {
            Debug.LogError("Copy Transparency Cannot Contain 2 Overloads!");
            return;
        }

        if (image != null) {
            colour = image.color;
        }
        if (textMeshPro != null) {
            colour = textMeshPro.color;
        }

        if (timer < duration) {
            timer += Time.deltaTime;
            colour.a = Mathf.Lerp(0, 1, timer / duration);

            if (image != null) {
                image.color = colour;
            }
            if (textMeshPro != null) {
                textMeshPro.color = colour;
            }
        }
    }
}