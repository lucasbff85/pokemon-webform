using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace pokemon_webform
{
    public class Validacion
    {
        public static bool validaTextoVacio(object control)
        {
            //VALIDACION CLASICA    
            //esta clase la dejamos aca en webform para que me tome los controles 


            //if (control is TextBox)
            //{
            //    if (string.IsNullOrEmpty(((TextBox)control).Text)) la documentacion dice que hagamos los sigueinte pare evitar todo ese casteo:  

            if (control is TextBox texto)
            {
                if (string.IsNullOrEmpty((texto.Text)))
                    return false;
                else
                    return true;

            }
            return false;
        }

    }
}