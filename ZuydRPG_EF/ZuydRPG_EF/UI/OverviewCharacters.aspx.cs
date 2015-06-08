using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZuydRPG_EF.CC;

namespace ZuydRPG_EF.UI
{
    public partial class OverviewCharacters : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CC_CharacterModifcation cm = new CC_CharacterModifcation();
            List<string> names = cm.GetCharacterNames();
            foreach(string name in names)
            {
                ListItem li = new ListItem();
                li.Value = name;
                listBox_characters.Items.Add(li);
            }
        }
    }
}