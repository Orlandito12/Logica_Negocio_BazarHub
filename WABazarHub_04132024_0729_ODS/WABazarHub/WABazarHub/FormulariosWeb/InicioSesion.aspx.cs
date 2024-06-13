using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Mail;
using Microsoft.IdentityModel.Tokens;

namespace WABazarHub.FormulariosWeb
{
    public partial class InicioSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string captcha = GenerarCaptcha();
                Session["Captcha"] = captcha;
                lblCaptcha.Text = "CAPTCHA: " + captcha;

                string codigoAuth = GenerarCodigoAutenticacion();
                Session["CodigoAuth"] = codigoAuth;
                lblAuthCode.Text = "Código de Autenticación: " + codigoAuth;

            }
        }

        public string GenerarClaveSecreta()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] randomBytes = new byte[32];
                rng.GetBytes(randomBytes);
                return Convert.ToBase64String(randomBytes);
            }
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtUsuario.Text;
            string contraseña = txtPassword.Text;
            string usuarioPrueba = "usuario";
            string contraseñaPrueba = "123456";

            if (nombreUsuario == usuarioPrueba && contraseña == contraseñaPrueba)
            {
                string captchaGenerado = Session["Captcha"] as string;
                string captchaIngresado = txtCaptcha.Text;

                if (captchaGenerado == captchaIngresado)
                {
                    authPanel.Visible = true;
                    loginPanel.Visible = false;
                    captchaPanel.Visible = false;
                }
                else
                {
                    string captcha = GenerarCaptcha();
                    Session["Captcha"] = captcha;
                    lblCaptcha.Text = "CAPTCHA: " + captcha;
                }

            }
            else
            {
            }
        }
        protected string GenerarCodigoAutenticacion()
        {
            Random random1 = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 5)
              .Select(s => s[random1.Next(s.Length)]).ToArray());
        }

        private static readonly Random random = new Random();
        protected string GenerarCaptcha()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 6)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }


        protected void lnkRegistro_Click(object sender, EventArgs e)
        {
            Response.Redirect("InicioSesion.aspx");
        }

        protected void btnAuth_Click(object sender, EventArgs e)
        {
            string codigoAuthGenerado = Session["CodigoAuth"] as string;
            string codigoAuthIngresado = txtAuthCode.Text;

            if (codigoAuthGenerado == codigoAuthIngresado)
            {
                Response.Redirect("PaginaInicio.aspx");
            }
            else
            {
            }
        }
    }
}