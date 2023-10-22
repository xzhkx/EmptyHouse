using UnityEngine;

public class ShowInformation : MonoBehaviour
{
    [SerializeField] private GameObject normalPhase, inforPhase;

    private void Update()
    {
        if(Input.GetKey(KeyCode.Backspace))
        {
            SetPhase();
        }    
    }

    private void SetPhase()
    {
        inforPhase.SetActive(false);
        normalPhase.SetActive(true);
    }
}
