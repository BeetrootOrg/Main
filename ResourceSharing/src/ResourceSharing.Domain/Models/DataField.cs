namespace ResourceSharing.Domain.Models
{
    public enum DataType
    {
        Int,
        String,
        Bool
    }

    public class DataField
    {
        public string Name { get; init; }
        public DataType Type { get; init; }
        public bool Required { get; init; }
        public string Default { get; init; }
    }
}
