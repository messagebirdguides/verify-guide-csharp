using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MessageBird;
using MessageBird.Exceptions;
using MessageBird.Objects;

public partial class Step2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Show an error if this page was previously called and SendVerifyToken generated an error
        if (Session["Error"] != null)
            ErrorLabel.Text = Session["Error"].ToString();
    }

    protected void CheckCodeButton_Click(object sender, EventArgs e)
    {
        // Check if code is empty
        if (CodeTextBox.Text.Length == 0)
        {
            Session["Error"] = "Verification code cannot be empty.";
            Server.Transfer("Step2.aspx");
            return;
        }

        // Call SendVerifyToken to verify the code entered in CodeTextBox.Text matches the code
        // sent to the user in the CreateVerify call in Step1.aspx.cs. Here, the words "token" and "code"
        // mean the same thing.
        try
        {
            Client client = ((Client)Session["Client"]);
            client.SendVerifyToken(Session["VerifyId"].ToString(), CodeTextBox.Text);
        }
        catch (ErrorException errorException)
        {
            Session["Error"] = ErrorGenerator.Generate(errorException);
            Server.Transfer("Step2.aspx");
        }
        Server.Transfer("Step3.aspx");
    }
}