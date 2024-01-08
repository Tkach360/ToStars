using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DarkScreenController : MonoBehaviour
{
    [SerializeField] private float FadeSpeed = 0f;

    IEnumerator Start()
    {
        Image FadeImage = GetComponent<Image>();
        Color FadeColor = FadeImage.color;

        while(FadeColor.a > 0f)
        {
            FadeColor.a -= FadeSpeed * Time.deltaTime;
            FadeImage.color = FadeColor;
            yield return null;
        }

        gameObject.SetActive(false);
    }
}
