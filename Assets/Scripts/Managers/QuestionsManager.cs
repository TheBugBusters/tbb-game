using System;

public class QuestionsManager : Singleton<QuestionsManager>
{

    public string CategoryName;
    public QuestionsUI Question;
    private GameManagerGame _gameManager;

 
    private void Start(){
        
        _gameManager = GameManagerGame.Instance;

        LoadNextQuestion();
    }

    void LoadNextQuestion(){
        var newQuestion = _gameManager.GetQuestionForCategory(CategoryName);
        
        if(newQuestion != null)
        {
            Question.PopulateQuestion(newQuestion);
        }
        
    }
}
