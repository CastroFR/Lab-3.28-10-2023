using Microsoft.Data.SqlClient;

using (var contextdb = new Context())
{

    Console.WriteLine("\nLOS DATOS REGISTRADOS SON LOS SIGUIENTES: \n");

    foreach (var s in contextdb.evaluaciones)
    {
        Console.WriteLine("Id: " + s.id + "\nNombre: " + s.nombre + "\nPorcentaje: " + s.porcentaje + "\nFecha: " + s.fecha + "\nLugar: " + s.lugar + "\n");
    }

    Console.WriteLine("\nA continuacion se insertaran los datos");
    contextdb.Database.EnsureCreated();

    bool continuar = true;
    while (continuar)
    {
        Console.WriteLine("Ingrese un Id: ");
        int id = int.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese un Nombre: ");
        string nombre = Console.ReadLine();

        Console.WriteLine("Ingrese un Porcentaje: ");
        string porcentaje = Console.ReadLine();

        Console.WriteLine("Ingrese la Fecha: ");
        string fecha = (Console.ReadLine());

        Console.WriteLine("Ingrese el Lugar: ");
        string lugar = Console.ReadLine();

        var evaluaciones = new Evaluaciones
        {
            id = id,
            nombre = nombre,
            porcentaje = porcentaje,
            fecha = fecha,
            lugar = lugar
        };

        contextdb.Add(evaluaciones);
        contextdb.SaveChanges();

        Console.Write("¿Desea agregar otro registro? (S/N): ");
        string respuesta = Console.ReadLine();
        continuar = (respuesta.ToLower() == "s \n");

        Console.WriteLine("\nLOS DATOS REGISTRADOS SON LOS SIGUIENTES: \n");

        foreach (var s in contextdb.evaluaciones)
        {
            Console.WriteLine("Id: " + s.id + "\nNombre: " + s.nombre + "\nPorcentaje: " + s.porcentaje + "\nFecha: " + s.fecha + "\nLugar: " + s.lugar + "\n");
        }
    }

    Console.WriteLine("\n***************************************************************************");
    Console.WriteLine("********************************** MENÚ *********************************** ");
    Console.WriteLine("***************************************************************************");
    Console.Write("\nSeleccione la opción que desee realizar: ");
    Console.WriteLine("\n1-Modificar datos");
    string opcionSelect = Console.ReadLine();

    switch (opcionSelect)
    {
        case "1":
            Console.WriteLine("Ingrese el Id del registro que desea modificar: ");
            int id = int.Parse(Console.ReadLine());
            var evaluaciones = contextdb.evaluaciones.Find(id);

            if (evaluaciones != null)
            {

                Console.WriteLine("\nQue atributo desea modificar: \nIngrese el numero correspondiente: \nNombres(1), (2), Porcentaje(3), Fecha(4), Lugar(5)");
                string atributoModificado = Console.ReadLine();

                switch (atributoModificado)
                {


                    case "1":
                        Console.WriteLine("\nIntroduzca el nuevo nombre: ");
                        evaluaciones.nombre = Console.ReadLine();
                        Console.WriteLine("Apellido fué almacenado exitosamente ");
                        break;

                    case "2":
                        Console.WriteLine("\nIntroduzca el nuevo porcentaje: ");
                        evaluaciones.porcentaje = Console.ReadLine();
                        Console.WriteLine("Edad fué almacenada exitosamente ");
                        break;

                    case "3":
                        Console.WriteLine("\nIntroduzca la nueva Fecha: ");
                        evaluaciones.fecha = Console.ReadLine();
                        Console.WriteLine("Sexo fué almacenado exitosamente ");
                        break;

                    case "4":
                        Console.WriteLine("\nIntroduzca el nuevo lugar: ");
                        evaluaciones.lugar = Console.ReadLine();
                        Console.WriteLine("Sexo fué almacenado exitosamente ");
                        break;

                    default:
                        Console.WriteLine("\nAtributo no válido");
                        break;

                }
                contextdb.SaveChanges();

            }
            else
            {
                Console.WriteLine("\nEl Estudiante no ha sido encontrado");
            }
            break;
        break;
    }
}
       
    


    