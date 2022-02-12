using Newtonsoft.Json;
using System.Collections.Generic;

namespace ResourceSharing.Domain.Models.Db
{
    internal class SchemaDto
    {
        public int Id { get; init; }
        public string SchemaName { get; init; }
        public IEnumerable<DataField> Fields { get; init; }
        public string SchemaDefinition => JsonConvert.SerializeObject(Fields);
    }
}
