namespace Thulir.DataSets.Models;

public class DataSet
{
    public String Name { get; set; }
    public String Location{ get; set; }

    public List<Label> Labels{ get; set; }

    public DataSet()
    {
        Labels = new List<Label>();
    }
}