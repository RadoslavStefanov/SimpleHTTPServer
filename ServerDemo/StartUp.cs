using ServerDemo;
using ServerDemo.HTTP;
using ServerDemo.Responces;
public class StartUp
{
    private const string DownloadForm = @"<form action='/Content' method='POST'>
    <input type='submit' value ='Download Sites Content' /> 
</form>";

    private const string HtmlForm = @"<form action='/HTML' method='POST'>
        Name: <input type='text' name='Name'/>
        Age: <input type='number' name='Age'/>
        <input type='submit' value ='Save' />
</form>";

    private const string FileName = "content.txt";

    public static async Task Main() 
    => await new HttpServer(routes=>routes
    .MapGet("/", new TextResponse("Hello from the server!"))
    .MapGet("/Redirect", new RedirectResponse("https://softuni.org/"))
    .MapGet("/HTML", new HtmlResponse(StartUp.HtmlForm))
    .MapPost("/HTML", new TextResponse("",StartUp.AddFormDataAction))
    .MapGet("/Content", new HtmlResponse(StartUp.DownloadForm))
    .MapPost("/Content", new TextFileResponse(StartUp.FileName)))
    .Start();

    private static void AddFormDataAction(Request request, Response response)
    {
        response.Body = "";
        foreach (var (key,value) in request.Form)
        {
            response.Body += $"{key} - {value}";
            response.Body += Environment.NewLine;
        }
    }
    

}