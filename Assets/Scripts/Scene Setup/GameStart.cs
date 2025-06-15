using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scene_Setup
{
    public class GameStart : MonoBehaviour
    {
        [SerializeField] private List<GameObject> objectsToInvokeAfterCutScene;
        [SerializeField] private List<GameObject> objectsToDivokeAfterCutScene;

        [SerializeField] private Image bg;

        [SerializeField] private GameObject leaderboard;
        [SerializeField] private Button _skipButton;
        private bool _firstLaunch = true;
        
        private void Start()
        {
            if (_firstLaunch)
                StartFirstDialogue();
            else
                GameOver();
            
            _skipButton.onClick.AddListener((() =>
            {
                DialogueController.instance.ClearDialogueInstance();
            }));
        }

        private void StartFirstDialogue()
        {
            _firstLaunch = false;
            
            DialogueController.instance.NewDialogueInstance("Когда-то это место было просто баней. ");
            DialogueController.instance.NewDialogueInstance(
                "Люди смеялись здесь, грели кости после долгой дороги");
            DialogueController.instance.NewDialogueInstance(
                "Но потом пришли [EXAGGERATE]Они[/EXAGGERATE] ");
            DialogueController.instance.NewDialogueInstance(
                "Те, кто смотрит из зеркал. ");
            DialogueController.instance.NewDialogueInstance("Те, чьи тени двигаются чуть медленнее, чем должны. ");
            DialogueController.instance.NewDialogueInstance(
                "Те, кто шепчет вам в темноте: [EXAGGERATE]\"Посмотри на меня...\"[/EXAGGERATE] ");
            DialogueController.instance.NewDialogueInstance("Теперь баня помнит. И ждёт. ");
            DialogueController.instance.NewDialogueInstance(
                "Здесь нет случайностей.");
            DialogueController.instance.NewDialogueInstance("Каждый ваш шаг, каждый взгляд, каждый вдох — уже часть игры. ");
            DialogueController.instance.NewDialogueInstance("Проверьте, закрыта ли дверь. ");
            DialogueController.instance.NewDialogueInstance("И никогда... ");
            DialogueController.instance.NewDialogueInstance(
                "[EXAGGERATE]никогда[/EXAGGERATE] не смотрите в зеркало....");

            DialogueController.instance.NewDialogueInstance(
                "О-о, новые гости...", "1");
            DialogueController.instance.NewDialogueInstance(
                "Садитесь, отдохните. Только не шумите — баня старая, всё скрипит.", "1");
            DialogueController.instance.NewDialogueInstance("Он медленно встаёт, поправляет печь");
            DialogueController.instance.NewDialogueInstance(
                "То труба течёт, то дверь не закрывается... Ладно, починю. Вы пока парьтесь.", "1");
            DialogueController.instance.NewDialogueInstance("Он уходит в предбанник.");

            DialogueController.instance.onDialogueFinished.AddListener(DelayBeforeFog);
        }

        private IEnumerator DelayBeforeFogCor()
        {
            DialogueController.instance.onDialogueFinished.RemoveListener(DelayBeforeFog);
            yield return new WaitForSeconds(3);

            bg.color = new Color(0, 0, 0, 255);

            DialogueController.instance.NewDialogueInstance("Внезапно свет выключается.");
            DialogueController.instance.NewDialogueInstance("Воздух густеет, становится трудно дышать");

            DialogueController.instance.NewDialogueInstance("Спите... Спите...", "2");
            DialogueController.instance.NewDialogueInstance("Ха-ха... Кажется, мы новых друзей нашли.", "3");
            
            DialogueController.instance.onDialogueFinished.AddListener(StartGame);
            DialogueController.instance.onDialogueFinished.AddListener(()=>  DialogueController.instance.onDialogueFinished.RemoveListener(StartGame));
        }

        private void DelayBeforeFog()
        {
            StartCoroutine(DelayBeforeFogCor());
        }

        private void StartEndDialogue()
        {
            DialogueController.instance.ClearDialogueInstance();
            
            DialogueController.instance.NewDialogueInstance("Ох, и шумные же вы... Ну что, попарились на славу?", "1");
            DialogueController.instance.NewDialogueInstance("Грустно с таким гостям прощаться...", "1");
            DialogueController.instance.NewDialogueInstance("Ну, с Богом... Только смотрите — не оглядывайтесь. А то... ", "1");
            DialogueController.instance.NewDialogueInstance("...а то пар ещё не весь вышел. ", "1");
            
            DialogueController.instance.NewDialogueInstance("Ну что, друг, на этом наше путешествие в таинственную баню подошло к концу.");
            DialogueController.instance.NewDialogueInstance("Надеюсь, удалось разгадать все её секреты... или хотя бы выбраться целыми.");
            DialogueController.instance.NewDialogueInstance("А теперь — время подвести итоги! ");
            DialogueController.instance.NewDialogueInstance("Но помните: старец всё ещё ждёт вас снова. ");
            DialogueController.instance.NewDialogueInstance("Может быть, однажды вы снова услышите скрип двери и почувствуете запах берёзового веника...");
            
            DialogueController.instance.onDialogueFinished.AddListener(EnableLeaderboard);
            DialogueController.instance.onDialogueFinished.AddListener(()=>  DialogueController.instance.onDialogueFinished.RemoveListener(EnableLeaderboard));
        }
        
        public void StartGame()
        {
            Debug.Log("game start");
            objectsToInvokeAfterCutScene.ForEach(obj => obj.SetActive(true));
            objectsToDivokeAfterCutScene.ForEach(obj => obj.SetActive(false));
            
            Timer.Instance.StartTimer();
        }

        public void GameOver()
        {
            Player.Player.instance.gameOverTimerManager.gameObject.SetActive(false);
            
            Timer.Instance.StopTimer();
            
            bg.color = new Color(255, 255, 255, 255);
            
            Debug.Log("game over");
            
            StartEndDialogue();
        }

        public void EnableLeaderboard()
        {
            leaderboard.SetActive(true);
        }
    }
}