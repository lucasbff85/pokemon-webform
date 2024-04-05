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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Trainee trainee = new Trainee();
            TraineeNegocio negocio = new TraineeNegocio();

            try
            {


                if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPassword.Text))
                {
                    Session.Add("error", "Debes completar ambos campos...");
                    Response.Redirect("Error.aspx"); // si pongo "Error.aspx", false   me sigue corriendo la función y me lleva al segundo catch (*)
                }

                trainee.Email = txtEmail.Text;
                trainee.Pass = txtPassword.Text;
                if (negocio.Login(trainee))
                {
                    Session.Add("trainee", trainee);
                    Response.Redirect("MiPerfil.aspx", false);
                }
                else
                {
                    Session.Add("error", "User o Pass incorrectos");
                    Response.Redirect("Error.aspx", false );
                }
            }
            catch (System.Threading.ThreadAbortException ex) { } // (*) le decimos que no haga nada podemos ponerlo dentro de un if en el catch ppal.
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        private void Page_Error(object sender, EventArgs e)
        {
            Exception exc = Server.GetLastError();

           Session.Add("error", exc.ToString());
           Server.Transfer("Error.aspx");

            //con esto el error no capturado pasaria por aca y no  va al global asax
        }
    }
}