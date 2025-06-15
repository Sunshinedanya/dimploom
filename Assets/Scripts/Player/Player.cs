using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class Player : MonoBehaviour
    {
        public static Player instance;

        public GameOverTimerManager gameOverTimerManager;
        
        private void Awake()
        {
            if (instance != null)
                Destroy(gameObject);
            
            instance = this;
        }

        public int ArtCount { private set; get; }
        public bool HasKeys{ private set; get; }

        public UnityEvent<int> ArtAdded;
        public UnityEvent<bool> GotKey;

        public void KeyPickUp()
        {
            HasKeys = true;
            gameOverTimerManager.gameObject.SetActive(true);
            GotKey.Invoke(HasKeys);
        }

        public void ArtefactPickUp()
        {
            ArtCount++;
            
            ArtAdded.Invoke(ArtCount);
        }
    }
}