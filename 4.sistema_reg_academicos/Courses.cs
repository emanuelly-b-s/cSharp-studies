public class Course
{
    public string Name { get; set; }
    public int CargaHoraria { get; set; }
    public int CodCurso { get; set; }

    public Course(string name, int cargaHoraria, int codCurso)
    {
        this.Name = name;
        this.CargaHoraria = cargaHoraria;
        this.CodCurso = codCurso;
    }

   
}
