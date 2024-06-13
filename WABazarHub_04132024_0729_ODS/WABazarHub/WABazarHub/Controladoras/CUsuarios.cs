﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WABazarHub.Comunicacion;
using WABazarHub.ServiceReference1;

namespace WABazarHub.Controladoras
{
    public class CUsuarios
    {
        LNBazarHub lnBazarHub;
        public CUsuarios()
        {
            lnBazarHub = new LNBazarHub();
        }
        public void InsertarUsuario(EUsuario usuario)
        {
            lnBazarHub.InsertarUsuario(usuario);
        }

        public void ActualizarUsuario(EUsuario usuario)
        {
            lnBazarHub.ActualizarUsuario(usuario);
        }

        public void ActualizarEstadoUsuario(int usuarioID, string estado)
        {
            lnBazarHub.ActualizarUsuarioEstado(usuarioID, estado);
        }

        public void ActualizarFechaEdicionUsuario(int usuarioID, DateTime fechaEdicion)
        {
            lnBazarHub.ActualizarUsuarioFechaEdicion(usuarioID, fechaEdicion);
        }

        public List<EUsuario> ObtenerTodosUsuarios()
        {
            return lnBazarHub.ObtenerTodosUsuarios();
        }
    }
}