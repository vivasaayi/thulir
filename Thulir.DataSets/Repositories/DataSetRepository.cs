using Thulir.Core.Dals;
using Thulir.DataSets.Models;

namespace Thulir.DataSets.Repositories;

public class DataSetRepository
{
    public void AddImage()
    {
        var dal = PostgresDal.GetInstance();
        
        Console.WriteLine("");
    }
}