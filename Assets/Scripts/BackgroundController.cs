using UnityEngine;
using UnityEngine.UI;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] public float speed;
    private Image image;
    private Material material;
    private Vector2 offset = Vector2.zero;

    private void Start()
    {
        image = GetComponent<Image>();
        offset = image.material.GetTextureOffset("_MainTex");
    }

    private void Update()
    {
        offset.x += speed * Time.deltaTime;
        image.material.SetTextureOffset("_MainTex", offset);
    }

    public void SetBackground(Material newMaterial, float newSpeed)
    {
        speed = newSpeed;
        image.material = newMaterial;
        offset.x = 0f;
    }
}
