using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AnswerUI : MonoBehaviour
{
    public int AnswerIndex;

    public Image CorrectImage;
    public Image IncorretImage;    
    private bool _canBeClicked = true;

    private void OnEnable()
    {
        QuestionsManager.OnNewQuestionLoaded += ResetValues;
        QuestionsManager.OnAnswerProvided += AnswerProvided;
    }

    private void OnDisable()
    {
        QuestionsManager.OnNewQuestionLoaded -= ResetValues;
        QuestionsManager.OnAnswerProvided -= AnswerProvided;
    }
    public void OnAnswerClicker()
    {   if(_canBeClicked)
        {
            bool result = QuestionsManager.Instance.AnswerQuestion(AnswerIndex);
            if(result){
                CorrectImage.DOFade(1,.5f);
            }
            else{
                IncorretImage.DOFade(1,.5f);
            }
        }
    }

    void AnswerProvided(){
        _canBeClicked = false;
    }

    void ResetValues()
    {
        CorrectImage.DOFade(0, .2f);
        IncorretImage.DOFade(0, .2f);
        _canBeClicked = true;
    }
}
