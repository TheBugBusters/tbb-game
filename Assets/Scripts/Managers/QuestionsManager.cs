using System;

public class QuestionsManager : Singleton<QuestionsManager>
{

    public string CategoryName;
    public QuestionsUI Question;
    private GameManagerGame _gameManager;
    private QuestionModel _currentQuestion;

 
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
        
    }


    public bool AnswerQuestion(int answerIndex)
    {
        return _currentQuestion.CorrectAnswerIndex == answerIndex;
    }
}
