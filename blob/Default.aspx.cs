using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;

namespace BlobWebRole
{
    public partial class Default : System.Web.UI.Page
    {
        CloudStorageAccount sa;
        CloudBlobClient client;
        CloudBlobContainer container;
        CloudBlockBlob blob;
        protected void Page_Load(object sender, EventArgs e)
        {
            sa = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("SACS"));
            client = sa.CreateCloudBlobClient();
            container = client.GetContainerReference("images");
            container.CreateIfNotExists();
            blob = container.GetBlockBlobReference("Seed Fund2.pptx");
        }

        protected void Upload_Click(object sender, EventArgs e)
        {
            blob.UploadFromStream(File.OpenRead(@"D:\phd\iceeccot\Seed Fund2.pptx"));

        }

        protected void Download_Click(object sender, EventArgs e)
        {
            blob.DownloadToStream(File.OpenWrite(@"D:\phd\iceeccot\Seed Fund3.pptx"));
        }
    }
}