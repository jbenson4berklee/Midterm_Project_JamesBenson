using System.Collections;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _playerHealth;
    [SerializeField] private TextMeshProUGUI _playerScore;

    private int _score;

    public int Score
    {
        set
        {
            _score = value;
            _playerScore.text = _score.ToString();
        }
        
        get  => _score;
    }

    private MouseMovement _character;

    private void Start()
    {
        _character = GetComponent<MouseMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectable"))
        {
            Score++;
            _playerScore.text = Score.ToString();
        }
    }
}
