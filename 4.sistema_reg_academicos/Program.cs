using System;

int qtdCourses = 0;

while (true)
{
    Console.WriteLine("\n1 - Cadastrar Curso\n2 - Mostrar Cursos\n3 - Cadastrar Aluno\n4 - Inserir notas\n5 - Estatisticas\n6 - Sair.\n");

    int option = int.Parse(Console.ReadLine());
    Console.Clear();

    if (option == 6)
        break;

    else if (option == 1)
    {
        qtdCourses ++;
        Console.WriteLine("\nNome do curso: ");
        string name = (Console.ReadLine());
        Console.WriteLine("Carga Horaria total: ");
        int cargaHoraria = int.Parse(Console.ReadLine());
        Course course = new Course(name, cargaHoraria, qtdCourses);
        ControlSystem.AddCourse(course);
        Console.Clear();
    }


    else if (option == 2)
    {
        for (int i = 0; i < (ControlSystem.Courses.Count); i++)
        {
            Console.WriteLine($"\n{ControlSystem.Courses[i].CodCurso} - Curso: {ControlSystem.Courses[i].Name} - Carga Horaria: {ControlSystem.Courses[i].CargaHoraria}");
        }
        Console.ReadKey();
        Console.Clear();
    }
    else if (option == 3)
    {
        if (ControlSystem.Courses.Count <= 0)
        {
            Console.WriteLine("\nCadastre um curso antes de inserir um aluno.");
            break;
        }
        Console.WriteLine("Nome do aluno: ");
        string name = (Console.ReadLine());
        Console.WriteLine("Cod de Matricula: ");
        int codMatricula = int.Parse(Console.ReadLine());
        for (int i = 0; i < (ControlSystem.Courses.Count); i++)
        {
            Console.WriteLine($"\n{ControlSystem.Courses[i].CodCurso} - Curso: {ControlSystem.Courses[i].Name} - Carga Horaria: {ControlSystem.Courses[i].CargaHoraria}");
        }
        Console.WriteLine("\nCod de curso: ");
        int codCurso = int.Parse(Console.ReadLine()) - 1;
        Student student = new Student(name, codMatricula, codCurso);
        ControlSystem.AddStudent(student);
        Console.Clear();
    }
    else if (option == 4)
    {
        bool stdcourse = false;
        if (ControlSystem.Courses.Count <= 0)
        {
            Console.WriteLine("\nNenhum curso inserido ainda.");
            break;
        }
        Console.WriteLine("\nPara qual curso as notas seram inseirdas: ");
        for (int i = 0; i < (ControlSystem.Courses.Count); i++)
        {
            Console.WriteLine($"\n{ControlSystem.Courses[i].CodCurso} - Curso: {ControlSystem.Courses[i].Name} - Carga Horaria: {ControlSystem.Courses[i].CargaHoraria}\n");
        }

        int indexCourse = int.Parse(Console.ReadLine()) - 1;
        
        if (indexCourse < 0 && indexCourse > ControlSystem.Courses.Count - 1)
        {
            Console.WriteLine("\nCodigo de curso não encontrado");
        }
        else
        {
            for (int i = 0; i < (ControlSystem.Students.Count); i++)
            {
                if(ControlSystem.Students[i].CodCurso == indexCourse)
                {
                    Console.WriteLine($"Nota do aluno {ControlSystem.Students[i].Name}: ");
                    float notaAluno = float.Parse(Console.ReadLine());
                    if (notaAluno > 0 && notaAluno < 10)
                    {
                        ControlSystem.Students[i].Nota = notaAluno;
                    }
                    stdcourse = true;
                    
                    if (!stdcourse)
                    {
                        Console.WriteLine("Nenhum aluno cadastrado neste curso.");
                    }   
                }
            }
        }
        Console.Clear();
    }
    else if (option == 5)
    {
        Console.WriteLine($"Total de alunos cadastrados: {ControlSystem.Students.Count}\n");
        Console.WriteLine($"Total de cursos cadastrados: {ControlSystem.Courses.Count}\n");
        for (int i = 0; i < (ControlSystem.Courses.Count); i++)
        {
            int alunos_aprovados = 0, alunos_reprovados = 0;
            for (int j = 0; j < ControlSystem.Students.Count; j++)
            {
                if (ControlSystem.Students[j].Nota > 7)
                    alunos_aprovados++;
                else
                    alunos_reprovados++;
            }
            Console.WriteLine($"Total de alunos aprovados no curso {ControlSystem.Courses[i].Name}: {alunos_aprovados}\n");
            Console.WriteLine($"Total de alunos reprovados no curso {ControlSystem.Courses[i].Name}: {alunos_reprovados}\n");
        }
    }
}