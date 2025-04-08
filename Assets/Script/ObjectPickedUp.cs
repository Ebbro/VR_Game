using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class HandGrabTracker : MonoBehaviour
{
    public XRBaseInteractor leftHandInteractor;
    public XRBaseInteractor rightHandInteractor;

    public XRBaseInteractable leftHeldItem;
    public XRBaseInteractable rightHeldItem;

    private void OnEnable()
    {
        if (leftHandInteractor)
        {
            leftHandInteractor.selectEntered.AddListener(OnLeftGrab);
            leftHandInteractor.selectExited.AddListener(OnLeftRelease);
        }

        if (rightHandInteractor)
        {
            rightHandInteractor.selectEntered.AddListener(OnRightGrab);
            rightHandInteractor.selectExited.AddListener(OnRightRelease);
        }
    }

    private void OnDisable()
    {
        if (leftHandInteractor)
        {
            leftHandInteractor.selectEntered.RemoveListener(OnLeftGrab);
            leftHandInteractor.selectExited.RemoveListener(OnLeftRelease);
        }

        if (rightHandInteractor)
        {
            rightHandInteractor.selectEntered.RemoveListener(OnRightGrab);
            rightHandInteractor.selectExited.RemoveListener(OnRightRelease);
        }
    }

    private void OnLeftGrab(SelectEnterEventArgs args)
    {
        leftHeldItem = args.interactableObject as XRBaseInteractable;

        Debug.Log($"Left hand grabbed {leftHeldItem.name}");
    }

    private void OnLeftRelease(SelectExitEventArgs args)
    {
        Debug.Log($"Left hand released {leftHeldItem?.name}");
        leftHeldItem = null;
    }

    private void OnRightGrab(SelectEnterEventArgs args)
    {
        rightHeldItem = args.interactableObject as XRBaseInteractable;
        Debug.Log($"Right hand grabbed {rightHeldItem.name}");
    }

    private void OnRightRelease(SelectExitEventArgs args)
    {
        Debug.Log($"Right hand released {rightHeldItem?.name}");
        rightHeldItem = null;
    }
}