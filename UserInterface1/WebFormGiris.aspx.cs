using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserInterface1
{
    public partial class WebFormGiris : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lHosgeldin.Text = "Hoşgeldin Çağıl";
        }
    }
}