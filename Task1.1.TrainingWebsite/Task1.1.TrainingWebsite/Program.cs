using Task1.One.TrainingWebsite.Entities;
using Task1.One.TrainingWebsite.Entities.TrainingMaterial;
using Task1.One.TrainingWebsite.Enums;

try
{
    #region textMaterial data
    string textMaterialDescription = "Some text material...";
    string textMaterialText = @"12345678910VERYLongtext....................";
    var textMaterial = new TextMaterial(textMaterialDescription, textMaterialText);
    Console.WriteLine(textMaterial.Description);
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
    Console.WriteLine($"VideoMaterial Id:{videoMaterial.Id}");
    var isVideoMaterialUri = Uri.TryCreate(videoMaterialPath, UriKind.Absolute, out createdVideoMaterialUri);
    var isSplashScreenUri = Uri.TryCreate(splashScreenPath, UriKind.Absolute, out createdSplashScreenUri);
    Console.WriteLine($"Video Material URI created: {isVideoMaterialUri}");
    Console.WriteLine($"Splash Screen URI created: {isSplashScreenUri}");
    #endregion

    #region TrainingWebsite testing
    List<EntityBase> trainingMaterials = new List<EntityBase>();
    string trainingDescription = "TextLesson Description";
    ulong trainingVersion = 1020;
    var training = new TrainingLesson(trainingDescription, trainingMaterials, trainingVersion);
    training.SetVersion(trainingVersion);
    Console.WriteLine($"TrainingLesson Id:{training.Id}");
    //simply converting byte array to string
    byte[] trainingVersionArray = training.ReadVersion(trainingVersion);
    Console.WriteLine(string.Join(".", trainingVersionArray));
    Console.WriteLine(training.Description);
    Console.WriteLine(textMaterial.Equals(textMaterial)); //true
    training.Add(textMaterial);
    training.Add(networkResource);
    training.Add(videoMaterial);
    var trainingType = training.GetTrainingType();
    Console.WriteLine($"Training type: {trainingType}");
    #endregion

    #region Cloning
    var trainingClone = training.Clone();
    Console.WriteLine($"Clonned training Id: {trainingClone.Id}");
    var textMaterialClone = trainingClone.TrainingMaterials[0] as TextMaterial;
    var networkResourceClone = trainingClone.TrainingMaterials[1] as NetworkResource;
    var videoMaterialClone = trainingClone.TrainingMaterials[2] as VideoMaterial;
    Console.WriteLine($"TextMaterial test for equals vs TextMaterialClone: {textMaterial.Equals(textMaterialClone)}"); //false
    Console.WriteLine($"Clonned Training Description: {trainingClone.Description = "Other TrainingLesson"}");
    Console.WriteLine($"Original Training Description: {training.Description}");
    Console.WriteLine($"Clonned VideoMaterial Description: {videoMaterialClone.Description = "Other VideoMaterial"}");
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
catch (NullReferenceException)
{
    Console.WriteLine("The resource you tried to access was not found.");
}