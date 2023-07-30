namespace Thulir.Core.Utils;

public class FileUtils
{
    public static string[] GetFilesFromFolder(string folderName)
    {
        var fileNames = Directory.GetFiles(folderName);
        return fileNames;
    }

    public static string GetFileNameFromS3Path(string s3Path)
    {
        if (s3Path.EndsWith(".jpg"))
        {
            var startIndex = s3Path.LastIndexOf("/");
            
            return s3Path.Substring(startIndex + 1,  s3Path.Length - (startIndex + 1));    
        }

        return null;
    }
}