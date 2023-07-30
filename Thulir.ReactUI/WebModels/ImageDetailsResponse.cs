using Thulir.Core.DbModels;

namespace Thulir.ReactUI.WebModels;

public class ImageDetailsResponse
{
    public SourceImage SourceImage { get; set; }
    public ImageLabel ImageLabels { get; set; }
}