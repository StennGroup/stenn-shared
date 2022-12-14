using System.Linq;
using Stenn.Shared.Csv;

namespace Stenn.Shared.Tables
{
    public sealed class CsvTableWriter : ITableWriter<string?>
    {
        private CsvBuilder _builder = default!;
        private readonly char _delemiter;

        public CsvTableWriter(char delemiter = ',')
        {
            _delemiter = delemiter;
        }

        /// <inheritdoc />
        public void SetColumns(params TableWriterColumn[] columns)
        {
            _builder = new CsvBuilder(_delemiter);
            _builder.AddRow(columns.Select(c => c.Name).ToArray());
        }

        /// <inheritdoc />
        public void WriteRow(string?[] values)
        {
            _builder.AddRow(values);
        }

        public string Build()
        {
            return _builder.Build();
        }
    }
}