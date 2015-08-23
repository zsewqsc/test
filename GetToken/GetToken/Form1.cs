using eBay.Service.Call;
using eBay.Service.Core.Sdk;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetToken
{
    public partial class Form1 : Form
    {
        ApiAccount _apiAccount = new ApiAccount();
        ApiContext _apiContext = new ApiContext();
        string sessionId;
        public Form1()
        {
            InitializeComponent();

            _apiAccount.Application = "zxc0511f0-a1c1-4ef6-91e4-6f146f2f8fb";
            _apiAccount.Certificate = "13d3fcee-b188-47a1-af9f-11a7d8a58e22";
            _apiAccount.Developer = "80cd8f72-e5e9-4726-b9f6-197d142328c9";

            _apiContext.ApiCredential = new ApiCredential();
            _apiContext.ApiCredential.ApiAccount = _apiAccount;
            _apiContext.RuName = "zxc-zxc0511f0-a1c1--ryxnnwvvo";
            _apiContext.SoapApiServerUrl = "https://api.sandbox.ebay.com/wsapi";
            _apiContext.SignInUrl = "https://signin.sandbox.ebay.com/ws/eBayISAPI.dll?SignIn";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(GetTokenUrl());
        }

        private string GetTokenUrl()
        {
            GetSessionIDCall apiCall = new GetSessionIDCall(_apiContext);
            sessionId = apiCall.GetSessionID(_apiContext.RuName);
            string autbUrl = string.Format("{0}&RuName={1}&SessID={2}", _apiContext.SignInUrl, _apiContext.RuName, sessionId);
            return autbUrl;
        }

        private void GetToken()
        {
            FetchTokenCall fetchTokenCall = new FetchTokenCall(_apiContext);
            string token = fetchTokenCall.FetchToken(sessionId);
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetToken();
        }
    }
}
