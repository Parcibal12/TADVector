public class Vector
{
    private const int max = 10000;
    private int[] elementos;
    public int Longitud { get; private set; }

    public Vector()
    {
        elementos = new int[max];
        Longitud = 0;
    }

    public void ModificarLongitud(int nuevaLongitud)
    {
        if (nuevaLongitud >= 0 && nuevaLongitud <= max)
        {
            Longitud = nuevaLongitud;
        }
        else
        {
            Console.WriteLine("Longitud fuera de rango...");
        }
    }

    public int ObtenerLongitud()
    {
        return Longitud;
    }

    public void ColocarElemento(int posicion, int valor)
    {
        if (posicion >= 0 && posicion < Longitud)
        {
            elementos[posicion] = valor;
        }
        else
        {
            Console.WriteLine("Posición fuera de rango...");
        }
    }

    public void InsertarElemento(int pos, int valor)
    {
        if (pos < 0 || pos > Longitud || Longitud >= max)
        {
            Console.WriteLine("Posición fuera de rango...");
            return;
        }
        
        for (int i = Longitud; i > pos; i--)
        {
            elementos[i] = elementos[i - 1];
        }
        elementos[pos] = valor;
        Longitud++;
    }

    public void EliminarElemento(int pos)
    {
        if (pos < 0 || pos >= Longitud)
        {
            Console.WriteLine("Posición fuera de rango...");
            return;
        }
        
        for (int i = pos; i < Longitud - 1; i++)
        {
            elementos[i] = elementos[i + 1];
        }
        Longitud--;
    }

    public bool CompararVectores(Vector v2)
    {
        if (this.Longitud != v2.Longitud)
            return false;
        
        for (int i = 0; i < Longitud; i++)
        {
            if (this.elementos[i] != v2.elementos[i])
                return false;
        }
        return true;
    }

    public Vector Union(Vector v2)
    {
        Vector resultado = new Vector();
        resultado.ModificarLongitud(this.Longitud + v2.Longitud);
        
        for (int i = 0; i < this.Longitud; i++)
        {
            resultado.elementos[i] = this.elementos[i];
        }
        
        for (int i = 0; i < v2.Longitud; i++)
        {
            resultado.elementos[this.Longitud + i] = v2.elementos[i];
        }
        
        return resultado;
    }

    public bool Subconjunto(Vector v2)
    {
        for (int i = 0; i < v2.Longitud; i++)
        {
            bool encontrado = false;
            for (int j = 0; j < this.Longitud; j++)
            {
                if (v2.elementos[i] == this.elementos[j])
                {
                    encontrado = true;
                    break;
                }
            }
            if (!encontrado)
                return false;
        }
        return true;
    }

    public void EliminarDuplicados()
    {
        int[] temp = new int[Longitud];
        int nuevaLongitud = 0;

        for (int i = 0; i < Longitud; i++)
        {
            bool existe = false;
            for (int j = 0; j < nuevaLongitud; j++)
            {
                if (elementos[i] == temp[j])
                {
                    existe = true;
                    break;
                }
            }
            if (!existe)
            {
                temp[nuevaLongitud] = elementos[i];
                nuevaLongitud++;
            }
        }
        
        for (int i = 0; i < nuevaLongitud; i++)
        {
            elementos[i] = temp[i];
        }
        Longitud = nuevaLongitud;
    }

    public void MostrarElementos()
    {
        Console.WriteLine("Elementos del vector:");
        for (int i = 0; i < Longitud; i++)
        {
            Console.Write(elementos[i] + " ");
        }
        Console.WriteLine(); 
    }
}

public class Program
{
    public static void Main()
    {
        Console.Write("Ingrese la longitud del primer vector: ");
        int longitud1 = int.Parse(Console.ReadLine());
        Vector v1 = new Vector();
        v1.ModificarLongitud(longitud1);
        for (int i = 0; i < longitud1; i++)
        {
            Console.Write($"Ingrese el elemento {i + 1}: ");
            int valor = int.Parse(Console.ReadLine());
            v1.ColocarElemento(i, valor);
        }

        Console.Write("Ingrese la longitud del segundo vector: ");
        int longitud2 = int.Parse(Console.ReadLine());
        Vector v2 = new Vector();
        v2.ModificarLongitud(longitud2);
        for (int i = 0; i < longitud2; i++)
        {
            Console.Write($"Ingrese el elemento {i + 1}: ");
            int valor = int.Parse(Console.ReadLine());
            v2.ColocarElemento(i, valor);
        }

        Console.WriteLine("¿Los vectores son iguales? " + v1.CompararVectores(v2));
        Console.WriteLine("¿El segundo vector es subconjunto del primero? " + v1.Subconjunto(v2));

        Vector union = v1.Union(v2);
        Console.WriteLine("Vector unión creado con longitud: " + union.ObtenerLongitud());

        Console.WriteLine("Estado inicial del primer vector:");
        v1.MostrarElementos();

        Console.Write("Ingrese la posición del elemento a eliminar en el primer vector: ");
        int posEliminar = int.Parse(Console.ReadLine());
        v1.EliminarElemento(posEliminar);
        Console.WriteLine("Elemento eliminado. La nueva longitud del primer vector es: " + v1.ObtenerLongitud());
        v1.MostrarElementos(); 

        Console.Write("Ingrese la posición para insertar un nuevo elemento en el primer vector: ");
        int posInsertar = int.Parse(Console.ReadLine());
        Console.Write("Ingrese el valor del nuevo elemento: ");
        int valorInsertar = int.Parse(Console.ReadLine());
        v1.InsertarElemento(posInsertar, valorInsertar);
        Console.WriteLine("Elemento insertado. La nueva longitud del primer vector es: " + v1.ObtenerLongitud());
        v1.MostrarElementos(); 

        v1.EliminarDuplicados();
        Console.WriteLine("Duplicados eliminados. La nueva longitud del primer vector es: " + v1.ObtenerLongitud());
        v1.MostrarElementos();

        Console.WriteLine("Estado inicial del segundo vector:");
        v2.MostrarElementos();
        Console.Write("Ingrese la posición del elemento a eliminar en el segundo vector: ");
        int posEliminar2 = int.Parse(Console.ReadLine());
        v2.EliminarElemento(posEliminar2);
        Console.WriteLine("Elemento eliminado. La nueva longitud del segundo vector es: " + v2.ObtenerLongitud());
        v2.MostrarElementos();

        Console.Write("Ingrese la posición para insertar un nuevo elemento en el segundo vector: ");
        int posInsertar2 = int.Parse(Console.ReadLine());
        Console.Write("Ingrese el valor del nuevo elemento: ");
        int valorInsertar2 = int.Parse(Console.ReadLine());
        v2.InsertarElemento(posInsertar2, valorInsertar2);
        Console.WriteLine("Elemento insertado. La nueva longitud del segundo vector es: " + v2.ObtenerLongitud());
        v2.MostrarElementos();
    }
}
