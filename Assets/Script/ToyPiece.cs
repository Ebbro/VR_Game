using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using static UnityEngine.Rendering.GPUSort;

public class ToyPiece : MonoBehaviour
{
    [SerializeField] private string PieceType = null;

    [SerializeField] public bool IsBase = false;

    [SerializeField] public int NumberOfPieces = 1;
    [SerializeField] private List<GameObject> Pieces = new List<GameObject>();

    
    [SerializeField] private List<string> ToyTypes = new List<string>();

    

    private List<XRSocketInteractor> socket = new List<XRSocketInteractor>();

    [Tooltip("Interaction layer to assign to object when inserted into this socket.")]


    [SerializeField] InteractionLayerMask voidlayer = InteractionLayerMask.GetMask();




    private void Awake()
    {

        //ActivateSocketListeners();
    }


    private void ActivateSocketListeners()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (IsBase)
            {
                socket.Add(transform.GetChild(i).GetComponent<XRSocketInteractor>());
                if (transform.GetChild(i).GetComponent<XRSocketInteractor>() != null) socket[i] = transform.GetChild(i).GetComponent<XRSocketInteractor>();

                if (socket[i] != null)
                {
                    socket[i].selectEntered.AddListener(OnObjectInserted);
                    socket[i].selectExited.AddListener(OnObjectRemoved);
                }
                else Debug.Log(i + " socket is null");
            }
        }
    }
    private void OnObjectInserted(SelectEnterEventArgs obj)
    {

        if (IsBase)
        {
            Debug.Log("Object enetered socket");
            GameObject piece = obj.interactableObject.transform.gameObject;
            Debug.Log(piece.name);
            AddPieceToList(piece);
            piece.GetComponent<ToyPiece>().DeactivateGrabInteractor();
        }
    }

    private void DeactivateGrabInteractor()
    {
        if (gameObject.GetComponent<XRGrabInteractable>() != null) gameObject.GetComponent<XRGrabInteractable>().interactionLayers = voidlayer;
        //if (gameObject.GetComponent<XRGrabInteractable>().enabled != null) gameObject.GetComponent<XRGrabInteractable>().enabled = false;
    }

    private void OnObjectRemoved(SelectExitEventArgs obj)
    {
        Debug.Log("Object exited socket");
        GameObject piece = obj.interactableObject.transform.gameObject;
        RemovePiaceToList(piece);
    }




    private void AddPieceToList(GameObject obj)
    {
        if (IsBase)
        {
            Pieces.Add(obj);
            NumberOfPieces++;

            AddTypeToList(obj);


        }
    }

    private void AddTypeToList(GameObject obj)
    {
        if (obj.GetComponent<ToyPiece>().PieceType != null)
        {
            ToyTypes.Add(obj.GetComponent<ToyPiece>().PieceType);
        }
    }

    private void RemovePiaceToList(GameObject obj)
    {
        for (int i = 0; i < Pieces.Count; i++)
        {
            if (Pieces[i].gameObject == obj) Pieces.Remove(Pieces[i]);
            NumberOfPieces--;
        }
    }

    private void ActivateToyPiece()
    {
        transform.tag = "Attachable";
    }


    private void DeactivateToyPiece()
    {
        transform.tag = "Default";
    }

    private void AddToMerged()
    {
        /*if (IsBase) {
            Pieces.Add()
            Types.Add
                }*/
    }


    private void SetInteractionManager(GameObject InteractionManager)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<XRSocketInteractor>().interactionManager = InteractionManager.GetComponent<XRInteractionManager>();
        }


    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //GameObject InteractionManager = GameObject.FindGameObjectWithTag("InteractionManager");
        ActivateSocketListeners();
        AddTypeToList(gameObject);

    }
    public string GetPieceType()
{
    return PieceType;
}

public int GetNumberOfPieces()
{
    return NumberOfPieces;
}
public void DistruggiCompletamente()
{
    if (!IsBase) return;

    // Distrugge prima tutti i pezzi collegati
    foreach (GameObject pezzo in Pieces)
    {
        if (pezzo != null)
        {
            Destroy(pezzo);
        }
    }

    // Infine distrugge se stesso (la base)
    Destroy(gameObject);
}
}

