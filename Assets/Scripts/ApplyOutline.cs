using UnityEngine;

public class ApplyOutline : MonoBehaviour
{
    public Material outlineMaterial;
    public float outlineThickness = 0.005f;
    public Color outlineColor = Color.black;

    private Renderer rend;
    private GameObject outlineObject;

    void Start()
    {
        // Ottieni il renderer del GameObject originale
        rend = GetComponent<Renderer>();

        // Crea un nuovo GameObject per l'outline
        outlineObject = new GameObject("Outline");
        outlineObject.transform.parent = transform;
        outlineObject.transform.localPosition = Vector3.zero;
        outlineObject.transform.localRotation = Quaternion.identity;
        outlineObject.transform.localScale = Vector3.one;

        // Aggiungi un MeshFilter e MeshRenderer all'outlineObject
        MeshFilter meshFilter = outlineObject.AddComponent<MeshFilter>();
        meshFilter.mesh = GetComponent<MeshFilter>().mesh;

        MeshRenderer meshRenderer = outlineObject.AddComponent<MeshRenderer>();
        meshRenderer.material = outlineMaterial;
        meshRenderer.material.SetColor("_OutlineColor", outlineColor);
        meshRenderer.material.SetFloat("_OutlineThickness", outlineThickness);

        // Imposta il renderer del GameObject principale per usare il suo materiale originale
        rend.material = rend.material;
    }
}
