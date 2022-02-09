namespace ResourceSharing.Domain.Models.Db
{
    internal class SchemaDto
    {
        public int Id { get; init; }
        public string SchemaName { get; init; }
        public string SchemaDefinition { get; init; }
    }
}
