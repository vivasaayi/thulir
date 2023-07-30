namespace Thulir.ReactUI;

public class AspNetConstants
{
    public static String FILE_UPLOAD_FOLDER_NAME = "";
    public static String S3_CACHE_FOLDER = "";

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
        
        string s3CacheFolder = Environment.GetEnvironmentVariable("S3_CACHE_FOLDER");

        if (string.IsNullOrEmpty(s3CacheFolder))
        {
            S3_CACHE_FOLDER = "/Users/rajanp/datasets_local/";
        }
        else
        {
            S3_CACHE_FOLDER = s3CacheFolder;
        }
        
        Console.Out.WriteLine("FILE_UPLOAD_FOLDER_NAME:" + FILE_UPLOAD_FOLDER_NAME);
        Console.Out.WriteLine("S3_CACHE_FOLDER:" + S3_CACHE_FOLDER);
    }
}