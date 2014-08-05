using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.Utilities;
using System.Net;
using System.IO;

using System.Windows.Forms;

namespace SPUserAuditor
{
    class UserAuditor
    {

        string folderPath;
        bool includeChildren;
        ClientContext context;

        //URL Constants
        private const string userGroupUrl = "/_layouts/user.aspx";
        private const string groupMembersUrl = "/_layouts/people.aspx?MembershipGroupId=";

        public UserAuditor(string siteUrl, string formFolderPath, bool formIncludeChildren)
        {

            if (!formFolderPath.EndsWith("\\"))
                formFolderPath += "\\";
            folderPath = formFolderPath;
            includeChildren = formIncludeChildren;
            context = new ClientContext(siteUrl);
        }

        public void SetCredentials(string userName, string password)
        {
            context.Credentials = new NetworkCredential(userName, password);
        }

        public void StartUserAudit()
        {
            Web web = context.Web;
            context.Load(web);
            context.ExecuteQuery();
            GetUserAudit(web);
        }
        
        //http://msdn.microsoft.com/en-us/library/office/fp179912(v=office.15).aspx
        // Working with groups with csom http://msdn.microsoft.com/en-us/library/office/ee538244(v=office.14).aspx
        private void GetUserAudit(Web web)
        {
            GroupCollection collGroup = web.SiteGroups;
            context.Load(collGroup);
            context.ExecuteQuery();
            //First get a shot of the groups page
            //cant use serverRelative URL by itself, see blog for example
            // http://www.spdeveloper.co.in/tipsntricks/pages/values-for-spsite-spweb-url-properties.aspx
            string siteGroupsUrl = web.Url + userGroupUrl;
            string newFolder = folderPath + web.Title;
            if (!Directory.Exists(newFolder))
            {
                Directory.CreateDirectory(folderPath + web.Title);
            }
            
            string userGroupShotPath = newFolder + "\\" + "UserGroup.bmp";
            TakeIEScreenshot(siteGroupsUrl, userGroupShotPath);
            
            //Get groups screenshot here
            foreach (Group oGroup in collGroup)
            {
                // Go into group and get screen shot, maybe create a list
                string groupUrl = web.Url + groupMembersUrl + oGroup.Id;
                string groupShotPath = folderPath + "\\" + web.Title + "\\" + oGroup.Title + ".bmp";
                TakeIEScreenshot(groupUrl, groupShotPath);
            }

            if (includeChildren)
            {
                WebCollection webs = web.Webs;
                context.Load(webs);
                context.ExecuteQuery();

                if (webs.Count > 0)
                {
                    foreach (Web subsite in webs)
                    {
                        context.Load(subsite);
                        context.ExecuteQuery();
                        GetUserAudit(subsite);
                    }
                }

            }
        }

        private void TakeIEScreenshot(string siteURL, string fullPath)
        {
            var bmp = ScreenShot.Create(siteURL);
            bmp.Save(fullPath);


            string nextPageUrl = "";
            // Make this recursive and add if here for contains link
            using(var webBrowser = new WebBrowser())
            {
                webBrowser.ScriptErrorsSuppressed = true;
                webBrowser.Width = 1000;
                webBrowser.Height = 1000;
                webBrowser.Visible = true;
                webBrowser.ScrollBarsEnabled = false;
                webBrowser.Navigate(siteURL);
                
                while (webBrowser.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                }

                //Need to add logic to navigate to the next page
                HtmlElement topPagingCell = webBrowser.Document.GetElementById("topPagingCell");
                if (topPagingCell != null)
                {
                    HtmlElementCollection pageLinks = topPagingCell.GetElementsByTagName("a");
                    if (pageLinks.Count > 0)
                    {
                        
                        //  Need to add logic to go to the correct link
                        if (pageLinks.Count > 1)
                        {
                            nextPageUrl = pageLinks[1].OuterHtml;
                        }
                        else
                        {
                            nextPageUrl = pageLinks[0].OuterHtml;
                        }
                    }
                }
            }

            //  Moved this out of the using statement so that the browser object is dead before recursion.
            if (!String.IsNullOrWhiteSpace(nextPageUrl))
            {
                nextPageUrl = nextPageUrl.Split('"')[1];
                nextPageUrl = nextPageUrl.Replace("\\u002f", "/");
                nextPageUrl = nextPageUrl.Replace("\\u0026", "&");
                nextPageUrl = nextPageUrl.Replace("\\u0025", "%");

                if (!nextPageUrl.Contains("PagedPrev"))
                {
                    TakeIEScreenshot(nextPageUrl, fullPath + "somethingExtra.bmp");
                }
            }

        }



    }
}
