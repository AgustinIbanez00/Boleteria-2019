using System.ComponentModel.DataAnnotations;

namespace Boleteria.Core.Models
{
    public class Distribucion
    {
        [Key]
        int id;
        [Key]
        [StringLength(128)]
        string nota;
        int cant_PB = 25;
        int cant_PA = 25;
        bool unPiso;
        List<Fila> matriz_PB;
        List<Fila> matriz_PA;

        public static int ESPACIO_NULL = -1;
        public static int ESPACIO_PASILLO = 1;
        public static int ESPACIO_BUTACA = 2;
        public static int ESPACIO_TV = 3;

        public Distribucion(int cantidad_PB)
        {
            this.cant_PB = cantidad_PB;
            if (cantidad_PB / 5 > 0)
            {
                matriz_PB = InicializarListaCeldas((cantidad_PB / 5), 5);
            }
            //unPiso = true;
        }

        public Distribucion(int cantidad_PB, int cantidad_PA)
        {
            this.cant_PB = cantidad_PB;
            this.cant_PA = cantidad_PA;
            if (cantidad_PB / 5 > 0)
            {
                matriz_PB = InicializarListaCeldas((cantidad_PB / 5), 5);
            }
            if (cantidad_PA / 5 > 0)
            {
                matriz_PA = InicializarListaCeldas((cantidad_PA / 5), 5);
            }
            //unPiso = false;
        }

        public Distribucion()
        {
        }

        public List<Fila> InicializarListaCeldas(int rows, int columns)
        {
            List<Fila> row_list = new List<Fila>();

            for (int i = 0; i < rows; i++)
            {
                Fila fila = new Fila();
                fila.Cells = new List<Celda>();

                for (int j = 0; j < columns; j++)
                {
                    Celda celda = new Celda()
                    {
                        Value = 0,
                        FechaRegistro = DateTime.Now
                    };
                    fila.Cells.Add(celda);
                }
                row_list.Add(fila);
            }
            return row_list;
        }

        public void AddRowCells(string matriz, int rows)
        {
            List<Fila> matriz_list = null;
            int rows_temp = -1;

            if (matriz == "PB")
            {
                matriz_list = matriz_PB;
                rows_temp = matriz_PB.Count;
            }
            else if (matriz == "PA")
            {
                matriz_list = matriz_PA;
                rows_temp = matriz_PA.Count;
            }

            if (matriz_list != null && rows_temp != -1)
            {
                for (int i = 0; i < rows; i++)
                {
                    Fila row = new Fila();
                    row.Cells = new List<Celda>();
                    for (int j = 0; j < 5; j++)
                    {
                        Celda cell = new Celda()
                        {
                            Value = 0,
                            FechaRegistro = DateTime.Now
                        };
                        row.Cells.Add(cell);
                    }
                    matriz_list.Add(row);
                }
            }
        }

        public void RemoveRowCells(string matriz, int rows)
        {
            List<Fila> matriz_list = null;
            int rows_temp = -1;

            if (matriz == "PB")
            {
                matriz_list = matriz_PB;
                rows_temp = matriz_PB.Count;
            }
            else if (matriz == "PA")
            {
                matriz_list = matriz_PA;
                rows_temp = matriz_PB.Count;
            }

            if (matriz_list != null && rows_temp != -1)
            {
                for (int i = 0; i < rows; i++)
                {
                    matriz_list.Remove(matriz_list.Last());
                }
            }
        }


        public void SetCellContent(string matriz, int fila, int columna, int value)
        {
            List<Fila> matriz_list = null;

            if (matriz == "PB") matriz_list = matriz_PB;
            else if (matriz == "PA") matriz_list = matriz_PA;

            if (matriz_list != null)
            {
                matriz_list[fila].Cells[columna].Value = value;
            }
        }

        public int GetCellContent(string matriz, int fila, int columna)
        {
            List<Fila> matriz_list = null;

            if (matriz == "PB") matriz_list = matriz_PB;
            else if (matriz == "PA") matriz_list = matriz_PA;

            if (matriz_list != null) return matriz_list[fila].Cells[columna].Value;
            return -1;
        }

        public void AgregarPasilloPB(int x, int y)
        {
            SetCellContent("PB", x, y, ESPACIO_PASILLO);
        }

        public void AgregarButacaPB(int x, int y)
        {
            SetCellContent("PB", x, y, ESPACIO_BUTACA);
        }

        public void AgregarTVPB(int x, int y)
        {
            SetCellContent("PB", x, y, ESPACIO_TV);
        }

        public void RemoverPB(int x, int y)
        {
            SetCellContent("PB", x, y, ESPACIO_NULL);
        }

        public void AgregarPasilloPA(int x, int y)
        {
            SetCellContent("PA", x, y, ESPACIO_PASILLO);
        }

        public void AgregarButacaPA(int x, int y)
        {
            SetCellContent("PA", x, y, ESPACIO_BUTACA);
        }

        public void AgregarTVPA(int x, int y)
        {
            SetCellContent("PA", x, y, ESPACIO_TV);
        }

        public void RemoverPA(int x, int y)
        {
            SetCellContent("PA", x, y, ESPACIO_NULL);
        }

        public int Id { get => id; set => id = value; }
        public List<Fila> Matriz_PB { get => matriz_PB; set => matriz_PB = value; }
        public List<Fila> Matriz_PA { get => matriz_PA; set => matriz_PA = value; }
        public string Nota { get => nota; set => nota = value; }
        public bool UnPiso { get => unPiso; set => unPiso = value; }

        /*
public int FilasPB { get => filas_pb;
set
{
if (matriz_PB == null && value != 0) matriz_PB = InicializarListaCeldas(value, 5);

if (value != filas_pb && filas_pb != 0)
{
if(value > filas_pb)
{
AddRowCells("PB", value-filas_pb);
}
else if(value < filas_pb)
{
RemoveRowCells("PB", filas_pb-value);
}
}
filas_pb = value;
}
}
public int FilasPA { get => filas_pa;
set
{
if (matriz_PA == null && value != 0) matriz_PA = InicializarListaCeldas(value, 5);

if (value != filas_pa && filas_pa != 0)
{
if (value > filas_pa)
{
AddRowCells("PA", value-filas_pa);
}
else if (value < filas_pa)
{
RemoveRowCells("PA", filas_pa-value);
}
}
filas_pa = value;
}
}
*/
        public int ContarAsientos()
        {
            int c = 0;
            for (int i = 0; i < matriz_PA.Count; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (GetCellContent("PA", i, j) == ESPACIO_BUTACA)
                        c++;
                }
            }
            for (int i = 0; i < matriz_PB.Count; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (GetCellContent("PB", i, j) == ESPACIO_BUTACA)
                        c++;
                }
            }
            return c;
        }

    }
}
