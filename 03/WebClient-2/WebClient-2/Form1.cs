using System.Net;

namespace WebClient_2
{
    /// <summary>
    /// Consuming Web Services using HttpWebRequest
    /// </summary>

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WebRequest myWebRequest = null;
            HttpWebResponse myResponse = null;
            Stream myStream = null;
            StreamReader myReader = null;
            try
            {
                myWebRequest = WebRequest.Create("http://webclient.fenris.ucn.dk/webclient2.txt");
                myResponse = (HttpWebResponse)myWebRequest.GetResponse();
                statusBox.Text = myResponse.StatusDescription;
                myStream = myResponse.GetResponseStream();
                myReader = new StreamReader(myStream);
                responseBox.Text = myReader.ReadToEnd();
            }
            catch
            {
                statusBox.Text = "FAILED TO GET STUFF";
            }
            finally
            {
                myReader.Close();
                myStream.Close();
                myResponse.Close();
            }
        }
    }
}