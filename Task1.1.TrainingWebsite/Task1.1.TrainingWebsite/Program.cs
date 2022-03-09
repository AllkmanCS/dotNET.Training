using Task1._1.TrainingWebsite.Entities;
using Task1._1.TrainingWebsite.Entities.TrainingMaterial;
using Task1._1.TrainingWebsite.Enums;
using Task1._1.TrainingWebsite.Extensions;

try
{
    #region TrainingLesson data
    var trainingDescription = "TextLesson Description";
    var training = new TrainingLesson(trainingDescription);
    #endregion
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
    var textMaterial = new TextMaterial(textMaterialText, textMaterialDescription);
    #endregion
    #region NetworkResource data
    string networkResourceDescription = "Official MS dotNET tutorials";
    string networkResourceUri = "https://docs.microsoft.com/en-us/dotnet/core/tutorials/";
    var networkResource = new NetworkResource(networkResourceDescription, networkResourceUri, LinkType.Html);

    #endregion
    #region videoMaterial data
    string videoContentDescription = "Advanced C# video - Events";
    string videoContentUri = "https://www.youtube.com/watch?v=Tr9NwrA-wmQ&t=898s";
    string splashScreenUri = "SplachScreenURI";
    var videoMaterial = new VideoMaterial(videoContentDescription, videoContentUri, splashScreenUri, VideoFormat.Mp4);
    #endregion
    #region TrainingWebsite testing
    //assign Guid to entity
    textMaterial.AssignGuid();
    Console.WriteLine(textMaterial.Id);
    
    Console.WriteLine(textMaterial.Equals(textMaterial)); //true (null and other obj = false)

    //testing exeption for string being over 1000 length
    //Console.WriteLine(textMaterial.Text);
    //Console.WriteLine(textMaterial.Description);

    training.Add(textMaterial); // [0]
    training.Add(networkResource); // [1]
    //training.Add(videoMaterial); // [2]

    var trainingType = training.GetTrainingType();
    Console.WriteLine(trainingType);

    //cloning
    var trainingClone = training.Clone();
    var textMaterialClone = trainingClone.TrainingMaterials[0] as TextMaterial;
    var networkResourceClone = trainingClone.TrainingMaterials[1] as NetworkResource;

    Console.WriteLine($"Clonned Training Description: {trainingClone.Description = "Other TextLesson"}");
    Console.WriteLine($"Original Training Description: {training.Description}");

    #endregion
}
catch (ArgumentException)
{
    Console.WriteLine("Text length must not exceed 1000 characters.");
}
catch (InvalidOperationException)
{
    Console.WriteLine("Cannot assign new Guid if entity already has one assigned");
}