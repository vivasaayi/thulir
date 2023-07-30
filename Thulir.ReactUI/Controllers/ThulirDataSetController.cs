using System.Net;
using Microsoft.AspNetCore.Mvc;
using Thulir.DataSets.Models;
using Thulir.DataSets.Services;

namespace Thulir.ReactUI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ThulirDataSetController : Controller
{
    private readonly DataSetService _dataSetService = new DataSetService();
    
    [HttpGet("available-data-sets")]
    public async Task<List<String>> GetAvailableDataSets(string? userName)
    {
        if (String.IsNullOrEmpty(userName))
        {
            userName = "";
        }

        var dataSetNames = _dataSetService.GetAllDataSetNames();
        return dataSetNames;
    }
    
    [HttpGet("available-data-sets-with-labels")]
    public async Task<List<DataSet>> GetAvailableDataSetsWithLabels()
    {
        var dataSetNames = _dataSetService.GetDataSetsWithLabels();
        return dataSetNames.Values.ToList();
    }
    
    [HttpGet("labels")]
    public async Task<List<String>> GetLabels(string? dataset)
    {
        if (String.IsNullOrEmpty(dataset))
        {
            dataset = "";
        }

        var labels = _dataSetService.GetLabelsForDataSet(dataset);
        return labels;
    }
}