using Task1._1.TrainingWebsite.Entities;
using Task1._1.TrainingWebsite.Entities.TrainingMaterial;
using Task1._1.TrainingWebsite.Enums;
using Task1._1.TrainingWebsite.Extensions;

try
{
    #region TrainingLesson data
    var trainingDescription = "TextLesson Description";
    ulong trainingVersion = 1020;
    var training = new TrainingLesson(trainingDescription);
    training.SetVersion(trainingVersion);
    byte[] trainingVersionArray = training.ReadVersion(trainingVersion);
    Console.WriteLine(string.Join(".", trainingVersionArray)); 
    training.AssignGuid();
    #endregion

    #region textMaterial data
    string textMaterialText = @"U4irqg4AF0pCfvCk04f1Q0ZWRlUZsT14mOBzoMAvckqUPuOXJ8Ug
Jhdu9JYZxA98ZdItAR5plyHKo1q3ksDojfsZI0XVZauP8273xO0Jp39cf2izwmmdA17DKlilLX
a0PbDceqa7HG9YETXPHk1lJwmsj8cY3JTLY0YjxzTlCjNT8lBrkTVy8SMtrKsADXTeFtORqSqP
A0MDDzoPnRtwfm6fKAbBJeKbWhcWgLwkAKQL9dcYBlrgsN4898Ca1DZlrqbPF1iRMejL2iMUQ0
vZg7s23IhUptbJ17DLnO9uoydC4AIdmekSaAj2FojKmg3emqpr1WAkzqhtOW
zwmPHEQJbVHN85wAGNJj5hKOQuuyouD2LgNq20e3kZ3yxyDWQ0xnDZqxI6ZlpRYkjqY6WesPKF
N9x8vwiep8Pn3zYfCWtGttxceDKUjdj6sdDFK
";
    string textMaterialDescription = "Some text material....";
    var textMaterial = new TextMaterial(textMaterialDescription, textMaterialText);
    #endregion

    #region NetworkResource data
    string networkResourceDescription = "Official MS dotNET tutorials";
    Uri createdNetworkResourceUri = null;
    string networkResourceUriString = "https://docs.microsoft.com/en-us/dotnet/core/tutorials/";

    var networkResource = new NetworkResource(networkResourceDescription, networkResourceUriString, LinkType.Html);
    bool isNetworkResourceUri = Uri.TryCreate(networkResourceUriString, UriKind.Absolute, out createdNetworkResourceUri);
    Console.WriteLine($"Network Resource URI created: {isNetworkResourceUri}");
    #endregion

    #region videoMaterial data
    string videoMaterialDescription = "Intro to Advanced C# - Events";
    ulong videoMaterialVersion = 10222;
    Uri createdVideoMaterialUri = null;
    string videoMaterialPath = Path.Combine(Environment.CurrentDirectory, @"Assets\", "intro.mp4");
    Uri createdSplashScreenUri = null;
    string splashScreenPath = Path.Combine(Environment.CurrentDirectory, @"Assets\", "splashscreen.jpg");

    var videoMaterial = new VideoMaterial(videoMaterialDescription, videoMaterialPath, splashScreenPath, VideoFormat.Mp4, videoMaterialVersion);
    videoMaterial.SetVersion(videoMaterialVersion);
    byte[] videoMaterialVersionArray = videoMaterial.ReadVersion(videoMaterialVersion);
    Console.WriteLine(string.Join(".", videoMaterialVersionArray));

    var isVideoMaterialUri = Uri.TryCreate(videoMaterialPath, UriKind.Absolute, out createdVideoMaterialUri);
    var isSplashScreenUri = Uri.TryCreate(splashScreenPath, UriKind.Absolute, out createdSplashScreenUri);
    Console.WriteLine($"Video Material URI created: {isVideoMaterialUri}");
    Console.WriteLine($"Splash Screen URI created: {isSplashScreenUri}");
    #endregion

    #region TrainingWebsite testing
    //assign Guid to entity
    textMaterial.AssignGuid();
    Console.WriteLine(textMaterial.Id);
    Console.WriteLine(textMaterial.Equals(textMaterial)); //true
    training.Add(textMaterial); // [0]
    training.Add(networkResource); // [1]
    training.Add(videoMaterial); // [2]
    var trainingType = training.GetTrainingType();
    Console.WriteLine($"Training type: {trainingType}");
    #endregion

    #region Cloning
    var trainingClone = training.Clone();
    Console.WriteLine($"Clonned training Id: {trainingClone.Id}");
    var textMaterialClone = trainingClone.TrainingMaterials[0] as TextMaterial;
    var networkResourceClone = trainingClone.TrainingMaterials[1] as NetworkResource;
    var videoMaterialClone = trainingClone.TrainingMaterials[2] as VideoMaterial;
    Console.WriteLine($"TextMaterial test for equals vs TextMaterialClone: {textMaterial.Equals(textMaterialClone)}"); 
    Console.WriteLine($"Clonned Training Description: {trainingClone.Description = "Other TextLesson"}");
    Console.WriteLine($"Original Training Description: {training.Description}");
    Console.WriteLine($"Clonned TextMaterial Description: {textMaterialClone.Description = "Other TextMaterial"}");
    Console.WriteLine($"Clonned NetworkResource Description: {networkResourceClone.Description = "Other Network Resource"}");
    Console.WriteLine($"Clonned VideoMaterial Description: {videoMaterialClone.Description = "Other Video Material"}");
    #endregion
}
catch (ArgumentOutOfRangeException)
{
    Console.WriteLine("Text length must not exceed 1000 characters.");
}
catch (InvalidOperationException)
{
    Console.WriteLine("Cannot assign new Guid if entity already has one assigned");
}