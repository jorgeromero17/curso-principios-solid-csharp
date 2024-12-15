using System.Text;

namespace SingleResponsability
{
  public class ExportHelper
  {
    public void ExportCsv<T>(IEnumerable<T> items, Func<T, string> formatRow, string fileName = "Export.csv")
    {
        StringBuilder sb = new StringBuilder();

      // Agregar encabezados si corresponde
      if (items.Any())
      {
        var headers = typeof(T).GetProperties()
          .Select(prop => prop.Name)
          .Aggregate((current, next) => $"{current};{next}");
        sb.AppendLine(headers);
      }

      // Agregar filas de datos
      foreach (var item in items)
      {
        sb.AppendLine(formatRow(item));
      }

      // Guardar archivo
      string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
      File.WriteAllText(path, sb.ToString(), Encoding.Unicode);

    }

  }
}