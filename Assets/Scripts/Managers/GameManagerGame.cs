using System.Linq;

public class GameManagerGame: Singleton<GameManagerGame>
{
    public GameModel Configuration;

    public QuestionModel GetQuestionForCategory(string categoryName){
        CategoryModel categoryModel = Configuration.Categories.FirstOrDefault(category => category.CategoryName == categoryName);
        if(categoryModel != null){
            return categoryModel.Questions[0];
        }

        return null;
    }
}
