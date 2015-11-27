using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InputFields : MonoBehaviour, IEventSystemHandler, IPointerClickHandler,  IUpdateSelectedHandler, ISubmitHandler, ICanvasElement
{
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnSubmit(BaseEventData eventData)
    {
        Debug.Log("ISubmitHandler");
    }

    public void OnUpdateSelected(BaseEventData eventData)
    {
        Debug.Log("IUpdateSelectedHandler");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("OnPointerClick");
    }
    public bool IsDestroyed()
    {
        Debug.Log("IsDestroyed");
        return true;
    }

    public void Rebuild(CanvasUpdate executing)
    {
        Debug.Log("Rebuild");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
