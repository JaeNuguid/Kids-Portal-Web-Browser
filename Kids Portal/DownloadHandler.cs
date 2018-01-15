using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kids_Portal
{
    class DownloadHandler: IDownloadHandler
    {
       
            public event EventHandler<DownloadItem> OnBeforeDownloadFired;

            public event EventHandler<DownloadItem> OnDownloadUpdatedFired;

            public void OnBeforeDownload(IBrowser browser, DownloadItem downloadItem, IBeforeDownloadCallback callback)
            {

            DialogResult dialogResult = MessageBox.Show("Kids Portal is strictly for browsing only.\n\nDownloading is prohibited.", "Kids Portal - Protection", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            if (dialogResult == DialogResult.Yes)
            {
                // parent login
                if (true) {
                    var handler = OnBeforeDownloadFired;
                    if (handler != null)
                    {
                        handler(this, downloadItem);
                    }

                    if (!callback.IsDisposed)
                    {
                        using (callback)
                        {
                            callback.Continue(downloadItem.SuggestedFileName, showDialog: true);
                        }
                    }
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
            
            }

            public void OnDownloadUpdated(IBrowser browser, DownloadItem downloadItem, IDownloadItemCallback callback)
            {
                var handler = OnDownloadUpdatedFired;
                if (handler != null)
                {
                    handler(this, downloadItem);
                }
            }
        
    }
}
