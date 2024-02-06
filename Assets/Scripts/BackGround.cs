using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGround : MonoBehaviour
{
    [SerializeField] private RawImage gradientImage;
    private Texture2D _background;

    private void Start()
    {
        _background = new Texture2D(1, 2);
        _background.wrapMode = TextureWrapMode.Clamp;
        _background.filterMode = FilterMode.Bilinear;
        RandomColor(Random.ColorHSV(0.5f, 1f, 1f, 1f, 0.5f, 1f), Random.ColorHSV(0f, 0.5f, 1f, 1f, 0.5f, 1f));
    }

    private void RandomColor(Color color1, Color color2)
    {
        _background.SetPixels(new Color[] { color1, color2 });
        _background.Apply();
        gradientImage.texture = _background;
    }
}
