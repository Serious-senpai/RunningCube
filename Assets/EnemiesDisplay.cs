using UnityEngine;
using TMPro;

public class EnemiesDisplay : MonoBehaviour
{
    private TextMeshProUGUI textMesh
    {
        get => GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        textMesh.text = $" Enemies: {Enemy.enemiesLeft}";
    }
}
