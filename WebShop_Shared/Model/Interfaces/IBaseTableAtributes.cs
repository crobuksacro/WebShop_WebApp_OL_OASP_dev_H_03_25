namespace WebShop_Shared.Model.Interfaces
{
    public interface IBaseTableAtributes
    {
        DateTime Created { get; set; }
        long Id { get; set; }
        DateTime? Updated { get; set; }
        bool Valid { get; set; }
    }
}
