using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class ToyPiece : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        GameObject InteractionManager = GameObject.FindGameObjectWithTag("InteractionManager");
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<XRSocketInteractor>().interactionManager = InteractionManager.GetComponent<XRInteractionManager>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
