using UnityEngine;
using UnityEngine.UI;

public class BackgroundScript : MonoBehaviour
{
    [SerializeField] public float speed;
    private Vector2 offset = Vector2.zero;
    private Material material;

    private void Start()
    {
        material = GetComponent<Image>().material;
        offset = material.GetTextureOffset("_MainTex");
    }

    private void Update()
    {
        offset.x += speed * Time.deltaTime;
        material.SetTextureOffset("_MainTex", offset);
    }
}
