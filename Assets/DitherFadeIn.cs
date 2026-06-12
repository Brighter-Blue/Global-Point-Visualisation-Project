using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DitherFadeIn : MonoBehaviour

{
    public float delay = 2f;
    public float fadeDuration = 2f;

    private Renderer rend;
    private MaterialPropertyBlock block;

    private Color baseColor;

    void Awake()
    {
        rend = GetComponent<Renderer>();
        block = new MaterialPropertyBlock();

        baseColor = rend.sharedMaterial.GetColor("_BaseColor");
    }

    void Start()
    {
        SetAlpha(0f);
        StartCoroutine(FadeSequence());
    }

    IEnumerator FadeSequence()
    {
        yield return new WaitForSeconds(delay);

        float time = 0f;

        while (time < fadeDuration)
        {
            float t = Mathf.SmoothStep(0f, 1f, time / fadeDuration);
            SetAlpha(Mathf.Lerp(0f, 1f, t));

            time += Time.deltaTime;
            yield return null;
        }

        SetAlpha(1f);
    }

    void SetAlpha(float value)
    {
        rend.GetPropertyBlock(block);

        Color c = baseColor;
        c.a = value;

        block.SetColor("_BaseColor", c);
        rend.SetPropertyBlock(block);
    }
}

