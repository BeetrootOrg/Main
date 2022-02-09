using ResourceSharing.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ResourceSharing.Domain.Services
{
    internal class DataFiledsHelper
    {
        public static bool IsSchemaValid(IEnumerable<DataField> fields)
        {
            var set = new HashSet<string>(fields.Select(field => field.Name), StringComparer.OrdinalIgnoreCase);

            if (set.Count != fields.Count())
            {
                return false;
            }

            return fields.All(field =>
            {
                if (string.IsNullOrWhiteSpace(field.Name))
                {
                    return false;
                }

                return field.Type switch
                {
                    DataType.Int => field.Default == null || int.TryParse(field.Default, out var _),
                    DataType.String => true,
                    DataType.Bool => field.Default == null || bool.TryParse(field.Default, out var _),
                    _ => throw new ArgumentOutOfRangeException(nameof(field.Type))
                };
            });
        }
    }
}
