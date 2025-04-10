using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Filtering;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using System.Collections.Generic;

    public class TagHoverAndSelectFilter : MonoBehaviour, IXRSelectFilter, IXRHoverFilter
{
    [Tooltip("Tag accettato per l'interazione.")]
    //public string acceptedTag = "ToyPiece";
    [SerializeField] public List<string> acceptedTags = new List<string>();

    [Tooltip("Tag per cui si deve negare l'hover (visual preview).")]
    //public string negatedTagHover = "ToyBase";
    [SerializeField] public List<string> negatedTags = new List<string>();

        public bool canProcess => isActiveAndEnabled;

    // Filtro per il socket (snap)
    public bool Process(IXRSelectInteractor interactor, IXRSelectInteractable interactable)
    {
        string tag = interactable.transform.tag;

        for (int i = 0; i < acceptedTags.Count; i++)
        {
            if (tag == acceptedTags[i]) return true;
        }
        for (int i = 0; i < negatedTags.Count; i++)
        {
            if (tag == negatedTags[i]) return true;
        }

        return false;


    }
    

    // Filtro per l'hover (visual preview snap)
    public bool Process(IXRHoverInteractor interactor, IXRHoverInteractable interactable)
    {
        string tag = interactable.transform.tag;
        /*if (tag == acceptedTag)
            return true;

        if (tag == negatedTagHover)
            return false;
        */

        for (int i = 0; i < acceptedTags.Count; i++)
        {
            if (tag == acceptedTags[i]) return true;
        }

        for (int i = 0; i < negatedTags.Count; i++)
        {
            if (tag == negatedTags[i]) return false;
        }

        return false;
    }
}