using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

namespace pokemon_webform
{
    public partial class Default : System.Web.UI.Page
    {
        //creamos una propiedad de tipo lista:
        public List<Pokemon> ListaPokemon {  get; set; } 
        protected void Page_Load(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            ListaPokemon = negocio.listarConSP();

            if (!IsPostBack)
            {
                repRepetidor.DataSource = ListaPokemon;
                repRepetidor.DataBind();
            }
            
        }

        protected void btnEjemplo_Click(object sender, EventArgs e)
        {
            //El boton lanza el evento, y el argumento del boton es el sender
            string valor = ((Button)sender).CommandArgument;
        }
    }
}