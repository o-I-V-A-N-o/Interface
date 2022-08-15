using TMPro;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private GameObject _manager;
    
    private void Update()
    {
        SetHealth();
    }

    private void SetHealth()
    {
        GetComponent<TextMeshProUGUI>().text = _manager.GetComponent<GameManager>().Health.ToString();
    }
}
