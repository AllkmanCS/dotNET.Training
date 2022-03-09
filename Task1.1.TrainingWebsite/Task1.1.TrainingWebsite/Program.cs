using Task1._1.TrainingWebsite.Entities;
using Task1._1.TrainingWebsite.Entities.TrainingMaterial;
using Task1._1.TrainingWebsite.Extensions;

try
{
#region textMaterial data
    string textMaterialText = @"U4irqg4AF0pCfvCk04f1Q0ZWRlUZsT14mOBzoMAvckqUPuOXJ8Ug
Jhdu9JYZxA98ZdItAR5plyHKo1q3ksDojfsZI0XVZauP8273xO0Jp39cf2izwmmdA17DKlilLX
a0PbDceqa7HG9YETXPHk1lJwmsj8cY3JTLY0YjxzTlCjNT8lBrkTVy8SMtrKsADXTeFtORqSqP
A0MDDzoPnRtwfm6fKAbBJeKbWhcWgLwkAKQL9dcYBlrgsN4898Ca1DZlrqbPF1iRMejL2iMUQ0
vZg7s23IhUptbJ17DLnO9uoydC4AIdmekSaAj2FojKmg3emqpr1WAkzqhtOW
zwmPHEQJbVHN85wAGNJj5hKOQuuyouD2LgNq20e3kZ3yxyDWQ0xnDZqxI6ZlpRYkjqY6WesPKF
N9x8vwiep8Pn3zYfCWtYgBzqOp0DVvGBvOi3GrM7OOERpamNqqmRWAWnqlc5lze5rilUI5WAxo
804TB6t20qhKxIKopNmPVrTZW7glC6o3gg9LvhV2IEyVQ05TxAQdvvFRyF67ReN4wikDLIYz6E
6PQfhq0zpF2b2lSv7wGKdrFkHyLY6wWoQ1pqbrYD5BOfruWvugLmAH7DGttxceDKUjdj6sdDFK
";
    string textMaterialDescription = "Some text material....";
    #endregion
#region videoMaterial data
    string videoURI = "https://www.youtube.com/watch?v=Tr9NwrA-wmQ&t=898s";
    string splashScreenURI = "SplachScreenURI";
#endregion

    var training = new TrainingLesson();
    var textMaterial = new TextMaterial(textMaterialText, textMaterialDescription);
    var videoMaterial = new VideoMaterial();
    var networkResource = new NetworkResource();

    //assign Guid to entity
    textMaterial.AssignGuid();
    Console.WriteLine(textMaterial.Id);

    //Console.WriteLine(textMaterial.Text);
    //Console.WriteLine(textMaterial.Description);

    training.Add(textMaterial);
    //training.Add(videoMaterial);
    training.Add(networkResource);

    var trainingType = training.GetTrainingType();
    Console.WriteLine(trainingType);

}
catch (ArgumentException)
{

    Console.WriteLine("Text length must not exceed 1000 characters.");
}