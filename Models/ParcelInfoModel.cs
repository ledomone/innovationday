namespace BlazorServerSignalRApp.Models;

public class ParcelInfoModel
{
    public int ParcelNumber { get; set; }
    public string Status { get; set; }
    public DateTime? LastModificationDate { get; set; }
}