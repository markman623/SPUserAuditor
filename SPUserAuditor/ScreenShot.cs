using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using System.Text;

/// <summary>
/// Code taken from page: https://gist.github.com/JoshClose/1366260
/// </summary>
public class ScreenShot
{
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("0000010d-0000-0000-C000-000000000046")]
    private interface IViewObject
    {
        [PreserveSig]
        int Draw([In] [MarshalAs(UnmanagedType.U4)] int dwDrawAspect, int lindex, IntPtr pvAspect,
                 [In] /*tagDVTARGETDEVICE*/ IntPtr ptd, IntPtr hdcTargetDev, IntPtr hdcDraw,
                 [In] /*COMRECT*/ Rectangle lprcBounds, [In] /*COMRECT*/ IntPtr lprcWBounds, IntPtr pfnContinue,
                 [In] int dwContinue);

        [PreserveSig]
        int GetColorSet([In] [MarshalAs(UnmanagedType.U4)] int dwDrawAspect, int lindex, IntPtr pvAspect,
                        [In] /*tagDVTARGETDEVICE*/ IntPtr ptd, IntPtr hicTargetDev, [Out] /*tagLOGPALETTE*/ IntPtr ppColorSet);

        [PreserveSig]
        int Freeze([In] [MarshalAs(UnmanagedType.U4)] int dwDrawAspect, int lindex, IntPtr pvAspect, [Out] IntPtr pdwFreeze);

        [PreserveSig]
        int Unfreeze([In] [MarshalAs(UnmanagedType.U4)] int dwFreeze);

        void SetAdvise([In] [MarshalAs(UnmanagedType.U4)] int aspects, [In] [MarshalAs(UnmanagedType.U4)] int advf,
                     [In] [MarshalAs(UnmanagedType.Interface)] /*IAdviseSink*/ IntPtr pAdvSink);

        void GetAdvise([In] [Out] [MarshalAs(UnmanagedType.LPArray)] int[] paspects,
                       [In] [Out] [MarshalAs(UnmanagedType.LPArray)] int[] advf,
                       [In] [Out] [MarshalAs(UnmanagedType.LPArray)] /*IAdviseSink[]*/ IntPtr[] pAdvSink);
    }

    public static Bitmap Create(string url)
    {
        using (var webBrowser = new WebBrowser())
        {
            
            // did not work until I specified the browser h & w 
            // or always ended up being something too small
            webBrowser.ScriptErrorsSuppressed = true;
            webBrowser.Width = 1000;
            webBrowser.Height = 1500;
            //webBrowser.Visible = true;
            webBrowser.ScrollBarsEnabled = false;
            webBrowser.AllowNavigation = true;
            webBrowser.AllowWebBrowserDrop = true;
            webBrowser.Navigate(url);
            //webBrowser.Navigate(new Uri(url), "_parent", null, @"User-Agent: Mozilla/4.0 (compatible; MSIE 10.0; Windows NT 6.1; Trident/5.0)");

            while (webBrowser.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }

            //webBrowser.Document.InvokeScript("AllowCSSFiltersOnIE8");
            //while (webBrowser.ReadyState != WebBrowserReadyState.Complete)
            //{
            //    Application.DoEvents();

            //}
            //webBrowser.Width = webBrowser.Document.Body.ScrollRectangle.Width;
            //webBrowser.Height = webBrowser.Document.Body.ScrollRectangle.Height;

            // Needed to modify this bc SharePoint does not use default browser scroll bars
            // Will need to add a feature to change the element fetched according to the master page used.
            HtmlElement mainBody = webBrowser.Document.GetElementById("s4-workspace");
            //mainBody.Style += "overflow: scroll;";
            webBrowser.Width = mainBody.ScrollRectangle.Width;
            webBrowser.Height = mainBody.ScrollRectangle.Height;  // 65 px is to account for tool bar

            var bitmap = new Bitmap(webBrowser.Width, webBrowser.Height);
            var graphics = Graphics.FromImage(bitmap);
            var hdc = graphics.GetHdc();
            
            var rect = new Rectangle(0, 0, webBrowser.Width, webBrowser.Height);

            var viewObject = (IViewObject)webBrowser.Document.DomDocument;
            viewObject.Draw(1, -1, (IntPtr)0, (IntPtr)0, (IntPtr)0, hdc, rect, (IntPtr)0, (IntPtr)0, 0);

            graphics.ReleaseHdc(hdc);

            return bitmap;
        }
    }
}
