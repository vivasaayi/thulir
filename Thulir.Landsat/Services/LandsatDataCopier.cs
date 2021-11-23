using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Amazon.Runtime.Internal;
using Thulir.Landsat.Models;

namespace Thulir.Landsat.Services
{
    public class LandsatDataCopier: ILandsatDataCopier
    {
        private Dictionary<string, string> _stBandNameToFileMap;
        private Dictionary<string, string> _srBandNameToFileMap;

        public LandsatDataCopier()
        {
            _stBandNameToFileMap = new Dictionary<string, string>();
            _srBandNameToFileMap = new Dictionary<string, string>();
            
            _stBandNameToFileMap.Add("thumb_large", "thumb_small.jpeg");
            _stBandNameToFileMap.Add("lwir11", "ST_B10.TIF");
            _stBandNameToFileMap.Add("ATRAN", "ST_ATRAN.TIF");
            _stBandNameToFileMap.Add("CDIST", "ST_CDIST.TIF");
            _stBandNameToFileMap.Add("DRAD", "ST_DRAD.TIF");
            _stBandNameToFileMap.Add("URAD", "ST_URAD.TIF");
            _stBandNameToFileMap.Add("TRAD", "ST_TRAD.TIF");
            _stBandNameToFileMap.Add("EMIS", "ST_EMIS.TIF");
            _stBandNameToFileMap.Add("EMSD", "ST_EMSD.TIF");
            _stBandNameToFileMap.Add("QA", "ST_QA.TIF");
            _stBandNameToFileMap.Add("qa_radsat", "QA_RADSAT.TIF");
            _stBandNameToFileMap.Add("qa_pixel", "QA_PIXEL.TIF");
            
            _srBandNameToFileMap.Add("coastal", "SR_B1.TIF");
            _srBandNameToFileMap.Add("blue", "SR_B2.TIF");
            _srBandNameToFileMap.Add("green", "SR_B3.TIF");
            _srBandNameToFileMap.Add("red", "SR_B4.TIF");
            _srBandNameToFileMap.Add("nir08", "SR_B5.TIF");
            _srBandNameToFileMap.Add("swir16", "SR_B6.TIF");
            _srBandNameToFileMap.Add("swir22", "SR_B7.TIF");
            _srBandNameToFileMap.Add("qa_aerosol", "QA_AEROSOL.TIF");
        }

        private Dictionary<string, string> GetSTFileNames(string fileName)
        {
            Dictionary<string, string> fileNames = new Dictionary<string, string>();
            
            foreach (var key in _stBandNameToFileMap.Keys)
            {
                fileNames.Add(key, fileName + _stBandNameToFileMap[key]);    
            }

            return fileNames;
        }

        
        private Dictionary<string, string> GetSRFileNames(string fileName)
        {
            Dictionary<string, string> fileNames = new Dictionary<string, string>();
            
            foreach (var key in _srBandNameToFileMap.Keys)
            {
                fileNames.Add(key, fileName + _srBandNameToFileMap[key]);    
            }

            return fileNames;
        }

        public async Task CopyDataSets(string fileName, List<string> filters)
        {
            var files = GetFileNamesToCopy(fileName, filters);
            
            GenerateAWSCopyCommands(files);   
        }

        private void GenerateAWSCopyCommands(List<string> filesTobeCopied)
        {
            var prefix = "aws s3 cp s3://usgs-landsat/";
            var sufix = " s3://landsat-dataasets --request-payer requester";

            var allCommands = "";
            
            foreach (var file in filesTobeCopied)
            {
                var command = prefix + file + sufix + "\n";
                allCommands += command;
            }
            
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "s3_copy_commands.sh")))
            {
                outputFile.WriteLine(allCommands);
            }
        }

        public List<string> GetFileNamesToCopy(string fileName, List<string> filters)
        {
            Console.WriteLine("Copying DataSets.." + fileName);
            LandsatCatalogItem[] links;
                
            using (var sr = new StreamReader(fileName))
            {
                links =  JsonSerializer.Deserialize<LandsatCatalogItem[]>(sr.ReadToEnd());
            }

            var filesToBeCopied = new List<string>();
            
            foreach (var link in links)
            {
                if (link.Rel != "item") continue;

                var bandFileName = link.Href.Replace("https://landsatlook.usgs.gov/data/", "");
                
                if(bandFileName.Contains("SR_stac.json")) continue;
                
                bandFileName = bandFileName.Replace("ST_stac.json", "").Replace("SR_stac.json", "");
                
                var stFileNames = GetSTFileNames(bandFileName);
                var srFileNames = GetSRFileNames(bandFileName);

                var allFiles = new Dictionary<string, string>(); 
                
                foreach (var item in stFileNames)
                {
                    allFiles.Add(item.Key, item.Value);
                }
                
                foreach (var item in srFileNames)
                {
                    allFiles.Add(item.Key, item.Value);
                }
                
                if (!filters.Any())
                {
                    filesToBeCopied.AddRange(allFiles.Values);
                }
                else
                {
                    foreach (var item in filters)
                    {
                        filesToBeCopied.Add(allFiles[item]);
                    }
                }
            }

            return filesToBeCopied;
        }
    }
}