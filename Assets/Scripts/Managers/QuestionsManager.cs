using System;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class QuestionsManager : Singleton<QuestionsManager>
{
    public static Action OnNewQuestionLoaded;
    public static Action OnAnswerProvided;
    public Transform CorrectImage;
    public Transform IncorrectImage;
    public string CategoryName;
    public QuestionsUI Question;
    private GameManagerGame _gameManager;
    private QuestionModel _currentQuestion;  
    public string nomeDesafio;

 
    private void Start(){
        
        _gameManager = GameManagerGame.Instance;

        LoadNextQuestion();
    }

    void LoadNextQuestion(){
        _currentQuestion = _gameManager.GetQuestionForCategory(CategoryName);
        
        if(_currentQuestion != null)
        {
            Question.PopulateQuestion(_currentQuestion);
        }
        
        OnNewQuestionLoaded?.Invoke();
    }


    public bool AnswerQuestion(int answerIndex)
    {
        OnAnswerProvided?.Invoke();
        bool isCorrect = _currentQuestion.CorrectAnswerIndex == answerIndex;

        if(isCorrect){
            TweenResult(CorrectImage);            
            VoltarFase();          
        }
        else
        {
            TweenResult(IncorrectImage);
        }
        return isCorrect;
    }


    void TweenResult(Transform resultTransform)
    {
        Sequence result = DOTween.Sequence();
        result.Append(resultTransform.DOScale(1,.5f).SetEase(Ease.OutBack)); 
        result.AppendInterval(2f);
        result.Append(resultTransform.DOScale(0, .2f).SetEase(Ease.Linear));

        result.AppendCallback(LoadNextQuestion);
    }

    private void VoltarFase(){
        SceneManager.LoadScene("fase1");
    }
}
