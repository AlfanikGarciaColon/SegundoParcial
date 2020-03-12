using Microsoft.EntityFrameworkCore;
using SegundoParcialAplicada.Data;
using SegundoParcialAplicada.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SegundoParcialAplicada.Controller
{
    public class CallsController
    {
        public bool Guardar(Calls call)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                if (call.CallId == 0)
                {
                    paso = Insertar(call);
                }
                else
                if (Buscar(call.CallId) != null)
                {
                    paso = false;
                }
                else
                {
                    paso = Modificar(call);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }


        private bool Insertar(Calls call)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Calls.Add(call);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }

        private bool Modificar(Calls call)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Database.ExecuteSqlRaw($"Delete From callDetalles where callId={call.CallId}");

                foreach (var item in call.Detalles)
                {
                    contexto.Entry(call).State = EntityState.Added;
                }

                contexto.Calls.Add(call);
                contexto.Entry(call).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public Calls Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Calls calls = new Calls();

            try
            {
                calls = contexto.Calls.Where(e => e.CallId == id).Include(d => d.Detalles).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            return calls;
        }

        public bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            Calls calls = new Calls();
            bool paso = false;

            try
            {
                calls = contexto.Calls.Find(id);
                contexto.Entry(calls).State = EntityState.Deleted;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public List<Calls> GetList(Expression<Func<Calls, bool>> expression)
        {
            Contexto contexto = new Contexto();
            List<Calls> list;

            try
            {
                list = contexto.Calls.Where(expression).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

    }
}