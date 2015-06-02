using CC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["CC_CreateCharacter"] == null )
        {
            CharacterModification cm = new CharacterModification();
            Session.Add("CC_CreateCharacter",cm);
        }
    }
    protected void btn_insert_Click(object sender, EventArgs e)
    {
        if (Session["CC_CreateCharacter"] != null)
        {
            CharacterModification cm = (CharacterModification)Session["CC_CreateCharacter"];
            int indexJob = ddl_job.SelectedIndex;
            string name = txt_name.Text;
            cm.CreateCharacter(name,indexJob);
            ShowMessage("Character Inserted Successfully");
        }
        else
        {
            ShowMessage("Character not created!");
        }
    }

    private void ShowMessage(string message)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('"+message+"')", true);
    }
}