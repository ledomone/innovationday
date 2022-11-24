using MongoDB.Bson;

namespace BlazorServerSignalRApp.Models;

public class ParcelInfoModel
{
    public ObjectId Id { get; set; }
    public int ParcelNumber { get; set; }
    public string Status { get; set; }
    public DateTime? LastModificationDate { get; set; }
}