using System.Collections.Generic;

namespace ResourceSharing.Api.Models
{
    public enum DataType
    {
        Int,
        String,
        Bool
    }

    public class Field
    {
        public string Name { get; init; }
        public DataType Type { get; init; }
        public bool Required { get; init; }
        public string Default { get; init; }
    }

    public class CreateSchemaRequest
    {
        public IEnumerable<Field> Fields { get; set; }
    }
}
