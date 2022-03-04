using Microsoft.EntityFrameworkCore;
using Nomina_Empleados_Leng.DAL;
using Nomina_Empleados_Leng.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nomina_Empleados_Leng.BLL
{
    public class NominasBLL
    {
        public static bool Guardar(Nominas nominas)
        {
            if (!Existe(nominas.NominaId))
                return Insertar(nominas);
            else
                return Modificar(nominas);
        }
        private static bool Insertar(Nominas nominas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Nominas.Add(nominas);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }
        public static bool Modificar(Nominas nominas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(nominas).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var nominas = contexto.Nominas.Find(id);
                if (nominas != null)
                {
                    contexto.Nominas.Remove(nominas);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }
        public static Nominas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Nominas nominas;

            try
            {
                nominas = contexto.Nominas.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return nominas;
        }
        public static List<Nominas> GetList(Expression<Func<Nominas, bool>> criterio)
        {
            List<Nominas> lista = new List<Nominas>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Nominas.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Nominas.Any(c => c.NominaId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }
        public static List<Nominas> GetList()
        {
            List<Nominas> nominas = new List<Nominas>();
            Contexto contexto = new Contexto();

            try
            {
                nominas = contexto.Nominas.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return nominas;
        }
        public static List<Nominas> GetNominas()
        {
            List<Nominas> lista = new List<Nominas>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Nominas.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }
    }
}
