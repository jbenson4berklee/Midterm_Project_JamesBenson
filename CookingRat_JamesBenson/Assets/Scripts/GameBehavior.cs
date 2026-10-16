using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UIElements;

public class GameBehavior : MonoBehaviour
{
   public static GameBehavior Instance;

   [Header("UI Elements")] 
   private Utilities.GameState _state;
   private float _timer;
   public TextMeshProUGUI TimerGUI;

   public float Timer
   {
      get => _timer;

      set
      {
         _timer = value;
         
         int minutes = Mathf.FloorToInt(_timer / 60);
         int seconds = Mathf.FloorToInt(_timer % 60);
         
         TimerGUI.text = $"{minutes:00}:{seconds:00}";
      }
   }

   
   
   public Utilities.GameState State
   {
      get => _state;
      set
      {
         _state = value;
         _pauseUI.enabled = State == Utilities.GameState.Pause;
      }
   }

   [SerializeField] private TMP_Text _pauseUI;
   [SerializeField] private float Score = 0;
   
   //enemy Prefab
   //enemy Parent
   //private GameObject _enemy

   //Singleton pattern wack
   void Awake()
   {
      if (Instance == null)
      {
         Instance = this;
         DontDestroyOnLoad(gameObject);
      }
      else if (Instance != this)
      {
         Destroy(gameObject);
      }
   }

   void Start()
   {
      ResetScore();
      State = Utilities.GameState.Play;
   }

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.P))
      {
         State = State == Utilities.GameState.Pause ? 
            Utilities.GameState.Pause : 
            Utilities.GameState.Play;
      }

      if (State == Utilities.GameState.Play)
      {
         Timer += Time.deltaTime;
         
         //respawn items and reset created Objects
      }
   }

   void ResetScore()
   {
      Score = 0;
   }

   public void ScorePoint()
   {
      Score++;
      
      //can add reset score value here if wanted
   }
   
   //Power up function with Coroutine for individual players
   
}
