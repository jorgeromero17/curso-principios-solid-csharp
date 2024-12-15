using SingleResponsability;

StudentRepository studentRepository = new();

ExportHelper exportHelper = new ExportHelper();

// Define cómo formatear cada estudiante como una fila CSV
exportHelper.ExportCsv(
    studentRepository.GetAll(),
    student => {
      return $"{student.Id};{student.Fullname};{string.Join("|", student.Grades)}";
    },
    "Students.csv"
);


Console.WriteLine("Proceso Completado");