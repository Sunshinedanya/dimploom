    using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class GlowingObject : MonoBehaviour
{
    public Material glowMaterial;
    private Renderer originalRenderer;
    private Material[] originalMaterials;

    public void StartGlow(float duration)
    {
        StartCoroutine(GlowCoroutine(duration));
    }

    private IEnumerator GlowCoroutine(float duration)
    {
        originalMaterials = originalRenderer.materials;

        originalRenderer.material = glowMaterial;

        yield return new WaitForSeconds(duration);

        originalRenderer.materials = originalMaterials;
    }

    private void Awake()
    {
        originalRenderer = GetComponent<Renderer>();
    }
}