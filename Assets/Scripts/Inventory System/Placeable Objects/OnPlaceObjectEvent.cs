using UnityEngine;
using System;

public class OnPlaceObjectEvent : MonoBehaviour
{
    public static Action<ItemData> PlaceObjectEventHandler;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IPlaceable placeable = collision.GetComponent<IPlaceable>();
        if(placeable != null)
        {
            PlaceObjectEventHandler += placeable.PlaceObject;
        }    
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IPlaceable placeable = collision.GetComponent<IPlaceable>();
        if (placeable != null)
        {
            PlaceObjectEventHandler -= placeable.PlaceObject;
        }
    }
}
