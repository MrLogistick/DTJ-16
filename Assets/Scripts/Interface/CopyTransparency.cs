using UnityEngine;
using UnityEngine.UI;

public class CopyTransparency : MonoBehaviour
{
    [SerializeField] Image target;

    void Update() {
        var colour = GetComponent<Image>().color;
        colour.a = target.color.a;
        GetComponent<Image>().color = colour;
    }
}