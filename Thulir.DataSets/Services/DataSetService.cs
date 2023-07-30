using System.Collections;
using Thulir.DataSets.Models;

namespace Thulir.DataSets.Services;

public class DataSetService
{
    private Dictionary<string, DataSet> DataSets;
    
    public DataSetService()
    {
        InitializeDataSets();
    }

    private void InitializeDataSets()
    {
        DataSets = new Dictionary<string, DataSet>();
        
        DataSets.Add("Cotton", getDatSet("Cotton", "Bud,Flower,Stem,Cotton"));
        DataSets.Add("Tomato", getDatSet("Tomato", "Bud,Flower,Stem,Tomato"));
        DataSets.Add("Chilli", getDatSet("Chilli", "Green,Red"));
    }

    private DataSet getDatSet(String name, String labelsString)
    {
        DataSet ds = new DataSet();
        ds.Name = name;

        String[] labels = labelsString.Split(",");

        foreach (var label in labels)
        {
            Label lbl = new Label();
            lbl.LabelName = label;
            
            ds.Labels.Add(lbl);
        }
        
        return ds;
    }

    public List<String> GetAllDataSetNames()
    {
        List<String> names = new List<string>();

        foreach (var ds in DataSets)
        {
            names.Add(ds.Value.Name);
        }

        return names;
    }

    public Dictionary<string, DataSet> GetDataSetsWithLabels()
    {
        return DataSets;
    }

    public List<String> GetLabelsForDataSet(string dataSetName)
    {
        List<String> labels = new List<string>();

        foreach (var label in DataSets[dataSetName].Labels)
        {
            labels.Add(label.LabelName);
        }

        return labels;
    }

    public List<string> GetImagsFor(string folderName, string dataset, string label)
    {
        string path = Path.Join(folderName, dataset, label);
        String[] files = Directory.GetFiles(path);

        List<string> result = new List<string>();

        foreach (var file in files)
        {
            string temp = file.Replace(folderName, "");
            result.Add(temp);
        }
        
        return result;
    }
}