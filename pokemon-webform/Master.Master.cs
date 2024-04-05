using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace pokemon_webform
{
    public partial class Master : System.Web.UI.MasterPage
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            string urlImagenDefault = "https://simg.nicepng.com/png/small/202-2022264_usuario-annimo-usuario-annimo-user-icon-png-transparent.png";
            imgAvatar.ImageUrl = urlImagenDefault;
            if (!(Page is Login || Page is Default || Page is Registro || Page is Error)) //se puede poner this.Page pero no es necesario
            {
                
                if (!Seguridad.sesionActiva(Session["trainee"]))
                    Response.Redirect("Login.aspx", false);

                //else
                //{
                //    Trainee user = (Trainee)Session["trainee"];
                //    lblUser.Text = user.Email;
                //    if (!string.IsNullOrEmpty(user.ImagenPerfil))
                //        imgAvatar.ImageUrl = "~/Images/" + user.ImagenPerfil;
                //}
           
           
            }
            if (Seguridad.sesionActiva(Session["trainee"]))
            {
                Trainee user = (Trainee)Session["trainee"];
                if (!string.IsNullOrEmpty(user.ImagenPerfil))
                    imgAvatar.ImageUrl = "~/Images/" + ((Trainee)Session["trainee"]).ImagenPerfil;
                lblUser.Text = user.Email;
            }
            
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("login.aspx");
        }
    }
}