using UnityEngine;
using UnityEngine.UI;

public class AnswerUI : MonoBehaviour
{
    public int AnswerIndex;

    public Image CorrectImage;
    public Image IncorretImage;    
    
    public void OnAnswerClicker()
    {
        bool result = QuestionsManager.Instance.AnswerQuestion(AnswerIndex);
        if(result){
            CorrectImage.gameObject.SetActive(true);
        }
        else{
            IncorretImage.gameObject.SetActive(true);
        }
    }
}
