using Dapper;
using Thulir.Core.Dals;
using Thulir.Core.DbModels;
using Npgsql;
using Label = Thulir.Core.DbModels.Label;

namespace Thulir.Core.Repositories;

public class LabelsRepository
{
    private PostgresDal _dal;

    public LabelsRepository()
    {
        _dal = PostgresDal.GetInstance();
        SqlMapper.AddTypeHandler(new GenericTypeHandler<List<Label>>());
        SqlMapper.AddTypeHandler(new GenericTypeHandler<Point>());
    }

    public async Task<ImageLabel> GetLabels(Guid imageId)
    {
        try
        {
            string command = @"SELECT * FROM imagelabels where imageid=@imageid";

            var result = await _dal.ExecuteQuery<ImageLabel>(command, new
            {
                imageid = imageId
            });

            if (result.Any())
            {
                return result.ToList()[0];    
            }

            return new ImageLabel();
        }
        catch (PostgresException err)
        {
            Console.WriteLine(err);
        }

        return new ImageLabel();
    }

    public async Task SaveLabels(Guid imageId, ImageLabel label)
    {
        try
        {
            // string command = @"INSERT INTO imagelabels(imageid, labels, createddate, lastmodifieddate) 
            //                     values(@imageid, @labels, @createddate, @lastmodifieddate)";

            string command = @"INSERT INTO imagelabels (imageid, labels, createddate, lastmodifieddate) 
                                values(@imageid, @labels, @createddate, @lastmodifieddate)
                                ON CONFLICT (imageid) DO UPDATE 
                                  SET labels = excluded.labels, 
                                      lastmodifieddate = excluded.lastmodifieddate;";

            await _dal.InsertRecord(command, new
            {
                imageid = imageId,
                labels = label.Labels,
                createddate = DateTime.Now,
                lastmodifieddate = DateTime.Now
            });
        }
        catch (PostgresException err)
        {
            Console.WriteLine(err);
        }
    }
}