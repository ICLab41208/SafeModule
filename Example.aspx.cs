using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class Example : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.HttpMethod.ToUpper() != "POST" || !Request.ContentType.ToLower().Contains("application/json"))
            return;
        else
        {
            string json = GetPostBody;
            try
            {
                var contact = SafeModule.JSONHelper.Deserialize<Machine>(json);
                RecordToDB(contact);
                Debug("Get object! \n {0}", SafeModule.JSONHelper.ToJSON(contact));
            }
            catch (Exception ex)
            {
                Debug("Get invalid object!: {0}", ex.Message);
                return;
            }

        }

    }

    string GetPostBody
    {
        get
        {
            using (var reader = new StreamReader(Request.InputStream))
            {
                return reader.ReadToEnd();
            }
        }
    }
       
    void RecordToDB(Machine machineObject)
    {
        var conenectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["XXX"].ConnectionString;
        SqlConnection conn = new SqlConnection(conenectionString);
        SqlCommand cmd = new SqlCommand(@"XXXXXX", conn);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }

    void Debug(string format, params object[] arg)
    {
        var msg = string.Format(format, arg);
        Response.Write(msg);
        Console.WriteLine(msg);
    }

}
