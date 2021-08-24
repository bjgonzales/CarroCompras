using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace CarroCompras.Models
{
    public class MantenimientoCliente
    {
        public SqlConnection con;

        public void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["cnxbd"].ToString();
            con = new SqlConnection(constr);
        }

        public List<Clientes> ObtenerClientes()
        {
            Conectar();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Pr_Listar_Cliente";
            cmd.Connection = con;
            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            List<Clientes> clientes = new List<Clientes>();
            while (dr.Read())
            {
                Clientes cliente = new Clientes()
                {
                    Id = Convert.ToInt32(dr["Id"].ToString()),
                    Nombre = dr["Nombre"].ToString(),
                    Apellido = dr["Apellido"].ToString(),
                    Correo = dr["Correo"].ToString(),
                    FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"].ToString()),
                    Sueldo = Convert.ToDecimal(dr["Sueldo"].ToString()),
                    Edad = Convert.ToInt32(dr["Edad"].ToString())
                };

                clientes.Add(cliente);

            }
            con.Close();
            return clientes;
        }

        public Clientes ObtenerCliente(int id)
        {
            Clientes cliente = new Clientes();
            Conectar();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Pr_Obtener_Cliente";
            cmd.Connection = con;
            con.Open();

            cmd.Parameters.AddWithValue("@id", id);

            var dr = cmd.ExecuteReader();
            dr.Read();


            cliente.Nombre = dr["Nombre"].ToString();
            cliente.Apellido = dr["Apellido"].ToString();
            cliente.Correo = dr["Correo"].ToString();
            cliente.FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"].ToString());
            cliente.Sueldo = Convert.ToDecimal(dr["Sueldo"].ToString());
            cliente.Edad = Convert.ToInt32(dr["Edad"].ToString());


            return cliente;
        }

        public void Crear(Clientes clientes)
        {
            Conectar();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Pr_Insertar_Cliente";
            cmd.Connection = con;
            con.Open();

            cmd.Parameters.AddWithValue("@nombre", clientes.Nombre);
            cmd.Parameters.AddWithValue("@apellido", clientes.Apellido);
            cmd.Parameters.AddWithValue("@correo", clientes.Correo);
            cmd.Parameters.AddWithValue("@fechanacimiento", clientes.FechaNacimiento);
            cmd.Parameters.AddWithValue("@sueldo", clientes.Sueldo);
            cmd.Parameters.AddWithValue("@edad", clientes.Edad);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Eliminar(Clientes clientes)
        {
            Conectar();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Pr_Eliminar_Cliente";
            cmd.Connection = con;
            con.Open();

            cmd.Parameters.AddWithValue("@id", clientes.Id);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Actualizar(Clientes clientes)
        {
            Conectar();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Pr_Actualizar_Cliente";
            cmd.Connection = con;
            con.Open();

            cmd.Parameters.AddWithValue("@id", clientes.Id);

            cmd.Parameters.AddWithValue("@nombre", clientes.Nombre);
            cmd.Parameters.AddWithValue("@apellido", clientes.Apellido);
            cmd.Parameters.AddWithValue("@correo", clientes.Correo);
            cmd.Parameters.AddWithValue("@fechanacimiento", clientes.FechaNacimiento);
            cmd.Parameters.AddWithValue("@sueldo", clientes.Sueldo);
            cmd.Parameters.AddWithValue("@edad", clientes.Edad);


            cmd.ExecuteNonQuery();
            
            con.Close();
        }
    }
}