using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZuydRPG_EF.CC;
using ZuydRPG_EF.HelperClasses;

namespace ZuydRPG_EF.UI
{
    public partial class CreateCharacter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_ok_Click(object sender, EventArgs e)
        {
            CC_CharacterModifcation cm = new CC_CharacterModifcation();
            cm.CreateCharacter(txt_name.Text);
            Utils.ShowMessage(this,"Character Created!");
        }
    }
}