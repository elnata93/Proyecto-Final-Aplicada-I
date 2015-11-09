using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class Cobradores : ClaseMaestra
    {
        ConexionDb conexion = new ConexionDb();

        public int CobradorId;
        public string Nombres;
        public string Apellidos;
        public string Direccion;
        public string Telefono;
        public string Celular;
        public string Cedula;
        public int RutaId;
         
        public Cobradores()
        {
            this.CobradorId = 0;
            this.Nombres = "";
            this.Apellidos = "";
            this.Direccion = "";
            this.Telefono = "";
            this.Celular = "";
            this.Cedula = "";
            this.RutaId = 0;
           // Rutas = new List<Rutas>();
        }

        /*public List<Rutas> Rutas { get; set; }

        public void AgregarRuta(int RutaId, string NombreRuta)
        {
            this.Rutas.Add(new Rutas(RutaId, NombreRuta));
        }*/
        public override bool Insertar()
        {
            bool retorno = false;
            conexion.Ejecutar(String.Format("Insert Into Cobradores(Nombres,Apellidos, Direccion,Telefono,Celular,Cedula,RutaId) values('{1}','{2}','{3}','{4}','{5}','{6}','{7}')",this.Nombres,this.Apellidos,this.Direccion,this.Telefono,this.Celular,this.Cedula,this.RutaId));
            return retorno;
        }

        public override bool Editar()
        {
            bool retorno = false;
            conexion.Ejecutar(String.Format("Update Cobradores set Nombres='{1}',Apellidos='{2}', Direccion='{3}',Telefono='{4}',Celular='{5}',Cedula='{6}',RutaId='{7}'", this.Nombres, this.Apellidos, this.Direccion, this.Telefono, this.Celular, this.Cedula, this.RutaId));
            return retorno;
        }

        public override bool Eliminar()
        {
            bool retorno = false;
            conexion.Ejecutar(String.Format("Delete from Cobradores where CobradorId",this.CobradorId));
            return retorno;
        }
        public override bool Buscar(int IdBuscado)
        {
            bool retorno = false;
            DataTable dt = new DataTable();
            DataTable dtRuta = new DataTable();
            dt = conexion.ObtenerDatos(String.Format("Select Nombres,Apellidos, Direccion,Telefono,Celular,Cedula,RutaId from Cobradores where CobradorId='{0}'", IdBuscado));
            if(dt.Rows.Count > 0)
            {
                this.Nombres = dt.Rows[0]["Nombres"].ToString();
                this.Apellidos = dt.Rows[0]["Apellidos"].ToString();
                this.Direccion = dt.Rows[0]["Direccion"].ToString();
                this.Telefono = dt.Rows[0]["Telefono"].ToString();
                this.Celular = dt.Rows[0]["Celular"].ToString();
                this.RutaId = (int)dt.Rows[0]["RutaId"];
            } 
            return retorno;
        } 
         
        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            string ordenFinal = ""; //!orden.Equals("") ? " orden by  " + orden : "";
            if (!Orden.Equals(""))
                ordenFinal = " orden by  " + Orden;

            return conexion.ObtenerDatos(("Select " + Campos +
                " from Cobradores where " + Condicion + ordenFinal));
        }
    }
}
