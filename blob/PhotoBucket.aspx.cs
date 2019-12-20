using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace BlobWebRole
{
    public partial class PhotoBucket : System.Web.UI.Page
    {
        CloudBlobContainer container;
        protected void Page_Load(object sender, EventArgs e)
        {
            CloudStorageAccount sa = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("SACS"));
            CloudBlobClient client = sa.CreateCloudBlobClient();
            container = client.GetContainerReference("photobucket");
            container.CreateIfNotExists();
            container.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
            ImageGrid.DataSource = container.ListBlobs();
            ImageGrid.DataBind();
        }

        protected void cmdUpload_Click(object sender, EventArgs e)
        {
            CloudBlockBlob blob = container.GetBlockBlobReference(ImageSelector.FileName);
            blob.UploadFromStream(ImageSelector.FileContent);
            Response.Redirect("PhotoBucket.aspx");

        }
    }
}