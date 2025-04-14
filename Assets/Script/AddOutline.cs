using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using static UnityEngine.Rendering.GPUSort;

public class AddOutline : MonoBehaviour
{

    [SerializeField] private Material OutlineMaterial;

    public void EnableOutline(HoverEnterEventArgs args)
    {
        var meshRenderer = args.interactableObject.transform.GetComponent<MeshRenderer>();
        var materials = meshRenderer.materials;

        // Prevent duplicates
        foreach (var mat in materials)
        {
            if (mat == OutlineMaterial)
                return;
        }

        // Add the outline material
        Material[] newMaterials = new Material[materials.Length + 1];
        for (int i = 0; i < materials.Length; i++)
            newMaterials[i] = materials[i];

        newMaterials[newMaterials.Length - 1] = OutlineMaterial;
        meshRenderer.materials = newMaterials;

    }

    public void DisableOutline(HoverExitEventArgs args)
    {
        var meshRenderer = args.interactableObject.transform.GetComponent<MeshRenderer>();
        if (meshRenderer == null) return;

        var materials = meshRenderer.materials;
        List<Material> newMaterials = new List<Material>();

        foreach (var mat in materials)
        {
            // Compare by name or shader if needed
            if (mat.name.Contains(OutlineMaterial.name)) continue;
            // Or: if (mat.shader == OutlineMaterial.shader) continue;

            newMaterials.Add(mat);
        }

        meshRenderer.materials = newMaterials.ToArray();
    }
}
