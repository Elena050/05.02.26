public class ReportGenerator
{
    public string GeneratePDFReport(List<Data> data)
    {
        var filteredData = PrepareData(data);
        return $"PDF: {filteredData.Count} items";
    }

    public string GenerateCSVReport(List<Data> data)
    {
        var filteredData = PrepareData(data);
        return string.Join(",", filteredData.Select(d => d.Value));
    }

    public string GenerateHTMLReport(List<Data> data)
    {
        var filteredData = PrepareData(data);
        return $"<html><body>Items: {filteredData.Count}</body></html>";
    }

    private List<Data> PrepareData(List<Data> data)
    {
        return data
            .Where(d => d.IsValid)
            .OrderBy(d => d.Date)
            .ToList();
    }
}
