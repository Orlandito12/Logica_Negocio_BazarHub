using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WABazarHub.MasterPage
{
    public partial class PaginaMaestraInicio : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnInicioSesion_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/FormulariosWeb/InicioSesion.aspx"); 

        }

    }
}