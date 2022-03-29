using Microsoft.Extensions.Logging.Console;
using System.Net;

var url = "https://docs.microsoft.com/en-us/dotnet/";

var httpRequest = (HttpWebRequest)WebRequest.Create(url);

//runing check with exp: for() loop
var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
{
    var result = streamReader.ReadToEnd();
}
//if 
Console.WriteLine(httpResponse.StatusCode);
