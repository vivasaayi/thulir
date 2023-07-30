namespace Thulir.ReactUI;

public class AspNetConstants
{
    public static String FILE_UPLOAD_FOLDER_NAME = "";

    public static void Init()
    {
        string fileUploadFolderName = Environment.GetEnvironmentVariable("FILE_UPLOAD_FOLDER_NAME");

        if (string.IsNullOrEmpty(fileUploadFolderName))
        {
            FILE_UPLOAD_FOLDER_NAME = "/Users/rajanp/file_uploads/";
        }
        else
        {
            FILE_UPLOAD_FOLDER_NAME = fileUploadFolderName;
        }
        
        Console.Out.WriteLine("FILE_UPLOAD_FOLDER_NAME:" + FILE_UPLOAD_FOLDER_NAME);
    }
}