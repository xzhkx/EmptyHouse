using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBarController : MonoBehaviour
{
    private Slider healthSlider;
    [SerializeField] MovingStickControl movingStickControl;

    private void Awake()
    {
        healthSlider = GetComponent<Slider>();
        healthSlider.maxValue = 100;
        healthSlider.value = 100;
    }

    public void TakeHealthDamage(float healthAmount)
    {
        healthSlider.value -= healthAmount;
        if (healthSlider.value <= 0) SetLosePhase();
    }

    public void TakeHealingAmount(float healthAmount)
    {
        healthSlider.value += healthAmount;
    }

    private void SetLosePhase()
    {
        movingStickControl.ResetPhase();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }    
}
