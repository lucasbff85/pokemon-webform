using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace pokemon_webform
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Seguridad.sesionActiva(Session["trainee"]))
                    {
                        Trainee user = (Trainee)Session["trainee"];
                        txtEmail.Text = user.Email;
                        txtEmail.ReadOnly = true;
                        txtNombre.Text = user.Nombre;
                        txtApellido.Text = user.Apellido;
                        txtFechaNacimiento.Text = user.FechaNacimiento.ToString("dd-MM-yyyy");
                        if(!string.IsNullOrEmpty(user.ImagenPerfil))
                            imgNuevoPerfil.ImageUrl = "~/Images"+ user.ImagenPerfil;
                        
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            //Trainee trainee = Session["trainee"] != null ? (Trainee)Session["trainee"] : null;
            ////pienso lo que necesito y despues lo niego:
            //if(!(trainee != null && trainee.Id != 0))
               // Response.Redirect("Login.aspx", false);

            
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                Page.Validate();   //son las validaciones que tenemos en esa pagina
                if (!Page.IsValid)  //hacemos esto porque las validaciones muestran cartel pero siguen, enconces con esto cortamos
                    return;


                TraineeNegocio negocio = new TraineeNegocio();

                Trainee user = (Trainee)Session["trainee"];

                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;
                user.FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);

                //ESCRIBIR IMG si se cargó algo:
                if(txtImagen.PostedFile.FileName != "")
                {
                    // MapPath de la clase Server, nos da la ruta física de donde se corre la app (pokemon-webform), luego le indicamos la carpeta, y dejamos barra al final para agregar el archivo
                    string ruta = Server.MapPath("./Images/");

                    //posted file carga los datos del archivo que la persona esta subiendo
                    txtImagen.PostedFile.SaveAs(ruta + "perfil-" + user.Id + ".jpg");
                    //con save as le indicamos como se va a guardar, en este caso la ruta, y le agregamos un indicador de la id del perfil, también la extensión

                    user.ImagenPerfil = "perfil-" + user.Id + ".jpg";
                }


                
                negocio.actualizar(user);

                //LEER IMG:
                       //Master.FindControl para tomar el objeto de la master con su id
                Image img = (Image)Master.FindControl("imgAvatar");
                       //la virgulilla (alt + 126) sirve para posicionarnos en la ubicacion base de la app (pokemon-webform)
                img.ImageUrl = "~/Images/" + user.ImagenPerfil;

                //Response.Redirect("Default.aspx", false);


            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }
    }
}