using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightPlaceable : MonoBehaviour, IPlaceable
{
    [SerializeField] private GameObject objectToPlace;
    [SerializeField] private ItemData itemData;

    public void PlaceObject(ItemData data)
    {
        if (data == itemData)
        {
            if (objectToPlace != null) objectToPlace.SetActive(true);
        }
    }    
}
