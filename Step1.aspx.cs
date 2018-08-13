using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MessageBird;
using MessageBird.Exceptions;
using MessageBird.Objects;

public partial class Step1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Show an error if this page was previously called and CreateVerify generated an error
        if (Session["Error"] != null)
            ErrorLabel.Text = Session["Error"].ToString();
    }

    protected void SendCodeButton_Click(object sender, EventArgs e)
    {
        // Check if phone number is empty
        if (PhoneNumberTextBox.Text.Length == 0)
        {
            Session["Error"] = "Phone number cannot be empty.";
            Server.Transfer("Step1.aspx");
            return;
        }

        // Load the API key using the DotNetEnv library
        DotNetEnv.Env.Load(System.AppDomain.CurrentDomain.BaseDirectory + "/APIKey.env");
        String YourAccessKey = System.Environment.GetEnvironmentVariable("MESSAGEBIRD_API_KEY");

        // Initalize the MessageBird API
        MessageBird.Client client = MessageBird.Client.CreateDefault(YourAccessKey);

        Session["client"] = client;

        // Call CreateVerify to send a verification code to the user's phone. Here, we are sending "null" as the second
        // input. This input specifies optional settings, such as the timeout. Since we are sending "null", the default
        // timeout is used, which is 30 seconds.
        try
        {
            Verify verify = client.CreateVerify(PhoneNumberTextBox.Text, null);
            Session["VerifyId"] = verify.Id;
        }
        catch (ErrorException errorException)
        {
            Session["Error"] = ErrorGenerator.Generate(errorException);
            Server.Transfer("Step1.aspx");
        }
        Server.Transfer("Step2.aspx");
    }
}