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

        List<Label> cottonLabels = new List<Label>();
        cottonLabels.Add(new Label()
        {
            LabelName = "Bud"
        });
        
        cottonLabels.Add(new Label()
        {
            LabelName = "Flower"
        });
        
        cottonLabels.Add(new Label()
        {
            LabelName = "Stem"
        });
        
        cottonLabels.Add(new Label()
        {
            LabelName = "Cotton"
        });

        DataSet cottonDataSet = new DataSet()
        {
            Name = "Cotton",
            Location = "CottonLocation",
        };

        cottonDataSet.Labels = cottonLabels;
        
        DataSets.Add(cottonDataSet.Name, cottonDataSet);
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
}