using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneInteractable : MonoBehaviour, ICollectable
{
    public void AddObject()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        if(CollectObjectEventControl.OnHandlerCollectObject != null)
        {
            CollectObjectEventControl.OnHandlerCollectObject -= AddObject;
        }    
    }
}
