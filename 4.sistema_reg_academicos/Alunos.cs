public class Student
{
    public string Name { get; set; }
    public int CodMatricula{ get; set; }
    public int CodCurso { get; set; }

    public float nota;

    public float Nota
    {
        get
        {
            return this.nota;
        }
        set
        {
            this.nota = value;
        }
    } 

    public Student(string name, int codMatricula, int codCurso)
    {
        this.Name = name;
        this.CodMatricula = codMatricula;
        this.CodCurso = codCurso;
    }
}
