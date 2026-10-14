
namespace EmpresaApp
{
    
    public abstract class Empleado
    {

        public string Nombre { get; set; }
        public decimal Salario { get; set; }

        public Empleado(string nombre, decimal salario)
        {
            Nombre = nombre;
            Salario = salario;
        }

        public abstract decimal CalcularSalario();

        public virtual void ObtenerInformacion()
        {
            Console.WriteLine($"Nombre: {Nombre}, Salario: {Salario:C}");
            Console.WriteLine($"Rol: {this.GetType().Name} | Nombre: {Nombre} | Salario: {Salario:C} | Bono: {CalcularSalario():C} | Total: {Salario + CalcularSalario():C}");
           // Console.WriteLine($"Rol: {this.GetType().Name,-12} | Nombre: {Nombre,-10} | Salario: {Salario,8:C} | Bono: {CalcularSalario(),8:C} | Total: {Salario + CalcularSalario(),8:C}");
        }
    }

    public class Developer : Empleado
    {
        public Developer(string nombre, decimal salario) : base(nombre, salario) { }
        public override decimal CalcularSalario()
        {
            return Salario * 0.10m; 
        }
    }

    public class TeamLead : Empleado
    {
        public TeamLead(string nombre, decimal salario) : base(nombre, salario) { }
        public override decimal CalcularSalario()
        {
            return Salario * 0.15m; 
        }
    }

    public class ProjectManager : Empleado
    {
        public ProjectManager(string nombre, decimal salario) : base(nombre, salario) { }
        public override decimal CalcularSalario()
        {
            return Salario * 0.20m; 
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== CÁLCULO DE BONOS DE EMPLEADOS ===\n");

            List<Empleado> empleados = new List<Empleado>
            {
                new Developer("Alice", 50000),
                new Developer("Jacson", 60000),
                new TeamLead("Bob", 70000),
                new ProjectManager("Charlie", 90000)
            };
            foreach (var empleado in empleados)
            {
                empleado.ObtenerInformacion();
            }
        }
    }


}